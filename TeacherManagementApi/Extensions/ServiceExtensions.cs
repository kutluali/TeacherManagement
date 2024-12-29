
using TeacherManagement.Business.Abstract;
using TeacherManagement.Business.Concrete;
using TeacherManagement.DataAccess.Abstract;
using TeacherManagement.DataAccess.Concreate;
using TeacherManagement.DataAccess.Respository;

namespace TeacherManagementApi.Extensions
{
	public static class ServiceExtensions
	{
		public static void AddServiceExtensions(this IServiceCollection services)
		{
			services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<ILessonDal, EfLessonDal>();
			services.AddScoped<ILessonService, LessonManager>();

			services.AddScoped<ITeacherDal, EfTeacherDal>();
			services.AddScoped<ITeacherService, TeacherManager>();

            services.AddScoped<IRefreshTokenDal, EfRefreshTokenDal>();
            services.AddScoped<IRefreshTokenService, RefreshTokenManager>();
        }

	}
}
