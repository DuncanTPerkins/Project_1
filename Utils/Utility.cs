//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		Utility.cs
//	Description:    Holds various static methods to be used throughout the project
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Chance Reichenberg, reichenberg@etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Thursday, February 5, 2015
//	Copyright:		Chance Reichenberg, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// A static Utility class that can be implemented in various projects
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Welcome message that can be displayed in the console window
        /// </summary>
        /// <param name="caption">The Message to be displayed</param>
        /// <param name="author">The author of the program</param>
        public static void WelcomeMessage(string caption = "Computer Science 2210", string author = "Chance Reichenberg")
        {
            Console.WriteLine("{0}: {1}", caption, author);
        }

        /// <summary>
        /// A Goodbye message that can be displayed
        /// </summary>
        /// <param name="msg">The message to be displayed</param>
        public static void GoodbyeMessage(string msg = "Thank you for using this program.")
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Skips a number os lines in the console window
        /// </summary>
        /// <param name="num">The number of lines to skip</param>
        public static void Skip(int num = 1)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("\n");

            }
        }

        /// <summary>
        /// Formats an entered string by placing it between entered margins
        /// </summary>
        /// <param name="txt">The string to be formatted</param>
        /// <param name="leftMargin">Left margin of the string</param>
        /// <param name="rightMargin">Right margin of the string </param>
        /// <returns>A formatted string the lies between the margins</returns>
        public static string FormatText(string txt, int leftMargin = 0, int rightMargin = 80)
        {

            return String.Format("{0}{1}", "".PadLeft(leftMargin),txt.PadRight(rightMargin - leftMargin));
        }


        public static List<String> Tokenize(string original, string delimiters)
        {
            //List for Taking apart the string
            List<String> list = new List<String>();

            //String to perform the cutting on
            String CompareString = original;

            //infinite loop for String cutting
            while (true)
            {

                //get the index of the earliest delimeter 
                int index = CompareString.IndexOfAny(delimiters.ToCharArray());

                //if there aren't any, break out of the loop
                if (index < 0) { break; }

                //if a delimeter is found, 
                else
                {
                    CompareString.Trim();
                    //add the characters
                    list.Add(CompareString.Substring(0, index));

                    //add the delimiter
                    if (string.IsNullOrWhiteSpace(CompareString.Substring(index, 1)))
                    {
                        //don't add the delimiter if it's a space
                    }
                    else
                    {
                        list.Add(CompareString.Substring(index, 1));
                    }
                    //resize the compared string
                    CompareString = CompareString.Substring(index + 1);
                }
            }//end loop6


            for (var i = 0; i < list.Count; i++)
            {
                if(string.IsNullOrWhiteSpace(list[i])) {list.Remove(list[i]);}

            }
            //return list of tokens
            return list;

        }
    }
}
