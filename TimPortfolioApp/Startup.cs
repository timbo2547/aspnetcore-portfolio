using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TimPortfolioApp.Models;
using TimPortfolioApp.Repository;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using TimPortfolioApp.Utilities;

namespace TimPortfolioApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Enable runtime compilation
            // https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-compilation?view=aspnetcore-3.1&tabs=visual-studio

            //Add PostgreSQL support
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<PostgresDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddAutoMapper(typeof(Startup));
            services.AddMvc();
            
            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<PostgresDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();
            
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies(o => { });

            // https://stackoverflow.com/questions/59199593/net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // Add our PostgreSQL Repositories (scoped to each request)
            services.AddScoped<ISampleItemRepository, SampleItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //Transient: Created each time they're needed
            services.AddTransient<SampleItemDbSeeder>();
            services.AddTransient<DatabaseMigrate>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Application API",
                    Description = "Application Documentation",
                    Contact = new OpenApiContact { Name = "TL" },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://en.wikipedia.org/wiki/MIT_License") }
                });

                // Add XML comment document by uncommenting the following
                // var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "MyApi.xml");
                // options.IncludeXmlComments(filePath);
            });

            // TODO: Review this
            services.AddCors(o => o.AddPolicy("AllowAllPolicy", options =>
            {
                options.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "dist";
            });

            //services.AddMvc(options =>
            //{
            //    options.SuppressAsyncSuffixInActionNames = false;
            //});

            // TODO: Research this, do not uncomment
            // services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SampleItemDbSeeder sampleItemDbSeeder, DatabaseMigrate dbMigrate) 
            // TODO: Add seed parameters: DockerCommandsDbSeeder dockerCommandsDbSeeder, CustomersDbSeeder customersDbSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // TODO: Review this
            app.UseCors("AllowAllPolicy");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // TODO: What is this?
            app.UseSpaStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            // Visit http://localhost:5000/swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // TODO: What is this?
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // TODO: WHAT IS THIS? Handle redirecting client-side routes to Customers/Index route
                //endpoints.MapFallbackToController("Index", "Customers");
            });

            // Use seeding for early development, drop database before 
            //sampleItemDbSeeder.SeedAsync(app.ApplicationServices).Wait();
            
            // Use migrations for production
            dbMigrate.ApplyMigrationsAsync(app.ApplicationServices).Wait();
        }
    }
}
