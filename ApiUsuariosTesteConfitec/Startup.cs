using ApiUsuariosTesteConfitec.Configuration;
using ApiUsuariosTesteConfitec_Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace ApiUsuariosTesteConfitec
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string MyAllowSpecificOrigins = "mycors";

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddIoCServices();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiUsuariosTesteConfitec", Version = "v1" });
            });

            services.AddDbContext<UsuariosContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlServerDbConnection"), b => b.MigrationsAssembly("ApiUsuariosTesteConfitec")));

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("https://frontend-usuarios-teste-confitec-1nhyv49s0-leoasprinorocha.vercel.app/");
                                  });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(MyAllowSpecificOrigins);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiUsuariosTesteConfitec v1"));
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
