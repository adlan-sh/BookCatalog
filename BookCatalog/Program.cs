
using BookCatalog.Application.UseCase;
using BookCatalog.Application.UseCase.Interface;
using BookCatalog.Domain.Repository;
using BookCatalog.Domain.Service;
using BookCatalog.Infrastructure;
using BookCatalog.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

            // Add services to the container.
            // Repository

            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

            // Service

            builder.Services.AddScoped<BookService>();
            builder.Services.AddScoped<AuthorService>();

            // Interactor

            builder.Services.AddScoped<IBookUseCaseInteractor, BookUseCaseInteractor>();
            builder.Services.AddScoped<IAuthorUseCaseInteractor, AuthorUseCaseInteractor>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
