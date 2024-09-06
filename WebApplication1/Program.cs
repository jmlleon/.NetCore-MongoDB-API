

using Application_Layer.Services;
using Domain_Layer.Interfaces.Repositories;
using Domain_Layer.Interfaces.Services;
using Domain_Layer.Model;
using Infraestructure_Layer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.Configure<SchoolDBSettings>(builder.Configuration.GetSection("SchoolDBSettings"));

#region Infraestructure_Layer


builder.Services.AddScoped<IStudentRepository, StudentRepository>();


#endregion

#region Application_Layer

builder.Services.AddScoped<IStudentService,StudentService>();

#endregion

#region CORS

//var origins = Configuration["CORS:Origins"].Split(";");


builder.Services.AddCors(c =>
{
    c.AddPolicy("CorsAllowAll", options =>
    {
        options
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });

   /* c.AddPolicy("CorsAllowSpecific", options =>
    {
        options
        .WithOrigins(origins)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        ;
    });*/
});

#endregion CORS



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.UseSwagger();
    //app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("CorsAllowAll");

//app.UseRouting();   

app.UseAuthorization();

app.MapControllers();

app.Run();
