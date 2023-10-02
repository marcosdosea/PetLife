using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace PetLifeWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<IConsultumService, ConsultumService>();
            builder.Services.AddTransient<IMedicamentoService, MedicamentoService>();
            builder.Services.AddTransient<IPessoaService, PessoaService>();
            builder.Services.AddTransient<IPetService, PetService>();
            builder.Services.AddTransient<IVacinaService, VacinaService>();
            builder.Services.AddTransient<IVendumService, VendumService>();
            builder.Services.AddTransient<IPetshopService, PetshopService>();
            builder.Services.AddTransient<IProdutoService, ProdutoService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<PetLifeContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("PetLifeDatabase")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

}

