using IdentityEF_DependencyInjection.Business.Abstract;
using IdentityEF_DependencyInjection.Business.Concrete;
using IdentityEF_DependencyInjection.DataAccess.Abstract;
using IdentityEF_DependencyInjection.DataAccess.Concrete.EntityFramework;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace IdentityEF_DependencyInjection.Business.Constant.DependencyInjection.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel(new NinjectBindingModule());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }
        public class NinjectBindingModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind<IAuthDal>().To<AuthDal>();
                Kernel.Bind<IAuthService>().To<AuthManager>();               
            }
        }
    }
}
