﻿using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Advent2020 {
    public static class Day1 {

        public static int Assignment1(int day) {

            LinkedList<int> numbers = new LinkedList<int>();
            Stack<int> numbers1 = new Stack<int>();
            LinkedList<int> numbers2 = new LinkedList<int>();

            foreach (string number in InputReader.ReadInputLines(1)) {
                numbers.AddFirst(int.Parse(number));
                numbers1.Push(int.Parse(number));
                numbers2.AddFirst(int.Parse(number));
            }

            while(numbers1.Count > 0) {
                int compareNumber = numbers1.Pop();
                LinkedListNode<int> currentNode2 = numbers2.First;

                while (1 == 1) {
                    LinkedListNode<int> currentNode = numbers.First;

                    while (1 == 1) {
                        if ((currentNode.Value + compareNumber + currentNode2.Value) == 2020) {
                            return currentNode.Value * compareNumber * currentNode2.Value;
                        }

                        if (currentNode.Next != null) {
                            currentNode = currentNode.Next;
                        } else {
                            break;
                        }
                    }
                    if (currentNode2.Next != null) {
                        currentNode2 = currentNode2.Next;
                    } else {
                        break;
                    }
                }
            }

            return 0;
        }

    }
}
