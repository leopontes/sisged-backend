using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SisGed_Backend.Business;
using SisGed_Backend.Models;
using SisGed_Backend.Repository;
using SisGed_Backend.Validators;

namespace SisGed_Backend
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

           
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });

            var _sessionFactory = NHibernateHelper.OpenSession();

            services.AddScoped<ITurmaBusiness, TurmaBusiness>();

            services.AddScoped<ICrudOperation<Aluno>, Persistence<Aluno>>(persistence => new Persistence<Aluno>(_sessionFactory));
            services.AddScoped<ICrudOperation<Escola>, Persistence<Escola>>(persistence => new Persistence<Escola>(_sessionFactory));
            services.AddScoped<ICrudOperation<Turma>, Persistence<Turma>>(persistence => new Persistence<Turma>(_sessionFactory));

            services.AddTransient<IValidator<Turma>, TurmaValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("EnableCORS");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
