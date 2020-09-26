using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;

class MainClass {
  /*
  Summary: 
  This program (I know can be written more efficiently)
  finds all possible nugget packaging combinations by first
  trying to use as many of the largest boxes as possible, 
  then filling it in with as many as the smaller box size 
  and so on. Then doing one less than the maximumm of the
  largest box and so on.

  Ex.
    Amount: 71
    Program:
      71/20 = 3
      Therefore:
      3 boxes of 20 = 60 packed nuggets
      71 - 60 = 11
      Next:
        11/9 = 1
        Therefore:
        1 box of 9 = 9 more packed nuggets
        11 - 9 = 2
        2 < 4, Therefore program moves back to the next highest
        box size (9). However it used the lowest possible amount
        of this size (1) already. Therefore it moves back to the
        next highest box size (20)
        Since it last used 3 boxes of 20, it will now try 2 boxes
        2 boxes of 20 = 40 packed nuggets
        71 - 40 = 31
        Next:
          31/9 = 3
          Therefore:
          3 boxes of 9 = 27 more packed nuggets
          31 - 27 = 4
          Next:
            4/6 = 0
            Therefore:
            0 boxes of 6 = 0 more packed nuggets
            4 - 0 = 4
            Next:
              4/4 = 1
              Therefore:
              1 box of 4 = 4 more packed nuggets
              4 - 4 = 0
              Therefore:
              The combination of 2 boxes of 20, 3 boxes of 9, and
              1 box of 4 (20, 20, 9, 9, 9, 4) is added to the list of possible combinations.
              Next:
                It moves back to the next highest box size possible
                (9).
                2 boxes of 9 = 18 more packed nuggets
                31 - 18 = 13
                (And this continues for every box size)
  */
  public static void Main (string[] args) {
    Write ("\nEnter the desired number of nuggets: ");
    int amount = Convert.ToInt32(ReadLine());
    // Store the list of box combinations returned by the method
    List<List<int>> combos = FindCombos(amount);
    // bool stays false if there are no possible box combinations
    bool possible = false;
    // Print all possible combinations
    WriteLine ("\n\nCombinations:");
    foreach (List<int> combo in combos) {
      Write ("(");
      foreach (int box in combo) {
        Write(box + ", ");
        possible = true;
      }
      Write("\b\b)\n");
    }
    // If the boolean was never changed to true 
    // (if no combination was found), prints out "None"
    if (!possible) {
      WriteLine("None");
    }
  }
  public static List<List<int>> FindCombos(int amount) {
    // Initializes list of possible combinations
    // that the method will return
    List<List<int>> combos = new List<List<int>>();
    // Array has all the box size possibilities
    int[] sizes = new int[]{20, 9, 6, 4};
    // For every size in the list of box sizes...
    foreach (int size1 in sizes) {
      // For as many times as it is possible to use this box size
      // for this amount of nuggests...
      for (int times1 = amount/size1; times1 > 0; times1--) {
        // Copies the amount in order to perform operations without
        // losing the original amount
        int amount1 = amount;
        // Initialises list to store the box sizes being used for this combination
        List<int> combination1 = new List<int>();
        // Adds as many boxes of the current size as defined by the loop above into the combination list and subtracts the amount of nuggets being stored in those boxes from the copied amount
        for (int t = times1; t > 0; t--) {
          combination1.Add (size1);
          amount1 -= size1;
        }
        // If the boxes can fit the exact number of nuggets, add this combination to the list of of possible combinations and continue to the next iteration of the loop (next amount of boxes)
        if (amount1 == 0) {
          combos.Add(combination1);
          continue;
        }
        // If the remaining nuggets can't fill another box, skip to the next iteration of the loop
        else if (amount1 < 4) {
          continue;
        }
        // If there are still nuggets that can fit in smaller boxes...
        else {
          foreach (int size2 in sizes) {
            if (size2 >= size1) {
              continue;
            }
            for (int times2 = amount1/size2; times2 > 0; times2--) {
              int amount2 = amount1;
              List<int> combination2 = new List<int>(combination1);
              for (int t = times2; t > 0; t--) {
                combination2.Add (size2);
                amount2 -= size2;
              }
              if (amount2 == 0) {
                combos.Add(combination2);
                continue;
              }
              else if (amount2 < 4) {
                continue;
              }
              else {
                foreach (int size3 in sizes) {
                  if (size3 >= size2) {
                    continue;
                  }
                  for (int times3 = amount2/size3; times3 > 0; times3--) {
                    int amount3 = amount2;
                    List<int> combination3 = new List<int>(combination2);
                    for (int t = times3; t > 0; t--) {
                      combination3.Add (size3);
                      amount3 -= size3;
                    }
                    if (amount3 == 0) {
                      combos.Add(combination3);
                      continue;
                    }
                    else if (amount3 < 4) {
                      continue;
                    }
                    else {
                      foreach (int size4 in sizes) {
                        if (size4 >= size3) {
                          continue;
                        }
                        for (int times4 = amount3/size4; times4 > 0; times4--) {
                          int amount4 = amount3;
                          List<int> combination4 = new List<int>(combination3);
                          for (int t = times4; t > 0; t--) {
                            combination4.Add (size4);
                            amount4 -= size4;
                          }
                          if (amount4 == 0) {
                            combos.Add(combination4);
                            continue;
                          }
                          else if (amount3 < 4) {
                            continue;
                          }
                          else {}
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
    return combos;
  }
}