
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(); // IAR jue 30MAY2024

//Add support to logging with SERILOG. IAR jue 30MAY2024
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));


var app = builder.Build();

// Configure the HTTP request pipeline.
// IAR jue 30MAY2024
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseExceptionHandler("/Error");
}
//if (builder.Environment.IsDevelopment())
//{
//    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
//    {
//        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//        options.RoutePrefix = string.Empty;
//    });
//}

//Add support to logging request with SERILOG. IAR jue 30MAY2024
/*
It’s important that the UseSerilogRequestLogging() the call appears before handlers such as MVC. 
The middleware will not time or log components that appear before it in the pipeline. (This can be 
utilized to exclude noisy handlers from logging, such as UseStaticFiles(), by placing 
UseSerilogRequestLogging() after them.) 
*/
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
