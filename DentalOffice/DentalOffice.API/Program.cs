using DentalOffice.API.Extensions;
using DentalOffice.Mapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using DentalOffice.Enums;
using DentalOffice.Entities.dbContext;
using DentalOffice.API.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.AddPersistence(builder.Configuration);
builder.Services.RegisterServices();
builder.Services.AddBasicAuth();

var app = builder.Build();

SeedDatabase();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        try
        {
            var scopedContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            DbSeed.SeedDB(scopedContext);
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }  
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


