
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project_Angular.Models;
using Project_Angular.UniteOfwork;
using System.Security.Cryptography;
using System.Text;

namespace Project_Angular
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<EcommerceContext>(options => {
                options.UseSqlServer("Data Source= DESKTOP-9KVOJTR;Initial Catalog=Ecommerce_Angular;Integrated Security=True;Encrypt=False");
            });
            
            builder.Services.AddScoped<_uniteOfwork>();
            //Register Identity Services wethere user Manager or User Stores
            builder.Services.AddIdentity<ApplicationUser,IdentityRole<int>>(
                options => { 
                options.Password.RequireNonAlphanumeric = false;
                }
                ).AddEntityFrameworkStores<EcommerceContext>();
            builder.Services.AddCors(option => { option.AddPolicy("myCros", op => op.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); }) ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           builder.Services.AddAuthentication(option => {
               //option.DefaultAuthenticateScheme = "mySchema"; 
               option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

           } ) //.AddJwtBearer("mySchema", op => {
                .AddJwtBearer( op => {
                    var secrite = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("i am mairem graduated from factly of commerce al azhar university "));
                    op.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = secrite,
                        ValidateIssuer=false,
                        ValidateAudience=false,
                        ValidateActor=false,
                        RequireExpirationTime=false,
                        ValidateIssuerSigningKey=false

                    };});
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseCors("myCros");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
