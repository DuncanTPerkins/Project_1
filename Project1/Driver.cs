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
    class Driver
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Title = "Menu Demonstration Application";

            Menu menu = new Menu("Menu Demo");
            menu = menu + "Open a file" + "Edit the file" + "Close the file" + "Quit";

            Choices choice = (Choices)menu.GetChoice();
            while (choice != Choices.QUIT)
            {
                switch (choice)
                {
                    case Choices.OPEN:
                        Console.WriteLine("You selected Open");
                        Console.ReadKey();
                        break;

                    case Choices.EDIT:
                        Console.WriteLine("You selected Edit");
                        Console.ReadKey();
                        break;

                    case Choices.CLOSE:
                        Console.WriteLine("You selected Close");
                        Console.ReadKey();
                        break;
                }  // end of switch

                choice = (Choices)menu.GetChoice();
            }  // end of while

        }
        }
    }

