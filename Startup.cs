using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kodigos.api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


/*
    Executado quando a aplicação for iniciada, define comportamtendos geras da aplicação;
    
*/
namespace kodigos.api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        /*
            RESPONSAVEL POR ADICIONAR SERVIÇOS QUE SERÃO USADO POR OUTROS COMPONENTES DA APLICAÇÃO
        */
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //Quando alguem pedir a interface instancie a classe;
            services.AddSingleton<IProdutoRepository, ProdutoRepository>();

            services.AddSingleton<IEstoqueRepository, EstoqueRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        // RESPONSAVEL PPR DEFINIR ASPECTO A RESPEITO DOS RETORNO CHAMADAS HTTP;
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

    //Politicas de acesso de requisição
            app.UseCors(config => {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });

            app.UseMvc();
        }
    }
}
