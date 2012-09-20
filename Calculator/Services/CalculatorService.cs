using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Services
{
    public class CalculatorService
    {
        private const string ApplyOperation = "apply";

        private readonly IDictionary<string, Func<double,double,double>> operations = 
            new Dictionary<string, Func<double, double, double>>
                {
                    {"add", (x,y) => x + y},
                    {"multiply", (x,y) => x * y},
                    {"divide", (x,y) => x / y},
                    {"substract", (x,y) => x - y}
                };

        /// <summary>
        /// Calculates operations provided in a collection.
        /// </summary>
        /// <param name="operations">Collection of operations.</param>
        /// <returns>A result of computation.</returns>
        public double Calculate(IEnumerable<string> operations)
        {
            // Freeze a collection.
            var lines = operations.ToList();

            var applyValue = GetApplyValue(lines.Last());

            // Don't calculate the apply value - it was already calculated
            var operationsWoApply = lines.Take(lines.Count - 1);
            return Calculate(applyValue, operationsWoApply);
        }

        /// <summary>
        /// Perform operations on apply value.
        /// </summary>
        /// <returns>Result of computation.</returns>
        private double Calculate(double applyValue, IEnumerable<string> operations)
        {
            return operations.Aggregate(applyValue, (current, line) => CalculatedValue(line, current));
        }

        /// <summary>
        /// Perform an knownOperation on a calculatedValue
        /// </summary>
        /// <returns>result of a computation</returns>
        private double CalculatedValue(string operation, double calculatedValue)
        {
            bool isOperationCorrect = false;
            foreach (var knownOperation in operations.Keys)
            {
                double valueFromLine;
                if (TryGetValueFromLine(operation, knownOperation, out valueFromLine))
                {
                    calculatedValue = operations[knownOperation](calculatedValue, valueFromLine);
                    isOperationCorrect = true;
                    break;
                }
            }

            if(!isOperationCorrect)
            {
                throw new ApplicationException("Line is in incorrect format: " + operation);
            }
            return calculatedValue;
        }

        private static bool TryGetValueFromLine(string line, string knownOperation, out double valueFromLine)
        {
            valueFromLine = 0;
            try
            {
                if(Regex.IsMatch(line,
                                string.Format(@"^{0} [0-9]+$", knownOperation),
                                RegexOptions.IgnoreCase))
                {
                    var extractedValue = Regex.Match(line,
                                string.Format(@"[0-9]+"),
                                RegexOptions.IgnoreCase).Value;

                    valueFromLine = double.Parse(extractedValue);
                    return true;
                }
            }catch{}

            return false;
        }

        private double GetApplyValue(string applyLine)
        {
            double valueFromLine;
            if(TryGetValueFromLine(applyLine, ApplyOperation, out valueFromLine))
            {
                return valueFromLine;
            }

            throw new ApplicationException("Incorrect format of apply knownOperation.");
        }
    }
}
