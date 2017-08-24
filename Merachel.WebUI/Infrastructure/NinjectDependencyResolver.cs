using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq;
using Ninject;
using System.Web.Mvc;
using Merachel.Domain.Abstract;
using Merachel.Domain.Concrete;
using Merachel.Domain.Entities;

namespace Merachel.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IBlogCategoryRepository>().To<EFBlogCategoryRepository>();
            kernel.Bind<IBlogRepository>().To<EFBlogRepository>();
            kernel.Bind<ICollectionRepository>().To<EFCollectionRepository>();
            kernel.Bind<IColletionPictureRepository>().To<EFCollectionPictureRepository>();
            kernel.Bind<ICourseCategoryRepository>().To<EFCourseCategoryRepository>();
            kernel.Bind<ICoursePriceRepository>().To<EFCoursePriceRepository>();
            kernel.Bind<ICourseRepository>().To<EFCourseRepository>();
            kernel.Bind<IEventRepository>().To<EFEventRepository>();
            kernel.Bind<IEventPriceRepository>().To<EFEventPriceRepository>();
            kernel.Bind<IEventPictureRepository>().To<EFEventPictureRepository>();
            kernel.Bind<IUserRepository>().To<EFUserRepository>();
            kernel.Bind<ITestimonialRepository>().To<EFTestimonialRepository>();
            kernel.Bind<IEmployeeRepository>().To<EFEmployeeRepository>();
            kernel.Bind<ILookupRepository>().To<EFLookupRepository>();
        }
    }
}