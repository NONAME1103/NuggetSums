using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;

class MainClass {
  /*
  Task - Nugget Sums
  Chicken nuggets come in boxes of 4 , 6 , 9 and 20. Write a  program that takes in a number and returns if that exact   number of chicken nuggets can be reached using the box sizes given. So 2 would be no but 10 would be yes (6 and 4). ext   return all possible box size combinations. 
  */
  public static void Main (string[] args) {
    Write ("\nEnter the desired number of nuggets: ");
    int amount = Convert.ToInt32(ReadLine());
    // Store the list of box combinations returned by the method
    // and initialize another list to record which combinations
    // have already been outputed (to avoid duplicates).
    List<List<int>> combos = FindCombos(amount);
    List<List<int>> printed = new List<List<int>>();
    // bool stays false if there are no possible box combinations
    bool possible = false;
    // Print all possible combinations avoiding duplicates
    WriteLine ("\n\nCombinations:");
    foreach (List<int> combo in combos) {
      if (combo.Count == 0) {
        continue;
      }
      bool skip = false;
      foreach (List<int> list in printed) {
        if (list.SequenceEqual(combo)) {
          skip = true;
          break;
        }
      }
      if (skip) {
        continue;
      }
      printed.Add(combo);
      Write ("(");
      foreach (int box in combo) {
        Write(box + ", ");
        possible = true;
      }
      Write("\b\b)\n");
    }
    if (!possible) {
      WriteLine("None");
    }
  }
  public static List<List<int>> FindCombos(int amount) {
    // Initialize the list of possible combinations
    List<List<int>> combos = new List<List<int>>();
    // sets up a copy of the amount of nuggets to package
    // and keeps track of the list indecies to avoid overwriting
    int amountCopy;
    int possibility = 0;
    // this list defines at which box size it will start
    // packaging nuggets in
    int[] starts = new int[] {20, 9, 6, 4};
    foreach (int start in starts) {
      // resets the amount copy for next combination
      amountCopy = amount;
      // adds new list for this combination in the 2D list
      combos.Add (new List<int>());
      // This will keep allocating the largest boxes of nuggets
      // possible until there are no nuggets left or
      // they cannot be packaged properly
      while (amountCopy > 0) {
        if (amountCopy >= 20 && start == 20) {
          combos[possibility].Add (20);
          amountCopy -= 20;
        }
        else if (amountCopy >= 9 && start >= 9) {
          combos[possibility].Add (9);
          amountCopy -= 9;
        }
        else if (amountCopy >= 6 && start >= 6) {
          combos[possibility].Add (6);
          amountCopy -= 6;
        }
        else if (amountCopy >= 4 && start >= 4) {
          combos[possibility].Add (4);
          amountCopy -= 4;
        }
        else {
          if (amountCopy != 0) {
            combos[possibility].Clear();
          }
          break;
        }
      }
      possibility++;
    }
    // This will keep allocating boxes of nuggets from 
    // smallest to largest until there are no nuggets left
    // or they cannot be packaged properly
    foreach (int start in starts) {
      amountCopy = amount;
      combos.Add (new List<int>());
      while (amountCopy > 0) {
        if (amountCopy >= 20 && start == 20) {
          combos[possibility].Add (20);
          amountCopy -= 20;
        }
        if (amountCopy >= 9 && start >= 9) {
          combos[possibility].Add (9);
          amountCopy -= 9;
        }
        if (amountCopy >= 6 && start >= 6) {
          combos[possibility].Add (6);
          amountCopy -= 6;
        }
        if (amountCopy >= 4 && start >= 4) {
          combos[possibility].Add (4);
          amountCopy -= 4;
        }
        else {
          if (amountCopy != 0) {
            combos[possibility].Clear();
          }
          break;
        }
      }
      possibility++;
    }
    return combos;
  }
}