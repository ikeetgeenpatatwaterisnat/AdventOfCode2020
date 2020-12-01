using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2020 {
    public static class InputReader {

        public static string ReadInput(string path) {

            return System.IO.File.ReadAllText(path);

        }

        public static string[] ReadInputLines(string path) {

            return System.IO.File.ReadAllLines(path);

        }

    }
}
