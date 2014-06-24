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

                //for some reason, dieRoll has a fixed random value. once it is evaluated it doesn't change in my for loop below
                //so i put it there
               // int dieRoll = randomNumberGenerator.Next(1, (number2 + 1));
                
                
                //final output
                Console.WriteLine("Throwing: " + number1 + stringD + number2);

                //for loop to write the results
                Console.Write("Results: ");
                for (int i = 0; i < number1; i++)
                {
                    int dieRoll = randomNumberGenerator.Next(1, (number2 + 1));
                    Console.Write("0" + dieRoll + " | ");
                }

                //make a space between function calls
                Console.WriteLine();


               
                
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
