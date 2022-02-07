using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Produtos.Domain.Interfaces;
using Produtos.Infra.Contexto;
using Produtos.Infra.Repositorios;
using AutoMapper;
using Produtos.Domain.Servicos;

namespace Produtos.WebApi
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


            //Configurando conex�o com o banco de dados
            services.AddDbContext<DbContexto>(opcoes => opcoes.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Produtos.WebApi")));

            //Configurando AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //Adicionar os repositorios ao escopo da aplica��o: realizando a inje��o de depend�ncias
            services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<IFornecedorServico, FornecedorServico>();

            services.AddControllers().AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
         
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Produtos.WebApi", Version = "v1" });
            });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(a => a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Produtos.WebApi v1"));
            }




            app.UseRouting();
            app.UseAuthorization();
            //   app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
