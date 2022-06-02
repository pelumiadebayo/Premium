using IntranetApi;
using IntranetApi.BusinessCore.Interfaces;
using IntranetApi.BusinessCore.Services;
using IntranetApi.BusinessCore.Services.Requisitions;
using IntranetApi.Repository;
using IntranetApi.Repository.Interfaces;
using IntranetApi.Repository.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("mysqlconnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryContext>(opts => opts.UseMySql(connection, ServerVersion.AutoDetect(connection), b=>b.MigrationsAssembly("IntranetApi")));
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IWrapper, Wrapper>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<ICheckBookRequest, CheckBookRequest>();


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

