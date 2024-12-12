internal class Program
{
    public static void Main(string[] args)
    {

        
        Parallel.Invoke(
            () => details(),
            () => details(),
            () => details()
            );

    }
    public static void details()
    {
        Singleton obj = Singleton.Instance();
        obj.meth();
    }
}
public sealed  class Singleton
{
    private static int Counter = 0;
    private static Singleton inst = null;

    private Singleton()
    {
        Counter++;
        Console.WriteLine("Counter is : "+Counter);
    }

    public static Singleton Instance() { 
        if(inst == null)
        {
            inst = new Singleton();

        }
        return inst;
    }
    //another method 
    public void meth()
    {
        Console.WriteLine("Singleton's Method");
    }
    
}


