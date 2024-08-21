namespace RoutingApp.DummyResources;

public interface IRepository1
{
    Task GetValue();
}

public interface IRepository2
{
}

public class Repository1 : IRepository1
{
    public async Task GetValue()
    {
        await Task.Delay(0);
        Console.WriteLine("GetValue");
    }
}

public class Repository2 : IRepository2
{
}