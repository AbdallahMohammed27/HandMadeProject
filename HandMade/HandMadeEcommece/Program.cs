using HandMadeEcommece.helper;
using HandMadeEcommece.Models;
using HandMadeEcommece.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = builder.Configuration;
builder.Services.Configure<JWT>(config.GetSection("JWT"));
builder.Services.AddScoped<IAuth, Auth>();
var constr = builder.Configuration.GetConnectionString("constr");
builder.Services.AddDbContext<AppDbContext>(Options =>
{
    Options.UseSqlServer(constr);
});


builder.Services.AddCors(Options =>
{
    Options.AddPolicy("MyPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//var stripeSecretKey = builder.Configuration["Stripe:SecretKey"];
//Stripe.StripeConfiguration.ApiKey = stripeSecretKey;

builder.Services.AddIdentity<AppUser, IdentityRole<int>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//ensure the saved data in token is same
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;    
})
    .AddJwtBearer(o=>{
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = config["JWT:Audience"],
            ValidateIssuer = true,
            ValidIssuer = config["JWT:Issuer"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]))
        };
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(o =>
{
    o.IdleTimeout = TimeSpan.FromHours(2);
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});




var app = builder.Build();

app.UseCors("MyPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
