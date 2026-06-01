namespace _02TaskTrackerwithJWT.Datas;

public interface ISeeder
{
    Task SeedAsync(AppDbContext context,IServiceProvider serviceProvider);
}