using CodeWave_AMI.Service.Implementations;
using CodeWave_AMI.Service;
using CodeWave_AMI.Repository.Implementations;
using CodeWave_AMI.Repository;

namespace CodeWave_AMI.web
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration) {

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            return services;
        }
    }
}
