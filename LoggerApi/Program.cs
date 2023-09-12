var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowBlazorApp", builder =>
        {
            builder.WithOrigins("https://localhost:7299/") // Replace with your Blazor app URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowBlazorApp");

app.UseRouting();

app.MapControllers();

app.Run();
