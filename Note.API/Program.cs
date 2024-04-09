using Microsoft.EntityFrameworkCore;
using Note.API.Core.Automapper;
using Note.API.Core.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=Notes.db")) ;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(typeof(AutomapperConfigProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>{

 option.AddPolicy(name:"CorsPolicy", configurePolicy:policyBuilder =>{

    policyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:8081");
 });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
