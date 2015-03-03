//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		Utility.cs
//	Description:    Holds various static methods to be used throughout the project
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Chance Reichenberg, reichenberg@etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Thursday, February 15, 2015
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
        public static void WelcomeMessage(string caption = "Computer Science 2210", string author = "", string author2 = "", string author3 = "")
        {
            Console.WriteLine("{0}:\n {1},{2},{3}", caption, author, author2, author3);
        }//End Method

        /// <summary>
        /// A Goodbye message that can be displayed
        /// </summary>
        /// <param name="msg">The message to be displayed</param>
        public static void GoodbyeMessage(string msg = "Thank you for using this program.")
        {
            Console.WriteLine(msg);
        }//End Method

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
        }//End Method

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
        }//End Method

        /// <summary>
        /// Splits a string into a list of the tokens that made it.
        /// </summary>
        /// <param name="original">The string to be tokenized</param>
        /// <param name="delimiters">The delimters that will be used to split the string</param>
        /// <returns>A list of tokens found in the given string</returns>
        public static List<string> Tokenize(string line, string delims)
        {
            List<string> tokenizedLine = new List<string>();


            char[] delimArray = delims.ToCharArray();
            int endingIndex = 0;
            int startingIndex = 0;
            string subStringToAdd;

            //Loops through the String until the ending index reaches the end meaning it found no delims
            while (endingIndex != -1)
            {
                endingIndex = line.IndexOfAny(delimArray, startingIndex);   //Finds the index of the next delimeter

                if (endingIndex != -1)
                {
                    int stringLength = endingIndex - startingIndex;         //Gets the length of the string to be cut

                    //Cuts out the substring and checks to see if it is empty or not before adding
                    subStringToAdd = line.Substring(startingIndex, stringLength);
                    if (!String.IsNullOrWhiteSpace(subStringToAdd) && !String.IsNullOrEmpty(subStringToAdd))
                    {
                        tokenizedLine.Add(subStringToAdd);
                    }//End If

                    //Used to add punctuation marks and delete empty spaces between words
                    subStringToAdd = line.Substring(endingIndex, 1);
                    if (!String.IsNullOrWhiteSpace(subStringToAdd) && !String.IsNullOrEmpty(subStringToAdd))
                    {
                        tokenizedLine.Add(subStringToAdd);
                    }//End If

                    startingIndex = endingIndex + 1;
                }//End if
                else            //Adds the final string of the original string to the list of tokens
                {
                    int length = line.Length - startingIndex;
                    tokenizedLine.Add(line.Substring(startingIndex, length));
                }//End if

            }//End While

            //Takes care of newline, tab, and return characters.
            for (int i = 0; i < tokenizedLine.Count; i++)
            {
                if (tokenizedLine[i] == "n" || tokenizedLine[i] == "r" || tokenizedLine[i] == "t")
                {
                    tokenizedLine[i] = '\\' + tokenizedLine[i];
                    tokenizedLine.Remove(tokenizedLine[i - 1]);
                }//End if


            }//End For

            return tokenizedLine;
        }//End Tokenize
    }
}
