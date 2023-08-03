using EmploymentManagement.api.Repositories.Implementations;
using EmploymentManagement.api.Repositories.Interfaces;
using EmploymentManagement.api.sub_folders.Context_folder;
using Microsoft.EntityFrameworkCore;

namespace EmploymentManagement.api.sub_folders.Extension_folder
{
    public static class ConfigureServices
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("conn")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
