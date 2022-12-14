WCK- The point of the exercise was to think the problem out before coding it. To take time to understand the requirements 
by doing a design, to define test cases and test data, etc. 
You have a rough design and some test cases.
	
You declare but don't initialize variables (required reading said don't do this). 
You have a "while(true)" loop that you use "break" to end. This is not good practice. 
If I enter two max int values they pass your parse test but will overflow when you add them together (this was a test case I provided during class). 
You have no validation for this. 
You have multiple return statements for the same method which the required reading says don't do this. 
You don't explain what LSB means. Your comments in LSB are so long I had to edit the file to see them. 
The "if (num6 < 10) is redundant with the "if (num3 < 10)" . You should just call LSB again at this point. 
Why do you treat negative numbers differently. This should be explained in the comments. 
Also, your variable names should be more descriptive, e.g. "remainder" or "leastSigDigit" instead of "num4". 
I don't see anything for stack overflow (another test case I provided in class). 
	
												  
												  
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *      Authors: Hunter Gilliam
 *               Joshua Thomas
 *      Date: 09/27/2022
 *      Assignment: Recursive Program
 *      Description: 2 user inputs until single digit
 * 
 */
/*
In todays exercise we are tasked with implementing a problem. The problem is as follows.

Recursively take two user inputted numbers and add them together then take the lsb away and add it to the remaining digits until you are left with one digit.

1.Initially the program will prompt for user input with error catching to ensure that it ends up with an integer. 


2.Once we have procured both of our numbers then we will add them together and ensure it is not a single digit number already

	2a.if it is a single digit number then we will be done and have the final solution

	2b.if it is not a single digit number then we will begin to Mod 10 to get the lsb and then add it back to the number after removing the lsb from the number.
		3.After each loop check to make sure that the number is not a single digit one and if it is then exit the loop.
	


Test Cases
Letters: Works throws exception.
Decimals: Works throws exception.
Normal numbers: work moves through solution.
Negatives: Work moves through solution.
Random keys: Works throws exception probably.
 */
namespace RecursiveNumberSeperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2; //initialize ints
            int num3;
            int finalOutput = new int();   WCK- why initialize this one and not the others ones?
            
             // Collects the first integer and error checks it
            Console.WriteLine("Enter the First Integer please: ");
            while(true)   WCK- THIS IS BAD PRACTICE
            {
                if (!int.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Number inputted is invalid\nPlease input a new integer:");
                }
                else
                {
                    break;
                }
            }
            //collects the second integer and error checks it
            Console.WriteLine("Enter the Second Integer please: ");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Number inputted is invalid\nPlease input a new integer");
                }
                else
                {
                    break;
                }
            }
            //Console.WriteLine($"{num1} {num2}");
            //Console.ReadLine();     TESTING LINES***
            num3 = num1 + num2; //ADDS user integers together
            finalOutput = LSB(num3);   // Runs recursive method

            Console.WriteLine($"{finalOutput} This is the final ouput\nPress enter to continue");
            Console.ReadLine();

        }
        public static int LSB(int num3)
        {
            // If else block which checks the int to be over or under 0 then collects the least significant bit. Once it hits one digit it ends and returns the int.
            //If it is not a single digit it will run again this has multiple layers of checks to make sure it stops at the proper time.
            
            Console.WriteLine($"The current number is : {num3}");
            if(num3 >0)
            {
                if(num3 <10)
                {
                    
                    return num3;
                }
                else
                {
                    int num4;
                    int num5;
                    int num6;
                    num4 = num3 % 10;
                    num5 = (num3 - num4) / 10;
                    num6 = (num5 + num4);
                    if(num6 <10)
                    {
                        
                        return num6;
                    }
                    else
                    {
                        return LSB(num6);
                    }
                    
                    
                }
            }
            else
            {
                if(num3 > -10)
                {
                    
                    return num3;
                }
                else
                {
                    int num4;
                    int num5;
                    int num6;
                    num4 = num3 % -10;
                    num5 = (num3 - num4) / 10;
                    num6 = (num5 + num4);
                    if (num6 > -10)
                    {
                        
                        return num6;
                    }
                    else
                    {
                        return LSB(num6);
                    }
                }
            }
        }
    }
}
