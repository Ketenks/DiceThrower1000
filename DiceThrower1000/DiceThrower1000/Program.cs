using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceThrower1000
{
    class Program
    {
        static void Main(string[] args)
        {
            //CALLING FUNCTIONS
            Console.WriteLine("CALLING FUNCTIONS********");
            Console.WriteLine();

            Console.WriteLine("THROW THAT DICE!");
            Console.WriteLine();
            ThrowDice("10d6");
            Console.WriteLine();
            ThrowDice("3d20");
            Console.WriteLine();
            ThrowDice("100d6");
            Console.WriteLine();
            Console.WriteLine("Format Test Zone");
            Console.WriteLine();
            ThrowDice("this is not correct format");

            //keeps console open until key is pressed
            Console.ReadKey();
        }
        //BEGIN FUNCTION DECLARATION

        //for input format of "int1" + "d" + "int2" roll a die; 
        //where int1 is number of rolls and int2 is number of faces of die
        static void ThrowDice(string diceString)
        {
            //set parameter to an input the user chooses
            diceString = Console.ReadLine();

            //declare function variables           
            string string1 = "";                     
            string stringD = "";           
            string string2 = "";
            


            //condition for correct format of diceString
            for (int i = 0; i < diceString.Length; i++)
            {
                if("0123456789".Contains(diceString[i])) 
                {                                
                        string1 += diceString[i];
                    
                }else
                {
                    stringD += diceString[i];
                }
                if (stringD == "d")
                {
                    for (int j = i; j < diceString.Length; j++)
                    {
                        if ("0123456789".Contains(diceString[j]))
                        {
                            string2 += diceString[j];
                        }                       
                    }
                    break;
                }                
            }
            
            //condition to run data conversion for correct format
            if (string1.Length > 0 && string2.Length > 0 && stringD == "d")
            {
                //now the actual function for the two numbers can begin: 
                //number1 is the number of rolls and number2 is the number of faces of the die

                //actual variables used for the math of the function
                int number1 = Convert.ToInt32(string1);
                int number2 = Convert.ToInt32(string2);

                //random number generator and the associated die roll for the number of faces
                Random randomNumberGenerator = new Random();
                int totalRoll = 0;
               var dieRollList = new List<int>();
                
                
                
                //final output
                Console.WriteLine("Throwing: " + number1 + stringD + number2);

                //for loop to write the results
                Console.Write("Results: ");
                for (int i = 0; i < number1; i++)
                {
                    int dieRoll = randomNumberGenerator.Next(1, (number2 + 1));
                    totalRoll += dieRoll;
                    dieRollList.Add(dieRoll);
                    Console.Write(i + 1 + " 0" + dieRoll + " | ");

                }
                //make a new line from for loop
                Console.WriteLine();

                //make average after for loop changes
                int averageRoll = totalRoll / number2;
                var top3 = dieRollList.OrderByDescending(x => x).Take(3).ToList();
                var bottom3 = dieRollList.OrderBy(x => x).Take(3).ToList();
                string bot3 = string.Join(", ", bottom3);
                string topS3 = string.Join(", ", top3);

                
                //EXTRA CREDIT!!!!!!!!!
                Console.WriteLine();
                Console.WriteLine("Statistics\n----------");
                Console.WriteLine("Average Roll: " + averageRoll);
                Console.WriteLine("Top 3 Rolls: " + topS3);
                Console.WriteLine("Bottom 3 Rolls: " + bot3);

                //make a space between function calls
                Console.WriteLine();

                //var l2 = new List<string>();
                //var results = l2.Where(x => x.unitPrice < search);

                //var dieRollList = new List<int>();
                //var top3 = list.OrderByDescending(x => x).Take(3);
                //var bot3 = list.OrderBy(x => x).Take(3);
                
            }
            else
            {
                Console.WriteLine("Sorry, the input was not in the correct format.");
                Console.WriteLine("The correct format is a single string started by an integer");
                Console.WriteLine("representing the number of rolls of the die");
                Console.WriteLine("followed by the letter 'd' and then followed by another integer");
                Console.WriteLine("representing the number of faces for that die.\n");
                Console.WriteLine("Example: \"INTdINT\"\n");
                Console.WriteLine("Thank you and try again.");
            }
                     
        }
    }
}
