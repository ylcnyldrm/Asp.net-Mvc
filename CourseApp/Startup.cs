using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace CourseApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //Klasörü dýþarý açmak için
            app.UseStaticFiles(); //wwwroot klasörü dýþarýya açýlýr
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "node_modules")), RequestPath = "/modules"
            });


            //burada sayfa yönlendirmesi yapýyoruz

            
            //burda isteðe baðlý olarak controllerlara sýrayla bakýlýr 
            //eðer istenilen controller yoksa en sonda varsayýlan controller uygulanýr.
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    // action = controller içindeki her bir metoda veriðimiz isim
                    // id? = Soru iþareti isteðe baðlý olarak kullanýlacaðýný belirtir. 
                    pattern: "{controller=Home}/{action=Index}/{id?}"); 
                
                //url yolu course released year ve ay þeklinde olmasý lazým year ve month da ? olsaydý
                // year ve month alanlarýný doldurmaya gerek kalmayacaktý.
                endpoints.MapControllerRoute( 
                    name: "CoursesByReleased",  
                    pattern: "course/released/{year?}/{month?}",
                    new { controller ="Course",action="Byreleased"},
                    new { year=@"\d{4}",month=@"\d{2}"}
                    );
                   
            });
        }
    }
}
