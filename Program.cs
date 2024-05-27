using ApFpoly_API.Data;
using ApFpoly_API.Services.Implementations;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder => builder.WithOrigins("https://apclone-22ec7.web.app/").AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((host) => true));

});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddDbContext<AuthContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);



//register the service
builder.Services.AddScoped<ISinhVienDependency, SinhVienDependency>();
builder.Services.AddScoped<IGiangVienDependency, GiangVienDependency>();
builder.Services.AddScoped<IMonHocDependency, MonHocDependency>();
builder.Services.AddScoped<IPhongHocDependency, PhongHocDependency>(); 
builder.Services.AddScoped<ILopHocChiTietDependency, LopHocChiTietDependency>(); 
builder.Services.AddScoped<ILichHocDependency, LichHocDependency>();
builder.Services.AddScoped<ILopHocDependency, LopHocDependency>(); 
builder.Services.AddScoped<IHocKyBlockDependency, HocKyBlockDependency>();
builder.Services.AddScoped<IValidateDependency, ValidateDependency>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
    app.UseSwaggerUI();
} 
app.UseCors("CORSPolicy");
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
if (!Directory.Exists(uploadsPath))
{
    Directory.CreateDirectory(uploadsPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
    RequestPath = "/uploads"
});

app.MapControllers();

app.Run();