using Microsoft.EntityFrameworkCore;
using CityInfo.API.DbContexts;
using CityInfo.API.Services;
using CityInfo.API.Clients;
using CityInfo.API.Repositories;
using CityInfo.API.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicantInfoContext>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:ApplicantInfoDBConnectionString"]));

builder.Services.AddScoped<IApplicantInfoRepository, ApplicantInfoRepository>();

builder.Services.AddScoped<ApplicationService>();

builder.Services.AddHttpClient<VRNAddressValidationClient>(client =>{
    //client.BaseAddress = new Uri("hello")
    //client.DefaultRequestHeaders.Add

});

//builder.Services.AddScoped<VRNAddressValidationClient>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();


var app = builder.Build();  


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{   
    endpoints.MapControllers();
});



app.Run();
