using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.OutputEncoding = System.Text.Encoding.Unicode;


        MyObject obj = new MyObject();
        obj.Run(args);
    }
}

class MyObject
{
    public void Run(string[] inputStrings)
    {
        string[] data;

        if (inputStrings.Length > 0)
        {
            data = inputStrings;
        }
        else
        {
            Console.WriteLine("Будь ласка, введіть рядки, розділені пробілами:");
            data = Console.ReadLine()?.Split(' ') ?? Array.Empty<string>();
        }

        using (MyOtherObject? otherObj = new MyOtherObject(data))
        {
          
        }
    }
}

class MyOtherObject : IDisposable
{
    private string[] _data;

    public MyOtherObject(string[] data)
    {
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public void Dispose()
    {
        Console.WriteLine($"Кількість елементів у масиві рядків: {_data.Length}");

        foreach (var item in _data)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Об'єкт MyOtherObject було видалено");

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}

