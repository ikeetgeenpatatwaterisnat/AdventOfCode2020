using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2020 {
    public static class Day2 {



        public static int Assignment1() {

            string[] input = InputReader.ReadInputLines(2);
            int validCounter = 0;

            foreach (string item in input) {

                int amount1 = int.Parse(item.Split('-')[0]);
                int amount2 = int.Parse(item.Split('-')[1].Split(' ')[0]);

                string letter = item.Split('-')[1].Split(' ')[1].TrimEnd(':') ;
                string passwordLetters = item.Split(':')[1].Trim();

                int initAmount = passwordLetters.Length;
                int finalAmount = passwordLetters.Replace(letter, "").Length;
                int ifAmount = initAmount - finalAmount;

                if (ifAmount >= amount1 && ifAmount <= amount2) {
                    validCounter++;
                }
            }

            return validCounter;

        }

        public static int Assignment2() {

            string[] input = InputReader.ReadInputLines(2);
            int validCounter = 0;

            foreach (string item in input) {

                int amount1 = int.Parse(item.Split('-')[0]);
                int amount2 = int.Parse(item.Split('-')[1].Split(' ')[0]);

                char letter = char.Parse(item.Split('-')[1].Split(' ')[1].TrimEnd(':'));
                string passwordLetters = item.Split(':')[1].Trim();

                if (passwordLetters[amount1 - 1] == letter ^ passwordLetters[amount2 - 1] == letter) {
                    validCounter++;
                }
                
            }

            return validCounter;

        }
    }
}
