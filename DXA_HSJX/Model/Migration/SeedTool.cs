
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// 种子数据工具
    /// </summary>
    public class SeedTool
    {
        /// <summary>
        /// 基础数据所在目录
        /// </summary>
        protected string DataDirectory { get; set; }

        /// <summary>
        /// 基础数据文件列表文件
        /// </summary>
        protected string DataOrderFile { get; set; }

        public SeedTool(string directory, string orderFile)
        {
            this.DataDirectory = directory;
            this.DataOrderFile = orderFile;
        }

        /// <summary>
        /// 导出
        /// </summary>
        //public void Export(string directory)
        //{

        //}

        /// <summary>
        /// 导入基础数据
        /// </summary>
        /// <param name="context">数据库实例</param>
        /// <param name="directory"></param>
        /// <param name="orderFile"></param>
        /// <param name="importConfig">部分导入基础数据时可选</param>
        public void Import(System.Data.Entity.DbContext context, IEnumerable<SeedImportConfig> importConfig = null)
        {
            try
            {
          

                Type t = typeof(HSJXEntities);
                PropertyInfo[] properties = t.GetProperties();
                IEnumerable<PropertyInfo> pInfos = this.GetOrderedProperties(properties, this.DataDirectory, this.DataOrderFile);

                foreach (PropertyInfo pInfo in pInfos)
                {
                    try
                    {
                        if (judgeTableImport(pInfo.Name, importConfig) == false)
                        {
                            continue;
                        }

                        object dbSet = pInfo.GetValue(context);
                        MethodInfo dbSetAddMethod = dbSet.GetType().GetMethod("Add");

                        if (pInfo.PropertyType.GenericTypeArguments.Length > 0)
                        {
                            object deserializeResult = this.Deserialize(this.DataDirectory, pInfo.PropertyType.GenericTypeArguments[0]);

                            //Log.Info(string.Format("开始导入表{0}数据", pInfo.PropertyType.GenericTypeArguments[0].Name));

                            IEnumerable list = deserializeResult as IEnumerable;
                            if (list != null)
                            {
                                foreach (object o in list)
                                {
                                    if (judgeRecordImport(pInfo.Name, o, importConfig) == false)
                                    {
                                        continue;
                                    }

                                    dbSetAddMethod.Invoke(dbSet, new object[] { o });
                                }
                            }

                           // Log.Info(string.Format("导入表{0}数据结束", pInfo.PropertyType.GenericTypeArguments[0].Name));
                        }

                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                       // Log.Info(string.Format("导入表{0}数据结束", pInfo.PropertyType.GenericTypeArguments[0].Name), e);
                    }
                }


               // Log.Info("导入数据库数据成功");
            }
            catch (Exception e)
            {
              //  Log.Info("导入数据库数据失败", e);
            }
        }

        /// <summary>
        /// 判断基础数据表是否要导入
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="importConfig">为null或长度为0时表示所有数据表都要导入</param>
        /// <returns></returns>
        private bool judgeTableImport(string tablename, IEnumerable<SeedImportConfig> importConfig)
        {
            if (importConfig == null || importConfig.Count() == 0)
            {
                return true;
            }

            return importConfig.FirstOrDefault(c => string.Equals(c.TableName, tablename, StringComparison.OrdinalIgnoreCase)) != null;
        }

        /// <summary>
        /// 判断基础数据记录是否要导入
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="importConfig">为null或长度为0时表示所有数据表都要导入</param>
        /// <returns></returns>
        private bool judgeRecordImport(string tablename, object obj, IEnumerable<SeedImportConfig> importConfig)
        {
            if (importConfig == null || importConfig.Count() == 0)
            {
                return true;
            }

            if (judgeTableImport(tablename, importConfig) == false)
            {
                return false;
            }

            IEnumerable<SeedImportConfig> tableConfig = importConfig.Where(c => string.Equals(c.TableName, tablename, StringComparison.OrdinalIgnoreCase));
            bool result = false;
            object idObj = obj.GetType().InvokeMember(importConfig.First().IdColumn, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty, null, obj, null);
            if (!(idObj is int))
            {
                return true;
            }

            int id = (int)idObj;
            foreach (SeedImportConfig config in tableConfig)
            {
                if (id >= config.MinId && id <= config.MaxId)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 部分导入基础数据
        /// </summary>
        /// <param name="context"></param>
        /// <param name="directory"></param>
        /// <param name="orderFile"></param>
        /// <param name="importConfig"></param>
        //public void Import(System.Data.Entity.DbContext context, string directory, string orderFile, IEnumerable<SeedImportConfig> importConfig) { 

        //}
        /// <summary>
        /// 反序列化基础数据
        /// </summary>
        /// <param name="t"></param>
        private object Deserialize(string directory, Type t)
        {
            Type listType = typeof(List<>);
            //获取json序列化为对象集合
            Type tempListType = listType.MakeGenericType(new Type[] { t });

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            
            serializer.MaxJsonLength = int.MaxValue;
            string path = System.IO.Path.Combine(directory, t.Name + ".json");
            if (File.Exists(path))
            {
                var stream = System.IO.File.Open(path, FileMode.Open);

                StreamReader reader = new StreamReader(stream);
                string strTemp = reader.ReadToEnd();

                var result = serializer.Deserialize(strTemp, tempListType);
                reader.Close();
                stream.Close();

                return result;
            }

            return null;
        }

        /// <summary>
        /// 根据orderFiles顺序返回导入顺序
        /// </summary>
        /// <param name="pinfos"></param>
        /// <param name="directory"></param>
        /// <param name="orderFile"></param>
        /// <returns></returns>
        private IEnumerable<PropertyInfo> GetOrderedProperties(PropertyInfo[] pinfos, string directory, string orderFile)
        {
            string path = System.IO.Path.Combine(directory, orderFile);
            List<string> orders = new List<string>();
            List<PropertyInfo> orderProperties = new List<PropertyInfo>();
            if (File.Exists(path))
            {
                var stream = System.IO.File.Open(path, FileMode.Open);

                StreamReader reader = new StreamReader(stream);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        orders.Add(line);
                    }
                }

                foreach (string order in orders)
                {
                    PropertyInfo tempProperty = pinfos.FirstOrDefault(
                        r =>
                        {
                            if (r.PropertyType.GenericTypeArguments.Length > 0)
                                return string.Compare(order, r.PropertyType.GenericTypeArguments[0].Name) == 0;
                            else
                                return false;
                        });

                    if (tempProperty != null)
                    {
                        orderProperties.Add(tempProperty);
                    }
                }

                return orderProperties;
            }

            return pinfos;
        }
    }

    /// <summary>
    /// 部分基础数据导入配置
    /// </summary>
    public class SeedImportConfig
    {
        public SeedImportConfig()
        {
            MinId = 0;
            MaxId = int.MaxValue;
        }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// ID列名
        /// </summary>
        public string IdColumn { get; set; }

        /// <summary>
        /// 设置或获取导入范围最小ID,大于等于此值被导入，默认为0
        /// </summary>
        public int MinId { get; set; }

        /// <summary>
        /// 设置或获取导入范围最大ID,小于等于此值被导入，默认为int.maxvalue
        /// </summary>
        public int MaxId { get; set; }
    }
}
