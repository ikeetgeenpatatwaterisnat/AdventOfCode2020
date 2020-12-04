using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Advent2020 {

    public static class Day4 {

        public static int Assignment1() {

            // Read input
            string[] input = InputReader.ReadInputLines(4);

            // Initialize values
            int validCounter = 0;
            bool valid = true;
            int fieldAmount = 0;
            bool cid;
            string[] validKeys = {"cid", "pid", "ecl", "hcl", "hgt", "eyr", "iyr", "byr"};
            List<string> passportKeys = new List<string>();

            // Calculate items
            foreach (string item in input) {
                // Check for new passport
                if (item.Equals("")) {

                    if (valid) {
                        validCounter++;
                    }

                    passportKeys.Clear();
                    fieldAmount = 0;
                   
                } else {

                    // Split item
                    string[] splitItem = item.Split(' ');

                    for (int x = 0; x < splitItem.Length; x++) {

                        foreach (string passportItem in splitItem[x].Split(':')) {

                            if (validKeys.Contains(passportItem)) {
                                passportKeys.Add(passportItem);
                                fieldAmount++;
                            }
                        }
                    }

                    // Initialize bool & set arraycounter
                    cid = passportKeys.Contains("cid");

                    // Check for correct fields
                    if (cid && fieldAmount == 8) {
                        valid = true;
                    } else if (fieldAmount == 7 && !cid) {
                        valid = true;
                    } else {
                        valid = false;
                    }
                }
            }
            if (valid) {
                validCounter++;
            }
            return validCounter;
        }
        public static int Assignment2() {

            // Read input
            string[] input = InputReader.ReadInputLines(4);

            // Initialize values
            int validCounter = 0;
            bool validItems = true;
            bool valid = true;
            int fieldAmount = 0;
            bool cid;
            string[] validKeys = { "cid", "pid", "ecl", "hcl", "hgt", "eyr", "iyr", "byr" };
            string key = "";
            List<string> passportKeys = new List<string>();

            // Calculate items
            foreach (string item in input) {
                // Check for new passport
                if (item.Equals("")) {

                    if (valid && validItems) {
                        validCounter++;
                    }

                    passportKeys.Clear();
                    fieldAmount = 0;
                    validItems = true;

                } else {

                    // Split item
                    string[] splitItem = item.Split(' ');

                    for (int x = 0; x < splitItem.Length; x++) {

                        foreach (string passportItem in splitItem[x].Split(':')) {

                            if (validKeys.Contains(passportItem)) {
                                key = passportItem;
                            } else {
                                bool validItem = false;
                                
                                // Ugly switch case for ugly needs
                                switch (key) {
                                    case "cid":
                                        validItem = true;
                                        break;

                                    case "pid":
                                        if (passportItem.Length == 9) {
                                            validItem = true;
                                        }
                                        break;

                                    case "ecl":
                                        bool ambblu = passportItem.Equals("amb") || passportItem.Equals("blu");
                                        bool brngry = passportItem.Equals("brn") || passportItem.Equals("gry");
                                        bool grnhzloth = passportItem.Equals("grn") || passportItem.Equals("hzl") || passportItem.Equals("oth");
                                        if (ambblu || brngry || grnhzloth) {
                                            validItem = true;
                                        }
                                        break;

                                    case "hcl":

                                        char firstSymbol = passportItem[0];

                                        char[] validBetChars = {'a', 'b', 'c', 'd', 'e', 'f'};
                                        char[] validIntChars = {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
                                        string restOfString = passportItem.Remove(0, 1);

                                        if (firstSymbol == '#' && restOfString.Length == 6) {
                                            foreach (char symbol in restOfString) {
                                                if (validBetChars.Contains(symbol) || validIntChars.Contains(symbol)) {
                                                    validItem = true;
                                                } else {
                                                    validItem = false;
                                                    break;
                                                }
                                            }
                                        }
                                        break;

                                    case "hgt":
                                        if (passportItem.Length == 5) {
                                            if (passportItem[3] == 'c' && passportItem[4] == 'm') {
                                                int length = int.Parse(passportItem.Split("cm")[0]);
                                                if (length >= 150 && length <= 193) {
                                                    validItem = true;
                                                }
                                            }

                                        } else if (passportItem.Length == 4) {
                                            if (passportItem[2] == 'i' && passportItem[3] == 'n') {
                                                int length = int.Parse(passportItem.Split("in")[0]);
                                                if (length >= 59 && length <= 76) {
                                                    validItem = true;
                                                }
                                            }
                                        }
                                        break;

                                    case "eyr":
                                        if (int.Parse(passportItem) >= 2020 && int.Parse(passportItem) <= 2030) {
                                            validItem = true;
                                        }
                                        break;

                                    case "iyr":
                                        if (int.Parse(passportItem) >= 2010 && int.Parse(passportItem) <= 2020) {
                                            validItem = true;
                                        }
                                        break;

                                    case "byr":
                                        if (int.Parse(passportItem) >= 1920 && int.Parse(passportItem) <= 2002) {
                                            validItem = true;
                                        }
                                        break;
                                }

                                if (validItem) {
                                    passportKeys.Add(key);
                                    fieldAmount++;
                                } else {
                                    validItems = false;
                                }
                            }
                        }
                    }

                    // Initialize bool
                    cid = passportKeys.Contains("cid");

                    // Check for correct fields
                    if (cid && fieldAmount == 8) {
                        valid = true;
                    } else if (fieldAmount == 7 && !cid) {
                        valid = true;
                    } else {
                        valid = false;
                    }
                }
            }

            if (valid && validItems) {
                validCounter++;
            }

            return validCounter;
        }
    }
}
