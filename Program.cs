using PRM392_Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddSignalR();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/chatHub");

app.MapGet("/",() =>
{
    Console.WriteLine("CONNECTED");
    return "CONNECTED";
});

app.Run();
