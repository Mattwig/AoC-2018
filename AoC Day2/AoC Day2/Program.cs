using System;
using System.IO;
using System.Linq;

namespace AoC_Day2
{
     class Program
     {
          static void Main(string[] args)
          {
               var input = File.ReadAllLines("puzzleInput.txt");

               // Question 1
               var twoLetterMatches = 0;
               var threeLetterMatches = 0;               

               // Loop through all of the lines
               foreach (var line in input)
               {
                    var twoMatchFound = false;
                    var threeMatchFound = false;
                    var lineArray = line.ToCharArray();

                    // Loop through all of the characters in the line
                    foreach(var letter in lineArray)
                    {
                         // Use linq to get the number of matches in each entry
                         var match = lineArray.Count(x => x == letter);

                         // If we don't check to see if we already found a match then out matches will increment too much in cases where a line could have more than one 2 letter match
                         if (match == 2 && twoMatchFound == false)
                         {
                              twoLetterMatches++;
                              twoMatchFound = true;
                         }
                         else if (match == 3 && threeMatchFound == false)
                         {
                              threeLetterMatches++;
                              threeMatchFound = true;
                         }
                         else if (twoMatchFound && threeMatchFound) break;                         
                    }
               }

               // Write out the answers
               Console.WriteLine("Two letter Matches: " + twoLetterMatches);
               Console.WriteLine("Three letter Matches: " + threeLetterMatches);
               Console.WriteLine("Checksum is: " + twoLetterMatches * threeLetterMatches);
               Console.ReadLine();


               // Question 2
               var matchFound = false;
               

               // TODO: See if we can use linq for this?
               // Loop through all of the lines
               foreach (var line in input)
               {
                    var lineArray = line.ToCharArray();

                    // Loop through each line again because we want to compare all of the lines against each other
                    foreach (var compareLine in input)
                    {
                         var match = 0;
                         var compareLineArray = compareLine.ToCharArray();

                         // At this point each line is converted to a char array so we just want to count how matches are in each word
                         for (int i = 0; i < compareLineArray.Length; i++)
                         {
                              if (compareLineArray[i] == lineArray[i]) match++;
                         }

                         // If our matches are 1 less than the count of the word then we found the matches
                         // TODO: actually print out the answer instead of the two matches
                         if (match == (compareLineArray.Length - 1))
                         {
                              Console.WriteLine("First Match: " + compareLine);
                              Console.WriteLine("Second Match: " + line);
                              matchFound = true;
                         }
                    }

                    // IF we found a match, quit. We have what we need
                    if (matchFound) break;
               }

               Console.ReadLine();
          }
     }
}
