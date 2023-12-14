using Microsoft.EntityFrameworkCore;

namespace TodoItemsApi;
public class TodoItemContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    #region Configuration
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseCosmos(
            "https://localhost:8081",
            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
            databaseName: "OrdersDB");
    #endregion
}
