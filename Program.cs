using PRM392_Server.Hubs;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Encoder =
                System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
        }
    );

builder.Services.AddSignalR();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.MapHub<ChatHub>("/chatHub");

app.MapGet("/",() => {Console.WriteLine("CONNECTED");return "CONNECTED";});

app.Run();
