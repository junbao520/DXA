using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    [Flags]
    public enum DataMigrationResult
    {
        Unknown = 0,
        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,
        /// <summary>
        /// 失败
        /// </summary>
        Failure = 2,
        /// <summary>
        /// 阻断后续执行
        /// </summary>
        Break = 4,
    }

    /// <summary>
    /// 数据库迁移、创建时的数据处理接口
    /// </summary>
    public interface IDataMigration
    {
        /// <summary>
        /// 数据处理,异常必须在内部进行处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        DataMigrationResult DataHandle(HSJXEntities context);

        /// <summary>
        /// 数据迁移适用的时间，以此进行顺序执行
        /// </summary>
        DateTime MigrationTime { get; }
    }

    /// <summary>
    /// 数据迁移时的数据升级基础类
    /// </summary>
    public abstract class DataMigration : IDataMigration
    {
        /// <summary>
        /// 数据处理,异常必须在内部进行处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract DataMigrationResult DataHandle(HSJXEntities context);

        /// <summary>
        /// 数据迁移适用的时间，以此进行顺序执行
        /// </summary>
        public abstract DateTime MigrationTime { get; }

        protected static SeedTool SeedTool { get; set; }

        static DataMigration()
        {
            string directory = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "InitData");
            SeedTool = new SeedTool(directory, "orders.txt");
        }
    }
}
