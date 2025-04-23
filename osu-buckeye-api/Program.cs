var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//ADD AFTER builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite("Data Source=../osu-buckeye.db"));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder=> {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
}

);


builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
