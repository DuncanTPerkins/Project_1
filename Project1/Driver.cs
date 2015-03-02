//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		Driver.cs
//	Description:    ?????
//	Course:			CSCI 2210-001 - Data Structures
//	Authors:		Chance Reichenberg, reichenberg@etsu.edu, Duncan Perkins, perkinsdt@goldmail.etsu.edu,  Department of Computing, East Tennessee State University
//	Created:	    Thursday, February 5, 2015
//	Copyright:		Chance Reichenberg, Duncan Perkins 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
namespace Project1
{
    /// <summary>
    /// Driver class for Project 1 
    /// </summary>
    class Driver
    {
        /// <summary>
        /// Main method to demonstrate various classes and functionality of Project 1
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Title = "Project 1";

            Text textData;
            Menu menu = new Menu("Project 1 Options");

            menu = menu + "Words from the file" + "Sentences from the file" + "Paragraphs from the file" + "Quit";

            string line, inputText;
            int textChoice;
            Choices choice = (Choices)menu.GetChoice();

            while (choice != Choices.QUIT)
            {
                switch (choice)
                {
                    //Case that displays Distinct Word and Words classes
                    case Choices.WORDS:


                        Console.WriteLine("Enter a '0' if you wish to open a file. Enter '1' if you wish to enter a text string.");
                        line = Console.ReadLine();

                        while(!Int32.TryParse(line, out textChoice) || Int32.Parse(line) < 0 || Int32.Parse(line) > 1)
                        {
                            Console.WriteLine("You did not enter a '0' or '1'. Try Again.");
                            line = Console.ReadLine();
                        }//End While

                        if (textChoice == 0)
                        {
                            textData = new Text();
                            
                        }
                        else
                        {
                            Console.WriteLine("Please enter the string you wish to evaluate below.");
                            inputText = Console.ReadLine();
                            textData = new Text(inputText, 1);
                        }
                        Words textWords = new Words(textData);
                        textWords.Display();
                        foreach(var item in textData.Tokens)
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;

                    case Choices.SENTENCES:
                        Console.WriteLine("You selected Close");
                        Console.ReadKey();
                        break;
                    case Choices.PARAGRAPHS:
                        Console.WriteLine("You selected Close");
                        Console.ReadKey();
                        break;
                }  // end of switch

                choice = (Choices)menu.GetChoice();
            }  // end of while

            //Console.WriteLine("Input Text to be Parsed");
            //string input = Console.ReadLine();
            //Text t = new Text(input, 1);
            //SentenceList s = new SentenceList(t);
            //s.Display();

            //Text test = new Text();
            //test.GetTokens();
            //Paragraph p = new Paragraph(test);
            //Console.WriteLine(p.ToString());
            //Console.ReadLine();
        }
        }
    }

