using System;
using System.Collections.Generic;

namespace ChemicalApp 
{
    class Program
    {
        //Gobal Variables
        static List<string> chemicalNames = new List<string>();
        static List<decimal> chemicalEfficiencies = new List<decimal>();
        //Methods

        static void SortChemicals()
        {
            for (int outer = 0; outer < chemicalEfficiencies.Count - 1; outer++)
            {
                for (int inner = outer+1; inner < chemicalEfficiencies.Count; inner++) 
                {
                    if (chemicalEfficiencies[outer] > chemicalEfficiencies[inner]) 
                    {
                        decimal tempEfficiency = chemicalEfficiencies[outer];
                        chemicalEfficiencies[outer] = chemicalEfficiencies[inner];
                        chemicalEfficiencies[inner] = tempEfficiency;

                        string tempName = chemicalNames[outer];
                        chemicalNames[outer] = chemicalNames[inner];
                            chemicalNames[inner] = tempName;
                    }
                }
            }
        }

        //checking if chemical has been tested
        static string validateChemical()
        {
            while (true)
            {



                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n" +
                                    " Welcome to the testing phase. Please enter your chemical name\n" +
                                    "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");

                string chemicalName = Console.ReadLine();

                if (chemicalNames.Contains(chemicalName))
                {
                    Console.WriteLine("\n* * * * * * * * * * * * * * * * * * *\nThis chemical as already been tested\n* * * * * * * * * * * * * * * * * * *\n\n");
                }
                else
                {
                    return chemicalName;
                }


            }
        }

        //Creating efficiency rating
        static void ChemicalChoice()
        {
            
            chemicalNames.Add(validateChemical());

            decimal chemicalEfficiency;
            decimal sumChemEfficiencies = 0;

            for (int i = 0; i < 5; i++)
            {
              
                Random rndm = new Random();
                int startGermcount = rndm.Next(100, 150);
                decimal endGermCount = rndm.Next(0, startGermcount);


                chemicalEfficiency = (startGermcount - endGermCount) / 30;
                
                chemicalEfficiency = Math.Round(chemicalEfficiency, 3);

                sumChemEfficiencies += chemicalEfficiency;
                
                Console.WriteLine($"The efficiency rating is {chemicalEfficiency}\n");   
            
            }

            decimal efficiencyRating = sumChemEfficiencies / 5;
            chemicalEfficiencies.Add(Math.Round(efficiencyRating, 3)) ;
            Console.WriteLine($"= = = = = = = = = = = = = = = = \n The average of {chemicalNames[chemicalNames.Count-1]} was {efficiencyRating}\n= = = = = = = = = = = = = = = =\n\n ");


        }



        //Main Process or When Run

        static void Main(string[] args)
        {
            int menuChoice;
            bool flagMain = true;
            //Welcome Message
            Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~\n" +
                              "Welcome to the Best Chemical Testing Laboratory in Town\n" +
                              "~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~\n");


            //Menu
            while (flagMain)
            {
                Console.WriteLine("-------Main Menu-------\n   1.Test a chemical\n   2.Quit\n");
                menuChoice = Convert.ToInt32(Console.ReadLine());




                if (menuChoice == 1)
                {
                    ChemicalChoice();
                }
                else if (menuChoice == 2)
                {
                    flagMain = false;

                    SortChemicals();

                    Console.WriteLine("----Chemical ranking list----");
                    for (int i = 0; i < chemicalEfficiencies.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {chemicalNames[i]} {chemicalEfficiencies[i]}");
                    }
                    Console.WriteLine($"------------------------------------------------------------\n" +
                                      $"The most effective chemical was {chemicalNames[0]} with a rating of {chemicalEfficiencies[0]}" +
                                      $"\n------------------------------------------------------------\n");
                    Console.WriteLine($"------------------------------------------------------------\n" +
                                      $"The least effective chemical was {chemicalNames[chemicalNames.Count - 1]} with a rating {chemicalEfficiencies[chemicalEfficiencies.Count - 1]}" +
                                      $"\n------------------------------------------------------------\n");

                    Console.WriteLine("\nThanks for using Hi-Jean's Chemical testing App");
                }
                else if (menuChoice >= 3)
                {
                    Console.WriteLine("\n* * * * * * * * * * * * * *\nERROR:Input must be 1 or 2\n* * * * * * * * * * * * * *\n");
                }
                else if (menuChoice <= 0)
                {
                    Console.WriteLine("\n* * * * * * * * * * * * * *\nERROR:Input must be 1 or 2\n* * * * * * * * * * * * * *\n");
                }

            }

        }

    }

}
