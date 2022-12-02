//using DelegateExercise;

class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Beispiel 1: Converter");
        decimal[] converted = LambdaTest.Converter(new decimal[] { -10, 0, 10, 20, 30 }, value => value + 273.15M);
        LambdaTest.ForEach(converted, value => Console.WriteLine(value));

        Console.WriteLine("Beispiel 2: Filter");
        decimal[] freezed = LambdaTest.Filter(converted, values => values < 273.15M);
        LambdaTest.ForEach(freezed, value => Console.WriteLine(value));

        Console.WriteLine("Beispiel 3: Division");
        decimal result = LambdaTest.ArithmeticOperation(2, 0, (x, y) => { if (y == 0) { return 0; } return x / y; });
        Console.WriteLine(result);
        result = LambdaTest.ArithmeticOperation(2, 0, (x,y) => x/y, message => Console.Error.WriteLine(message));
        Console.WriteLine(result);

        Console.WriteLine("Beispiel 4: Callback Funktion");
        LambdaTest.RunCommand(() => { Console.WriteLine("Hello World."); Console.WriteLine("Hello World again."); });

        Console.ReadLine();
    }
}