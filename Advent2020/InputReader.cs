using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2020 {
    public static class InputReader {

        public static string ReadInput(int day) =>
            System.IO.File.ReadAllText($@"C:\Users\max96\source\repos\Advent2020\Advent2020\Input\Day{day}Input.txt");

        
        public static string[] ReadInputLines(int day) =>
            System.IO.File.ReadAllLines($@"C:\Users\max96\source\repos\Advent2020\Advent2020\Input\Day{day}Input.txt");

    }
}
