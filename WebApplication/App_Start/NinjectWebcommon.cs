[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApplication.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApplication.App_Start.NinjectWebCommon), "Stop")]

namespace WebApplication.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using WebApplication.Abstract;
    using WebApplication.concrete;
    using WebApplication.Models;
    using Moq;
    using System.Collections.Generic;
    using Ninject.Web.Common.WebHost;
  

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            Grade d1 = new Grade { Id = 1, Name = "PGD Student" };
            Grade d2 = new Grade { Id = 2, Name = "Undergraduate Student" };

            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            mock.Setup(m => m.GetUsers()).Returns(new List<User>
            {
                 new User{ Name = "Chuks", MatricNo = "01", Id = 1, Grade = d1 },
                 new User {Name = "Emmanuel", MatricNo = "02", Id = 2, Grade = d2 },
                 new User { Name = "Muna", MatricNo = "03", Id = 3, Grade = d1 },
                 new User{ Name = "Winnie", MatricNo = "04", Id = 4, Grade = d2 },
                 new User { Name = "Lola", MatricNo = "05", Id = 5, Grade = d1 }

            });
            kernel.Bind<IUserRepository>().ToConstant(mock.Object);

           // kernel.Bind<IUserRepository>().To<UserRepository>();
        }
    }
}
