using Microsoft.Extensions.DependencyInjection.Extensions;
using SOAPPractise.Model;
using SOAPPractise;
using SoapCore;
using System.ServiceModel;
using SoapCoreServer;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using SOAPPractise.Mappings;
using REST_Practise.Data;
using Microsoft.EntityFrameworkCore;
using SOAPPractise.Model.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();
// Add services to the container.
//-------------------------------------------------------------------------------------------------------
//builder.Services.TryAddSingleton<ISampleService, SampleService>();
//-------------------------------------------------------------------------------------------------------
// add automapper service
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
//-------------------------------------------------------------------------------------------------------
builder.Services.AddMvc();
//-------------------------------------------------------------------------------------------------------
builder.Services.AddDbContext<ERPContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmpConnectionString")));
//----------------------------------------------------------------------------------------------------
builder.Services.AddScoped<IDepartmentRepository, SQLDepartmentRepository>();
//------------------------------------------------------------------------------------------------------
//Configure Services
//builder.Services.AddControllers(options =>
//{
//    options.InputFormatters.Insert(0, new XmlSerializerInputFormatter(new MvcOptions()));
//});
//------------------------------------------------------------------------------------------------------
//builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.InputFormatters.Add(new XmlSerializerInputFormatter(new MvcOptions()));
    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
});
//-------------------------------------------------------------------------------------------------------
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ICP Technologies", Version = "v1" });
    //c.IncludeXmlComments("YourApi.xml"); // Optional: Include XML comments in Swagger documentation
});
//-------------------------------------------------------------------------------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
        c.RoutePrefix = "swagger";
    });
}
//////-------------------------------------------------------------------------------------------------------
//app.UseSoapEndpoint<ISampleService>("/Service.asmx", new BasicHttpBinding(), SoapSerializer.XmlSerializer);
//////----------------------------------------------------------------------------------------------------------
app.UseRouting();

//app.UseEndpoints(endpoints => {
//    endpoints.UseSoapEndpoint<ISampleService>("/ServicePath.asmx", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
//});

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
