using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region(ORM关系映射服务设置)
var connectionString = builder.Configuration.GetConnectionString("QBSDB");
builder.Services.AddDbContext<QBS.DbManager.DbContexts.QBSDbContext>(option => 
                                                                    option.UseSqlServer(connectionString));
builder.Services.AddIdentity<QBS.Models.Identity.SysUser, QBS.Models.Identity.SysRole>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<QBS.DbManager.DbContexts.QBSDbContext>();
builder.Services.AddSingleton(typeof(QBS.DbManager.DbContexts.QBSDbContext));
builder.Services.AddSingleton(typeof(QBS.Utility.ConfigService));

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});
#endregion

#region(生成数据库)
#endregion
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
