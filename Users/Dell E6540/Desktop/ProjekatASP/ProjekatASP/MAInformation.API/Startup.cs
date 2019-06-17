using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAInformation.Application.Commands;
using MAInformation.DataAccess;
using MAInformation.EfCommands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace MAInformation.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<MAInformationContext>();
            services.AddTransient<IAddActorCommand, EfAddActorCommand>();
            services.AddTransient<IDeleteActorCommand, EfDeleteActorCommand>();
            services.AddTransient<IUpdateActorCommand, EfUpdateActorCommand>();
            services.AddTransient<IGetActors, EfGetActorCommand>();
            services.AddTransient<IAddDirectorCommand, EfAddDirectorCommand>();
            services.AddTransient<IDeleteDirectorCommand, EfDeleteDirectorCommand>();
            services.AddTransient<IUpdateDirectorCommand, EfUpdateDirectorCommand>();
            services.AddTransient<IGetDirectorCommand, EfGetDirectorCommand>();
            services.AddTransient<IAddMovieCommand, EfCreateMovieCommand>();
            services.AddTransient<IDeleteMovieCommand, EfDeleteMovieCommand>();
            services.AddTransient<IUpdateMovieCommand, EfUpdateMovieCommand>();
            services.AddTransient<IGetMovieCommand, EfGetMovieCommand>();
            services.AddTransient<IAddGenreCommand, EfAddGenreCommand>();
            services.AddTransient<IDeleteGenreCommand, EfDeleteGenreCommand>();
            services.AddTransient<IUpdateGenreCommand , EfUpdateGenreCommand>();
            services.AddTransient<IGetGenreCommand, EfGetGenreCommand>();
            services.AddTransient<IMovieActorRelationCommand, EfAddMovieActorRelationCommand>();
            services.AddTransient<IDeleteMovieActorRelationCommand, EfDeleteMovieActorRelationCommand>();
            services.AddTransient<IAddMovieGanreRelationCommand, EfCreateGanreMovieRelationCommand>();
            services.AddTransient<IDeleteMovieGenreRelationCommand, EfDeleteGenreMovieRelationCommand>();

            services.AddTransient<IAddLanguageCommand, EfAddLanguageCommand>();
            services.AddTransient<IGetLanguages, EfGetLanguagesCommand>();
            services.AddTransient<IDeleteLanguageCommand, EfDeleteLanguageCommand>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }





            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });

        }
    }
}
