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

            //Klas�r� d��ar� a�mak i�in
            app.UseStaticFiles(); //wwwroot klas�r� d��ar�ya a��l�r
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "node_modules")), RequestPath = "/modules"
            });


            //burada sayfa y�nlendirmesi yap�yoruz

            
            //burda iste�e ba�l� olarak controllerlara s�rayla bak�l�r 
            //e�er istenilen controller yoksa en sonda varsay�lan controller uygulan�r.
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    // action = controller i�indeki her bir metoda veri�imiz isim
                    // id? = Soru i�areti iste�e ba�l� olarak kullan�laca��n� belirtir. 
                    pattern: "{controller=Home}/{action=Index}/{id?}"); 
                
                //url yolu course released year ve ay �eklinde olmas� laz�m year ve month da ? olsayd�
                // year ve month alanlar�n� doldurmaya gerek kalmayacakt�.
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
