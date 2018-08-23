using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public  class Initializer : CreateDatabaseIfNotExists<HSJXEntities>
    {
        protected override void Seed(HSJXEntities context)
        {
            string directory = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "InitData");
            var SeedTool = new SeedTool(directory, "orders.txt");
            SeedTool.Import(context);

            //到时候执行Sql更新
            //EFRepositoryBase<User> repositoryBase = new EFRepositoryBase<User>();
            //repositoryBase.ExecuteSqlNonQuery("",context.c)
                

            //EFRepositoryBase<ExamCar> eFRepositoryBase = new EFRepositoryBase<ExamCar>();
            //var entity= eFRepositoryBase.LoadEntitiy(s => s.Id == 1);
            //entity.ExamStudentId = 1;
            //eFRepositoryBase.UpdateEntity(entity);

            //EFRepositoryBase<ExamStudent> studentRepositoryBase = new EFRepositoryBase<ExamStudent>();

            //var students = studentRepositoryBase.LoadEntities();
            //foreach (var item in students)
            //{
            //    item.CreateTime = DateTime.Now;
            //    studentRepositoryBase.UpdateEntity(item);
            //}
        }
    }
}
