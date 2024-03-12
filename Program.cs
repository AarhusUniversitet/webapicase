using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddTransient<SqliteConnection>((serviceProvider) =>
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "app.db" };
            var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
            connection.Open();

            // Opret en tabel (hvis den ikke allerede eksisterer)
            using (var command = new SqliteCommand("CREATE TABLE IF NOT EXISTS Products (Id INTEGER PRIMARY KEY, Name TEXT, Price DECIMAL)", connection))
            {
                command.ExecuteNonQuery();
            }
            return connection;
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

