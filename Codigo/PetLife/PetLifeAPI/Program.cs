using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace PetLifeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
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
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}