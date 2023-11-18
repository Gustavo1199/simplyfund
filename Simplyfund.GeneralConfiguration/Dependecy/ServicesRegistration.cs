using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.ServicesInterface.IBaseServices;
using Simplyfund.Dal.Data.BaseData;
using Simplyfund.Dal.DataBase;
using Simplyfund.Dal.DataBase.IBaseData;
using Simplyfund.GeneralConfiguration.AutoMaper;

namespace Simplyfund.GeneralConfiguration.Dependecy
{
    public static class ServicesRegistration
    {
        public static void AddRegister(this IServiceCollection services, IConfiguration configuration)
        {

            #region automapper

            services.AddAutoMapper(typeof(AutoMapperProfile));

            #endregion

            #region context

            services.AddDbContext<SimplyfundContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #endregion

            //Dependecy Inyeccion
   
            services.AddScoped(typeof(IBaseServices<>), typeof(BaseService<>));

            services.AddScoped(typeof(IBaseDatas<>), typeof(BaseDatas<>));


            //services.AddScoped(typeof(IBaseServices<>));
            //services.AddScoped(typeof(IBaseData<>));
            //services.AddScoped(typeof(BaseData<>));








        }

    }
}
