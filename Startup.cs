using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using HobbyApp.Controllers.Books;
using HobbyApp.Infrastructure;
using HobbyApp.Infrastructure.Shared;
using HobbyApp.Mappers;
using HobbyApp.Services.Books;

namespace HobbyApp {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<HobbyDatabaseSettings>(
                Configuration.GetSection(nameof(HobbyDatabaseSettings)));

            services.AddSingleton<IHobbyDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<HobbyDatabaseSettings>>().Value);

            ConfigureMyServices(services);

            services.AddControllers().AddNewtonsoftJson();

            // CORS -------------------------------------------------------
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyOrigin(); // For anyone access.
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyHeader();

            services.AddCors(options => {
                options.AddPolicy(name: "CORSPolicy", corsBuilder.Build());
            });
            // ------------------------------------------------------------

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HobbyApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HobbyApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // CORS:
            app.UseCors("CORSPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }

        public void ConfigureMyServices(IServiceCollection services) {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookMap, BookMap>();
            services.AddTransient<IBookService, BookService>();
        }
    }
}