using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SignalRServer.Hubs;
using SignalRServer.Models;
using SignalRServer.Models.DB;

namespace SignalRServer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;

		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
            services.AddDbContext<ToDoDbContext>(options =>
				options.UseSqlite(
                    ConfigurationDB.ConnectionString,
					opts =>
					{
						opts.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName); 
					}));

			services.AddTransient<ToDoDbRepository>();
			
			services.AddTransient<RepositoryGeneric<Employee>>();
			services.AddScoped<RepositoryGeneric<RoleEmployee>>();
			services.AddScoped<RepositoryGeneric<TaskEmployee>>();

			services.AddScoped<IToDoDbContext>(provider => provider.GetService<ToDoDbContext>());
            services.AddScoped<IDapperWriteDbConnection, DapperWriteDbConnection>();
            services.AddScoped<IDapperReadDbConnection, DapperReadDbConnection>();

			ConfigureServicesMapping.ConfigureServices(services);

			services.AddCors();

			services.AddSignalR();
			services.AddSingleton<ManagerHub>();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("signalR_v1", new OpenApiInfo
                {
                    Title = "SignalRApp",
                    Version = "Ver. 1.0",
                    Description = "REST API ToDo"
                });
                
                c.CustomSchemaIds(x => x.FullName);

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                if (!File.Exists(xmlPath))
                    Console.WriteLine($"File {xmlPath} not found");
                
                c.IncludeXmlComments(xmlPath);
            });
			//services.AddSwaggerGenNewtonsoftSupport();

			services.AddControllersWithViews();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseCors(builder => builder
				.WithOrigins("null")
				.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowCredentials());

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseSwagger();

			// url: swagger/index
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/signalR_v1/swagger.json", "SignalRApp");
				c.RoutePrefix = "swagger";
			});

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapDefaultControllerRoute();

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");

				endpoints.MapHub<NotificationHub>("/notification");

				endpoints.MapControllerRoute(name: "blog",
					pattern: "api/{controller}/{action}/{id?}",
					defaults: new { controller = "ToDo", action = "GetString" });
			});


		}
	}
}
