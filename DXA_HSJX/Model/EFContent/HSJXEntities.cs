using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HSJXEntities: System.Data.Entity.DbContext
    {
        public static readonly string ConnectionName = "HSJXEntities";

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new Initializer());

            base.OnModelCreating(modelBuilder);

      

        }

        public HSJXEntities()
            : base(ConnectionName)
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.LazyLoadingEnabled = true; //关闭延迟加载
            Database.Initialize(true);
        }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<LoginLog> LoginLog { get; set; }

        public virtual DbSet<ExamCar> ExamCar { get; set; }

        public virtual DbSet<ExamStudent> ExamStudent { get; set; }

        public virtual DbSet<ExamBreakeRuleRecord> ExamBreakeRuleRecord { get; set; }

        public virtual DbSet<ExamCapture> ExamCapture { get; set; }

        public virtual DbSet<ExamRecord> ExamRecord { get; set; }

        public virtual DbSet<ExamItem> ExamItem { get; set; }


        public virtual DbSet<DeductionRule> DeductionRule { get; set; }

        public virtual DbSet<ProjectThrough> ProjectThrough { get; set; }



    }
}
