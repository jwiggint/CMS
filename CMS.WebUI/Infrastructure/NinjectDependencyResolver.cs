﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using System.Configuration;
using CMS.Domain.Models;
using CMS.Domain.Abstract;

namespace CMS.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
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
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IEventRepository>().To<EventRepository>();
            kernel.Bind<IFAQRepository>().To<FAQRepository>();
            kernel.Bind<IGalleryRepository>().To<GalleryRepository>();
            kernel.Bind<IImageRepository>().To<ImageRepository>();
            kernel.Bind<IFolderRepository>().To<FolderRepository>();
            kernel.Bind<IDocumentRepository>().To <DocumentRepository>();
            kernel.Bind<IPageRepository>().To<PageRepository>();
        }
    }
}