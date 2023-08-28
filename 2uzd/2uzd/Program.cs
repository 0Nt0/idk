using _2uzd.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-w1l2iew8i0oobcrh.us.auth0.com/";
    options.Audience = "https://hello-world1.example.com";
});

builder.Services.AddDbContext<BookDbContext>(o =>
{ o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
   o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}) ;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    app.UseDeveloperExceptionPage();
    //  app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
