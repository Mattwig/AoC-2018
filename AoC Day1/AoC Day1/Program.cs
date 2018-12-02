using System;
using System.IO;
using System.Collections.Generic;

namespace AoC_Day1
{
     class Program
     {
          static void Main(string[] args)
          {
               // Load the data from the first puzzle
               var data = File.ReadAllLines(@"puzzleInput.txt");

               // Create a hashset for the frequencies
               HashSet<int> frequencies = new HashSet<int>();

               // Initialize some data
               var frequency = 0;
               var notFound = true;
               var numRuns = 0;               

               while (notFound)
               {
                    foreach (var line in data)
                    {
                         // Convert the line to an int 
                         var num = Convert.ToInt32(line);

                         // Add it to the current frequency
                         frequency += num;

                         // Check to see if we have the current frequency
                         if (frequencies.Contains(frequency))
                         {
                              // We found it so write it out
                              Console.WriteLine("First Duplicate: " + frequency);

                              // Break the while and foreach loops
                              notFound = false;
                              break;
                         }

                         // Add the feequency to the list so we can get it later
                         frequencies.Add(frequency);
                    }

                    // Increment the run
                    numRuns += 1;

                    // This is the answer for the first task
                    if (numRuns == 1) Console.WriteLine(frequency);
                    
                    // Write out the number of runs so we don't go crazy waiting for an output
                    Console.WriteLine("Ran through list " + numRuns + " times.");
                    
               }               

               // Readline at the end so we can get the value
               Console.ReadLine();
          }
     }
}
