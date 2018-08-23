using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;

namespace Model
{
    /// <summary>
    ///  EntityFramework仓储操作基类
    /// </summary>
    /// <typeparam name="Tentity">动态实体类</typeparam>
    public class EFRepositoryBase<TEntity> : IEFRepository<TEntity> where TEntity : class
    {


        private HSJXEntities EFContext;
        public EFRepositoryBase()
        {
            //构造函数直接初始化
            EFContext = ServiceLocator.Current.GetInstance<HSJXEntities>();
        }



   

        //使用够着函数



        /// <summary>
        /// 使用单利模式 
        /// </summary>
        /// <returns></returns>
        public  HSJXEntities GetDataContext()
        {
            return EFContext;
        }


        /// <summary>
        /// 插入实体对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isSave">是否执行保存</param>
        /// <returns>操作影响行数</returns>
        public bool AddEntity(TEntity entity, bool isSave = true)
        {
            var DBContext = GetDataContext();
            DBContext.Entry<TEntity>(entity).State = EntityState.Added;
            return SaveCommit(isSave);


        }

        bool SaveCommit(bool isSave)
        {
            int EffectRows = 0;
            if (isSave)
            {
                EffectRows = GetDataContext().SaveChanges();
            }
            return isSave == false ? true : EffectRows > 0;
        }

        public bool AddEntity(IEnumerable<TEntity> entities, bool isSave = true)
        {
            var DBContext = GetDataContext();
            {
                foreach (var item in entities)
                {
                    DBContext.Entry<TEntity>(item).State = EntityState.Added;
                }
                return SaveCommit(isSave);
            }

        }

        /// <summary>
        /// 插入实体记录集合
        /// </summary>
        /// <param name="entities">实体记录集合</param>
        /// <param name="isSave">是否知悉保存</param>
        /// <returns>操作影响行数</returns>
        public bool AddEntityByBluk(IEnumerable<TEntity> entities, bool isSave = true)
        {

            HSJXEntities DBContext = GetDataContext();

            entities = entities.ToArray();
            var conn = new SqlConnection(DBContext.Database.Connection.ConnectionString);
            conn.Open();
            Type t = typeof(TEntity);
            var bulkCopy = new SqlBulkCopy(conn)
            {
                DestinationTableName = t.Name
            };
            var properties = t.GetProperties().ToArray();
            var table = new DataTable();

            foreach (var property in properties)
            {
                Type propertyType = property.PropertyType;
                if (propertyType.IsGenericType &&
                    propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    propertyType = Nullable.GetUnderlyingType(propertyType);
                }

                table.Columns.Add(new DataColumn(property.Name, propertyType));
            }

            foreach (var entity in entities)
            {
                table.Rows.Add(properties.Select(
                  property => GetPropertyValue(
                  property.GetValue(entity, null))).ToArray());
            }
            //其实可以修改按照列名匹配写入DB
            bulkCopy.WriteToServer(table);
            conn.Close();
            return true;

        }
        private object GetPropertyValue(object o)
        {
            if (o == null)
                return DBNull.Value;
            return o;
        }

        /// <summary>
        /// 删除实体记录集合
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>操作影响行数</returns>
        public bool DeleteEntity(TEntity entity, bool isSave = true)
        {


            GetDataContext().Set<TEntity>().Attach(entity);
            GetDataContext().Entry<TEntity>(entity).State = EntityState.Deleted;
            return SaveCommit(isSave);
        }

        /// <summary>
        /// 删除实体记录集合
        /// </summary>
        /// <param name="key">实体记录key</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>操作影响行数</returns>
        public bool DeleteEntity(object key, string keyName = "ID", bool isSave = true)
        {
            List<TEntity> Entities = GetDataContext().Set<TEntity>().ToList<TEntity>();


            foreach (var item in Entities)
            {
                if (GetObjectPropertyValue(item, keyName).ToString() == key.ToString())
                {
                    //执行删除
                    GetDataContext().Set<TEntity>().Attach(item);
                    GetDataContext().Entry<TEntity>(item).State = EntityState.Deleted;
                }
            }

            return SaveCommit(isSave);
        }

        /// <summary>
        /// 删除实体集合
        /// </summary>
        /// <param name="entities">实体对象</param>
        /// <param name="isSave">是否执行保存</param>
        /// <returns>操作影响行数</returns>
        public bool DeleteEntity(IEnumerable<TEntity> entities, bool isSave = true)
        {
            var DBContext = GetDataContext();
            {
                foreach (var item in entities)
                {
                    DBContext.Set<TEntity>().Attach(item);
                    DBContext.Entry<TEntity>(item).State = EntityState.Deleted;
                }
            }

            return SaveCommit(isSave);
        }


        /// <summary>
        /// 删除所有的符合特定表达式的数据
        /// </summary>
        /// <param name="Predicate">查询条件谓语表达式</param>
        /// <param name="isSave">是否执行保存</param>
        /// <returns>操作影响行数</returns>
        public bool DeleteEntity(Expression<Func<TEntity, bool>> Predicate, bool isSave = true)
        {
            //删除实体 //查询出来一个删除
            HSJXEntities DBContext = GetDataContext();
            {

                List<TEntity> Entities = DBContext.Set<TEntity>().Where<TEntity>(Predicate).AsQueryable().ToList<TEntity>();
                foreach (var item in Entities)
                {
                    DBContext.Set<TEntity>().Attach(item);
                    DBContext.Entry<TEntity>(item).State = EntityState.Deleted;
                }
            }

            return SaveCommit(isSave);
        }

        /// <summary>
        /// 更新实体记录
        /// </summary>
        /// <param name="entity">实体记录</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>操作影响行数<</returns>
        public bool UpdateEntity(TEntity entity, bool isSave = true)
        {
            var DBContext = GetDataContext();
            {
                DBContext.Set<TEntity>().Attach(entity);
                DBContext.Entry<TEntity>(entity).State = EntityState.Modified;
                return SaveCommit(isSave);
            }


        }

        /// <summary>
        /// 查找制定主键的实体记录集合
        /// </summary>
        /// <param name="key"></param>
        /// <returns>符合条件的记录集合，不存在返回null</returns>
        public TEntity GetByKey(object key, string keyName = "ID")
        {
            List<TEntity> Entities = GetDataContext().Set<TEntity>().ToList<TEntity>();


            foreach (var item in Entities)
            {
                if (GetObjectPropertyValue(item, keyName).ToString() == key.ToString())
                {
                    return item;
                }
            }
            return null;
        }
        public object GetObjectPropertyValue(TEntity t, string propertyname)
        {
            if (t == null)
            {
                return "0";
            }
            Type type = typeof(TEntity);

            PropertyInfo property = type.GetProperty(propertyname);

            if (property == null) return string.Empty;

            object o = property.GetValue(t, null);

            if (o == null) return string.Empty;

            return o;
        }

        /// <summary>
        /// 加载所有的实体记录集合
        /// </summary>
        /// <returns></returns>
        public List<TEntity> LoadEntities()
        {

            // SWUNEEntities DBContext = GetDataContext();
            // GetDataContext().Set<TEntity>().Load();
            var DBContext = GetDataContext();
            {
                return DBContext.Set<TEntity>().ToList<TEntity>();
            }



        }

        /// <summary>
        /// 批量查找实体记录集合
        /// </summary>
        /// <param name="Predicate"></param>
        /// <returns></returns>
        public List<TEntity> LoadEntities(Expression<Func<TEntity, bool>> Predicate)
        {
            var DBContext = GetDataContext();
            {
                return DBContext.Set<TEntity>().Where<TEntity>(Predicate).AsQueryable().ToList<TEntity>();
            }
        }





        /// <summary>
        /// 查找某一个实体记录集合
        /// </summary>
        /// <param name="Predicate"></param>
        /// <returns></returns>
        public TEntity LoadEntitiy(Expression<Func<TEntity, bool>> Predicate)
        {
            var DBContext = GetDataContext();
            {
                return DBContext.Set<TEntity>().Where<TEntity>(Predicate).AsQueryable().ToList<TEntity>().FirstOrDefault();
            }

        }
        /// <summary>
        /// 利用反射自动copy属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tSource">源数据</param>
        /// <param name="tDestination">目的数据</param>
        public static void CopyObjectProperty<T>(T tSource, T tDestination) where T : class
        {
            //获得所有property的信息
            PropertyInfo[] properties = tSource.GetType().GetProperties();
            foreach (PropertyInfo p in properties)
            {
                try
                {
                    p.SetValue(tDestination, p.GetValue(tSource, null), null);//设置tDestination的属性值   
                }
                catch (Exception)
                {

                    continue;
                }

            }
        }

        public DataSet OutDSByExecuteSql(string mySql, string connStr = "")
        {
            if (string.IsNullOrEmpty(connStr))
            {
                connStr = GetDataContext().Database.Connection.ConnectionString;
            }
            SqlConnection myConn = new SqlConnection(connStr);
            SqlCommand myCmd = new SqlCommand(mySql, myConn);
            myCmd.CommandTimeout = 500000;//設置執行數據庫連接超時2分鐘
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = myCmd;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
                throw new Exception(ex.Message + mySql);
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
            return ds;
        }


        /// <summary>
        /// 执行非查询sql语句
        /// </summary>
        /// <param name="strConn">连接数据库的字符串</param>
        /// <param name="mySql">sql语句</param>
        /// <returns>返回被影响的行数 -1表示执行失败</returns>
        public int ExecuteSqlNonQuery(string mySql, string strConn = "")
        {
            if (string.IsNullOrEmpty(strConn))
            {
                strConn = GetDataContext().Database.Connection.ConnectionString;
            }
            SqlConnection myConn = new SqlConnection(strConn);
            SqlCommand myCmd = new SqlCommand(mySql, myConn);
            myCmd.CommandTimeout = 120000;
            int ret = -1;
            try
            {
                //這個人資料有問題,請聯繫管理員
                myConn.Open();
                ret = myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + mySql);
            }
            finally
            {
                myCmd.Dispose();
                myConn.Close();
            }
            return ret;
        }








    }
}
