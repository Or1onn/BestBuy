namespace ConsoleApp1;

public class Program
{
    public static void Main()
    {
        using ModelContext context = new();

        var model = context.Model.ToList();

        var newModel = new Model()
        {
            Style = GameStyle.RPG,
            GameName = "DOOM"
        };

        model.Add(newModel);

        foreach (var item in model)
        {
            Console.WriteLine($"Name: {item.GameName}\nStyle: {item.Style}\n" +
                              $"Release date: {item.ReleaseDate}");
        }

        context.SaveChanges();

    }
}
