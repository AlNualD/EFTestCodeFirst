using EFTestCodeFirst.Controllers;
using EFTestCodeFirst.DAL;
using EFTestCodeFirst.DAL.Repositories;
using EFTestCodeFirst.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>();

builder.Services.AddAutoMapper(typeof(MapperProfileDb), typeof(MapperProfileDto));
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICharacterService, CharacterService>();
builder.Services.AddTransient<IGuildService, GuildService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<IGuildRepository, GuildRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();