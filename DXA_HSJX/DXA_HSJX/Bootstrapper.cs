using DContainer;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using System.Data.Entity;
using Model;
using Service;

namespace DXA_HSJX
{
    public class Bootstrapper
    {
        public virtual void Initialize()
        {


            InitializeServices(Locator.Register);

            ///进行日志配置设置

        }


        public virtual void InitializeServices(IServiceRegister register)
        {
            register
                .RegisterInstance(Messenger.Default)
                .RegisterType<IEFRepository<ExamCar>, EFRepositoryBase<ExamCar>>(LifetimeScope.Singleton)
                .RegisterType<IEFRepository<ExamStudent>, EFRepositoryBase<ExamStudent>>(LifetimeScope.Singleton)
                .RegisterType<IEFRepository<User>, EFRepositoryBase<User>>(LifetimeScope.Singleton)
                .RegisterType<ILoginService, LoginService>(LifetimeScope.Singleton)
                .RegisterType<IEFRepository<ExamRecord>, EFRepositoryBase<ExamRecord>>(LifetimeScope.Singleton)
                .RegisterType<IEFRepository<ExamBreakeRuleRecord>, EFRepositoryBase<ExamBreakeRuleRecord>>(LifetimeScope.Singleton)
                .RegisterType<IEFRepository<ExamItem>, EFRepositoryBase<ExamItem>>(LifetimeScope.Singleton)
                .RegisterType<IEFRepository<ProjectThrough>, EFRepositoryBase<ProjectThrough>>(LifetimeScope.Singleton)
                .RegisterType<IEFRepository<ExamCapture>, EFRepositoryBase<ExamCapture>>(LifetimeScope.Singleton)
                .RegisterType<IEFRepository<DeductionRule>, EFRepositoryBase<DeductionRule>>(LifetimeScope.Singleton)
                .RegisterType<HSJXEntities, HSJXEntities>(LifetimeScope.Singleton)
                .RegisterType<IExamService, ExamService>(LifetimeScope.Singleton);


        }
    }
}
