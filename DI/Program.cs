
class DependencyInjection
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class MyDependency
{
    public void WriteMessage(string message)
    {
        Console.WriteLine($"MyDependency.WriteMessage called. Message: {message}");
    }
}
//lets say we have this class

public class IndexModel 
{
    private readonly MyDependency _dependency = new MyDependency();

    public void OnGet()
    {
        _dependency.WriteMessage("IndexModel.OnGet");
    }
}
//this class depends on the Mydependency class
/*  Now 
 *  1) if we want to implement a different class in place of Mydependency we can not do that
 *  2) if Mydependency class depends on some other class we have to change the   Mydependency as ell the Index model class.
 *  this will make it quite difficult for unit testing
 *  
 *  3) to prevent this from happening : we can put different implemenattaion inside the Index Model class in place of Mydependency only
 *  
 *  what we can do is : 
 *      i) create an abstract or an interface so that we can have different implementations of the same IMydependency type 
 *      ii) and we can use those different implementation : no rigidity.
 *      
 *      Something like _______--*/


public interface IMyDependency
{
    void WriteMessage(string message);
}

public class MyDependenc : IMyDependency
{
    public void WriteMessage(string message)
    {
        Console.WriteLine($"MyDependency.WriteMessage called. Message: {message}");
    }
}

public class AnotherDependency : IMyDependency
{
    public void WriteMessage(string message)
    {
        Console.WriteLine($"AnotherDependency.WriteMessage called. Message: {message}");
    }
}