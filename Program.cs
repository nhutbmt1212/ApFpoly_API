using ApFpoly_API.Data;
using ApFpoly_API.Services.Implementations;
using ApFpoly_API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder => builder.WithOrigins("https://apclone-22ec7.web.app/").AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((host) => true));

});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddDbContext<AuthContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AuthContext>();
//register the service
builder.Services.AddScoped<ISinhVienDependency, SinhVienDependency>();
builder.Services.AddScoped<IGiangVienDependency, GiangVienDependency>();
builder.Services.AddScoped<IMonHocDependency, MonHocDependency>();
builder.Services.AddScoped<IPhongHocDependency, PhongHocDependency>(); 
builder.Services.AddScoped<ILopHocChiTietDependency, LopHocChiTietDependency>(); 
builder.Services.AddScoped<ILichHocDependency, LichHocDependency>();
builder.Services.AddScoped<ILopHocDependency, LopHocDependency>(); 
builder.Services.AddScoped<IHocKyBlockDependency, HocKyBlockDependency>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  
}  app.UseSwagger();
    app.UseSwaggerUI();
app.UseCors("CORSPolicy");
app.UseRouting();
app.MapIdentityApi<IdentityUser>();

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