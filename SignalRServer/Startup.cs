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
					//Configuration["Data:ConnectionString"],
                    ConfigurationDB.ConnectionString,
					opts =>
					{
						opts.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName); 

					}));

			//services.AddTransient<Repository_<Employee>>();
			//services.AddScoped<Repository_<RoleEmployee>>();
			//services.AddScoped<Repository_<TaskEmployee>>();

			services.AddScoped<IToDoDbContext>(provider => provider.GetService<ToDoDbContext>());
            services.AddScoped<IDapperWriteDbConnection, DapperWriteDbConnection>();
            services.AddScoped<IDapperReadDbConnection, DapperReadDbConnection>();
			//services.AddControllers();

			//services.AddTransient<IRepository, ToDoDbRepository>();

            services.AddTransient<ToDoDbRepository>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
			
			services.AddSingleton<ManagerHub>();
			


			services.AddCors();
			services.AddSignalR();
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapDefaultControllerRoute();

				//endpoints.MapControllerRoute(
				//	name: "default",
				//	pattern: "{controller=Home}/{action=Index}/{id?}");

				endpoints.MapHub<NotificationHub>("/notification");

				endpoints.MapControllerRoute(name: "blog",
					pattern: "api/{controller}/{action}/{id?}",
					defaults: new { controller = "ToDo", action = "GetString" });
			});
		}
	}
}
