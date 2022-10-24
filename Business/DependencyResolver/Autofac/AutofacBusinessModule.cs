using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<CommentManager>().As<ICommentServcie>();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>();

            builder.RegisterType<QuestionManager>().As<IQuestionService>();
            builder.RegisterType<EfQuestionDal>().As<IQuestionDal>();

            builder.RegisterType<QuestionImageManager>().As<IQuestionImageSevice>().SingleInstance();
            builder.RegisterType<EfQuestıonImageDal>().As<IQuestionImageDal>();
            builder.RegisterType<FileHelperManager>().As<IFileHelper>();





            var assembly=System.Reflection.Assembly.GetExecutingAssembly(); 


            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
              .EnableInterfaceInterceptors(new ProxyGenerationOptions()
              {
                  Selector = new AspectInterceptorSelector()
              }).SingleInstance();
        }
    }
}
