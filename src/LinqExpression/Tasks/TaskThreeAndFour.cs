using System.Diagnostics;

namespace LinqExpression.Tasks
{
    /// <summary>
    /// Task Three and Four: Demonstrates LINQ-querying on integer array to find
    /// the second largest number, find pairs that add up to a given target sum,
    /// and time execution of regular and optimized queries to retrieve the
    /// same results.
    /// </summary>
    public class TaskThreeAndFour
    {
        private readonly int _target;
        private int[] _numbers;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskThreeAndFour"/> class.
        /// </summary>
        /// <param name="count">
        /// The number of integers to generate for array-based task.
        /// </param>
        /// <param name="target">
        /// The target sum for sum-pair retrieval task.
        /// </param>
        public TaskThreeAndFour(int count, int target)
        {
            this._numbers = this.PopulateArray(count: count);
            this._target = target;
        }

        /// <summary>
        /// Execute the actual task (#3) and write the output to the console.
        /// </summary>
        public void ExecuteThree()
        {
            Console.WriteLine("Actual Array:");
            Console.WriteLine(string.Join(", ", this._numbers));
            Console.WriteLine();

            int largest = this._numbers.Max();

            int secondLargest = this._numbers.Where(number => number < largest).Max();

            Console.WriteLine($"Second largest number in array: {secondLargest}\n");

            (int Num1, int Num2)? targetSumPair = this.FindTargetSumPairs();
            this.PrintPair(targetSumPair);
        }

        /// <summary>
        /// Execute the actual task (#4) and write the output to the console.
        /// </summary>
        public void ExecuteFour()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            (int Num1, int Num2)? targetSumPair = this.FindTargetSumPairs();
            stopwatch.Stop();

            this.PrintPair(targetSumPair);
            Console.WriteLine($"Regular version time elapsed (in ms): {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            (int Num1, int Num2)? targetSumPairOptimized = this.FindTargetSumPairsOptimized();
            stopwatch.Stop();

            this.PrintPair(targetSumPairOptimized);
            Console.WriteLine($"Optimized version time elapsed (in ms): {stopwatch.ElapsedTicks}");
        }

        private void PrintPair((int Num1, int Num2)? pair)
        {
            if (pair is null)
            {
                Console.WriteLine("No pairs found!\n");
                return;
            }

            Console.WriteLine($"{pair.Value.Num1} + {pair.Value.Num2} = {this._target}");
        }

        private (int Num1, int Num2)? FindTargetSumPairs()
        {
            // Create a fast lookup table mapping values to their indices
            var lookup = this._numbers.Select((val, idx) => new { val, idx })
                                 .ToLookup(x => x.val, x => x.idx);

            var result = this._numbers
                .Select((num, idx) => new { num, idx })
                .Where(x =>
                {
                    int complement = this._target - x.num;
                    return lookup.Contains(complement) &&
                           lookup[complement].Any(complementIdx => complementIdx != x.idx);
                })
                .Select(x => (x.num, this._target - x.num))
                .FirstOrDefault();

            return result.Equals(default) ? null : result;
        }

        private (int Num1, int Num2)? FindTargetSumPairsOptimized()
        {
            var pair = this._numbers
                .SelectMany((num1, index1) => this._numbers.Skip(index1 + 1)
                                                     .Select(num2 => new { num1, num2 }))
                .FirstOrDefault(p => p.num1 + p.num2 == this._target);

            return pair != null ? (pair.num1, pair.num2) : null;
        }

        private int[] PopulateArray(int count)
        {
            int[] numbers = new int[count];
            Random random = new Random();

            for (int i = 0; i < count; ++i)
            {
                numbers[i] = random.Next(1, 100 + 1);
            }

            return numbers;
        }
    }
}
