using System;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Test
{
    public class CsvTestHelpers
    {
        public static void MeasureElapsedTime(string description, ITestOutputHelper outputHelper, Action action)
        {
            TimeSpan ts = MeasureElapsedTime(action);

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            outputHelper.WriteLine($"[{description}] Elapsed Time = {elapsedTime}");
        }

        public static TimeSpan MeasureElapsedTime(Action action)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            action();
            stopWatch.Stop();

            return stopWatch.Elapsed;
        }
    }
}
