using BuySell.Api;
using BuySell.Api.Middleware;
using BuySell.Api.Repositories;
using BuySell.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BuySellDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IClaimsHelper, ClaimsHelper>();
builder.Services.AddScoped<IUsersService, UsersService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// Authentication/Authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.Authority = "http://localhost:8080/realms/buysell-realm";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            RoleClaimType = "realm_access.roles"
        };

        //options.Events = new JwtBearerEvents
        //{
        //    OnTokenValidated = context =>
        //    {
        //        var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
        //        var realmAccess = context.Principal.FindFirst("realm_access")?.Value;

        //        if (realmAccess != null)
        //        {
        //            var parsed = JsonDocument.Parse(realmAccess);
        //            if (parsed.RootElement.TryGetProperty("roles", out var roles))
        //            {
        //                foreach (var role in roles.EnumerateArray())
        //                {
        //                    claimsIdentity?.AddClaim(new Claim(claimsIdentity.RoleClaimType, role.GetString()));
        //                }
        //            }
        //        }
        //        return Task.CompletedTask;
        //    }
        //};

    });


//builder.Services.AddAuthorizationBuilder()
//          .AddPolicy(AuthorizationPolicies.Admin, policy =>
//          {
//              policy.RequireRole("Admin");
//              policy.RequireAssertion(context =>
//              {
//                  return context.User.Claims.Any(claim =>
//                      claim.Type == "scope" && claim.Value.Split(' ').Contains("Auc.FullAccess"));
//              });
//          });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireClaim(ClaimsHelper.RoleClaimId,"ADMIN"));

    options.AddPolicy("SellerOrAdmin", policy =>
        policy.RequireClaim(ClaimsHelper.RoleClaimId, "SELLER","ADMIN"));

    options.AddPolicy("TestRole", policy =>
        policy.RequireClaim(ClaimTypes.Role,"admin2"));

    //options.AddPolicy()
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseMiddleware<ClaimBuilderMiddleware>();
app.UseAuthorization();


app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
