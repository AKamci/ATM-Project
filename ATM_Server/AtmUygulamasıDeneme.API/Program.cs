using AtmUygulamasýDeneme.API.Models;
using AtmUygulamasýDeneme.Business.Abstract;
using AtmUygulamasýDeneme.Business.Concrete;
using AtmUygulamasýDeneme.DataAccess.Abstract;
using AtmUygulamasýDeneme.DataAccess.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty))

        };
    }
                );

builder.Services.Configure<JwtAyarlari>(builder.Configuration.GetSection("Jwt"));



builder.Services.AddControllers();


builder.Services.AddSingleton<IMusteriService, MusteriManager>();
builder.Services.AddSingleton<IMusteriRepository, MusteriRepository>();


builder.Services.AddSwaggerDocument();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseOpenApi();
app.UseSwaggerUi3();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



app.MapRazorPages();

app.Run();
