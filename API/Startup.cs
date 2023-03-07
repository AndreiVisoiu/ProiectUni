using API.Processors;
using API.Services;
using API.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; 
        }
        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSwaggerGen();

            services.Configure<DatabaseSettings>(Configuration.GetSection("Database"));
            services.AddSingleton(s => s.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddTransient<IRocketProcessor, RocketProcessor>();
            services.AddTransient<IRocketService, RocketService>();
        }


        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RocketAPI");
            });
            app.UseCors();
            app.UseAuthentication();
            app.UseMvc();
        }

    }
}
