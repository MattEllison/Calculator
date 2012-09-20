using System;
using Services;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args == null || args.Length != 1)
            {
                PrintUsage();
                return;
            }

            try
            {
                var operations = new FileService().GetLinesFromFile(args[0]);
                Console.WriteLine(new CalculatorService().Calculate(operations));
            }
            catch
            {
                PrintUsage();
            }
        }

        private static void PrintUsage()
        {
            const string usageMessage = @"
                This program calculates operations specified in file, and returns a result of computation.
                Usage: Calculator.exe <FileName>

                Correct file format:
                <OperationName> <Value>
                .
                .
                .
                apply <Value>

                Valid OperationName (case insensitive):
                add, substract, multiply, devide

                Valid example of a file content:
                add 2
                add 3
                apply 1

                There can be no empty line anywhere. Each file ends with apply statement.
                When file format is incorrect, or application is not used correctly this message is displayed.
                ";

            Console.WriteLine(usageMessage);
        }
    }
}
