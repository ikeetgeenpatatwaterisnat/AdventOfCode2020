using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Advent2020 {
    public static class Day3 {

        public static int Assignment1(int yIncr, int xIncr) {

            // Initialize input
            string[] input = InputReader.ReadInputLines(3);

            // Initialize conversion values
            int x;
            int maxX = input[0].Length;

            int y = 0;
            int maxY = input.Length;

            // Initialize other values
            int treeCounter = 0;

            // Convert input to 2d array
            char[,] dInput = new char[maxY, maxX];

            foreach (string line in input) {
                x = 0;

                foreach (char symbol in line) {
                    dInput[y, x] = symbol;
                    x++;
                }

                y++;
            }

            // Calculate movement
            y = 0;
            x = 0;

            for (;y < maxY; y += yIncr) {

                if (dInput[y, x] == '#') {
                    treeCounter++;
                }

                if (x + xIncr >= maxX) {
                    int diff = x - maxX;
                    x = xIncr + diff;
                } else {
                    x += xIncr;
                }
            }

            return treeCounter;
        }

        public static int Assignment2() {
            int slope1 = Assignment1(1, 1);
            int slope2 = Assignment1(1, 3);
            int slope3 = Assignment1(1, 5);
            int slope4 = Assignment1(1, 7);
            int slope5 = Assignment1(2, 1);

            return slope1 * slope2 * slope3 * slope4 * slope5;
        }
    }
}
