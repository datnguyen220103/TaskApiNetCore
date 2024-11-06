using Microsoft.EntityFrameworkCore;
using TaskListApi;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 27)))); // Cập nhật phiên bản MySQL nếu cần

builder.Services.AddControllers();
var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();
