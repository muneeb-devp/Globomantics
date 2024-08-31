using Globomantics.Data;
using Globomantics.Data.Repositories;
using Globomantics.Extensions;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
builder.Services.AddDbContext<HouseDbContext>();

builder.Services.AddScoped<IHouseRepository, HouseRepository>();
builder.Services.AddScoped<IBidRepository, BidRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod());
// app.UseHttpsRedirection();

app.MapHouseEndpoints();
app.MapBidEndpoints();

app.Run();