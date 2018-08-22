using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Data;

namespace Model
{
    /// <summary>
    /// EntityFramework仓储操基类的接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEFRepository<TEntity>
    {

        /// <summary>
        /// 插入实体对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isSave">是否执行保存</param>
        /// <returns>操作影响行数</returns>
        bool AddEntity(TEntity entity, bool isSave = true);

        /// <summary>
        /// 插入实体记录集合
        /// </summary>
        /// <param name="entities">实体记录集合</param>
        /// <param name="isSave">是否知悉保存</param>
        /// <returns>操作影响行数</returns>
        bool AddEntity(IEnumerable<TEntity> entities, bool isSave = true);

        /// <summary>
        /// 插入实体记录集合通过SqlBluck方式，不适合有主外键关系的 Table
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
         bool AddEntityByBluk(IEnumerable<TEntity> entities, bool isSave = true);


        /// <summary>
        /// 删除实体记录集合
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>操作影响行数</returns>
        bool DeleteEntity(TEntity entity, bool isSave = true);

        /// <summary>
        /// 删除实体记录集合
        /// </summary>
        /// <param name="Key">实体记录Key</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>操作影响行数</returns>
        bool DeleteEntity(object Key,string keyName="ID", bool isSave = true);

        /// <summary>
        /// 删除实体集合
        /// </summary>
        /// <param name="entities">实体对象</param>
        /// <param name="isSave">是否执行保存</param>
        /// <returns>操作影响行数</returns>
        bool DeleteEntity(IEnumerable<TEntity> entities, bool isSave = true);


        /// <summary>
        /// 删除所有的符合特定表达式的数据
        /// </summary>
        /// <param name="Predicate">查询条件谓语表达式</param>
        /// <param name="isSave">是否执行保存</param>
        /// <returns>操作影响行数</returns>
        bool DeleteEntity(Expression<Func<TEntity, bool>> Predicate, bool isSave = true);

        /// <summary>
        /// 更新实体记录
        /// </summary>
        /// <param name="entity">实体记录</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>操作影响行数<</returns>
        bool UpdateEntity(TEntity entity, bool isSave = true);

        /// <summary>
        /// 查找制定主键的实体记录集合
        /// </summary>
        /// <param name="key"></param>
        /// <returns>符合条件的记录集合，不存在返回null</returns>
        TEntity GetByKey(object key,string KeyName="ID");
        /// <summary>
        /// 批量单个实体记录集合
        /// </summary>
        /// <param name="Predicate"></param>
        /// <returns></returns>
        TEntity LoadEntitiy(Expression<Func<TEntity, bool>> Predicate);
        /// <summary>
        /// 批量查找实体记录集合
        /// </summary>
        /// <param name="Predicate"></param>
        /// <returns></returns>
        List<TEntity> LoadEntities(Expression<Func<TEntity, bool>> Predicate);
        /// <summary>
        /// 加载所有的实体记录集合
        /// </summary>
        /// <returns></returns>
        List<TEntity> LoadEntities();

        //bool ExcuteSql(string sql, params ObjectParameter[] parameters);

       DataSet OutDSByExecuteSql(string mySql, string connStr = "");
        int ExecuteSqlNonQuery(string mySql, string strConn = "");

    }
}
