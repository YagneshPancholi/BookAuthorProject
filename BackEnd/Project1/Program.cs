using Application.Repository;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Services.AuthorService;
using Project1.Services.BookService;
using Project1.Services.GenreService;
using Project1.Services.PublisherService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Project1DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Project2") ?? throw new InvalidOperationException("Connection String 'Project2' Not Found"))
);
builder.Services.AddCors(p => p.AddPolicy("corspolicy", builder =>
{
    //http://localhost:4200
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorRepository, AuthorService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
//builder.Services.AddSingleton<IBookService, BookService>();
//builder.Services.AddTransient<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corspolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();