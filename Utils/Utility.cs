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
            Skip(4);
            Console.WriteLine("\t{0}:\n\t\tBy: {1},{2},{3}", caption, author, author2, author3);
            Skip(1);
            Console.WriteLine("\tPress Enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }//End Method

        /// <summary>
        /// A Goodbye message that can be displayed
        /// </summary>
        /// <param name="msg">The message to be displayed</param>
        public static void GoodbyeMessage(string msg = "Thank you for using this program!")
        {
            Skip(3);
            Console.WriteLine(String.Format("\t\t{0}", msg));
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

            string work = line;

            char[] delimArray = delims.ToCharArray();
            List<char> temp = delimArray.ToList();
            int endingIndex = 0;
            string subStringToAdd;

            //Loops through until work is empty
            while (!String.IsNullOrEmpty(work))
            {
                int tempIndex1 = work.IndexOfAny(delimArray);
                int tempIndex2 = work.IndexOf("\r\n");

                //Gets the closest index of the delimiter that is found
                if (tempIndex1 == -1)
                {
                    endingIndex = tempIndex2;
                }
                else if (tempIndex2 == -1)
                {
                    endingIndex = tempIndex1;
                }
                else
                    endingIndex = (tempIndex1 < tempIndex2) ? tempIndex1 : tempIndex2;  //Ternary expression to retreive lowest index if they arent both -1
                //End If


                if (endingIndex != -1)
                {
                    subStringToAdd = work.Substring(0, endingIndex);

                    //Checks if the string is null of empty before adding
                    if (!String.IsNullOrEmpty(subStringToAdd) && !String.IsNullOrWhiteSpace(subStringToAdd))
                    {
                        tokenizedLine.Add(subStringToAdd);
                    }
                    else if (subStringToAdd == "\r" || subStringToAdd == "\n")  //If it is a carraige return or newline add it
                    {
                        tokenizedLine.Add(subStringToAdd);
                        subStringToAdd = work.Substring(endingIndex, 1);
                        while (subStringToAdd == "\r" || subStringToAdd == "\n")    //keep adding these until there are no more newline or carraige returns in the sequence
                        {
                            tokenizedLine.Add(subStringToAdd);
                            endingIndex += 1;
                            subStringToAdd = work.Substring(endingIndex, 1);
                        }//End while
                    }//End if

                    subStringToAdd = work.Substring(endingIndex, 1);

                    //Again checks if the string is null or empty and removes it if it's a space
                    if (!String.IsNullOrEmpty(subStringToAdd) && !String.IsNullOrWhiteSpace(subStringToAdd))
                    {
                        tokenizedLine.Add(subStringToAdd);
                        work = work.Substring(endingIndex + 1);
                    }
                    else if (subStringToAdd == "\r" || subStringToAdd == "\n")
                    {
                        while (subStringToAdd == "\r" || subStringToAdd == "\n")
                        {
                            tokenizedLine.Add(subStringToAdd);
                            endingIndex += 1;
                            subStringToAdd = work.Substring(endingIndex, 1);
                        }//End While
                        work = work.Substring(endingIndex);
                    }
                    else
                    {
                        work = work.Substring(endingIndex + 1);
                    }//End If

                }//End If
                else
                {
                    tokenizedLine.Add(work);
                    work = "";
                }
            }//End While

            tokenizedLine = CarraigeReturnToNewline(tokenizedLine);

            return tokenizedLine;
        }//End Tokenize

        /// <summary>
        /// Replaces the carraige returns in a list with a single newline character
        /// </summary>
        /// <param name="tokens">The list to check</param>
        /// <returns>The list with the carraige returns replaced</returns>
        private static List<string> CarraigeReturnToNewline(List<string> tokens)
        {
            int startIndex = 0, endIndex = 0;
            bool clean = true;

            //Loops through the list of strings and finds the first occurence of a newline or carraige return
            //It then finds the last one in that sequence and replaces that group with a single newline.
            //It continues to do this until all multiple occurences have been replace with a single newline
            while (clean)
            {
                for (int i = startIndex + 1; i < tokens.Count; i++)
                {
                    if (tokens[i] == "\r" || tokens[i] == "\n")
                    {
                        startIndex = i;
                        for (int c = i; c < tokens.Count; c++)
                        {
                            if (tokens[c] != "\n" && tokens[c] != "\r")
                            {
                                endIndex = c;
                                tokens = Replace(tokens, startIndex, endIndex - startIndex, "\n");
                                break;
                            }//end if
                        }//end for
                        clean = true;
                        break;
                    }
                    else
                    {
                        clean = false;
                    }//end if
                }//end for


            }//End while
            return tokens;
        }//end CarraigeReturnToNewline

        /// <summary>
        /// Replaces a specified range in a list with the given string
        /// </summary>
        /// <param name="listToReplace">List that will have a range replaced</param>
        /// <param name="startIndex">Starting index for the range</param>
        /// <param name="rangeToReplace">The range of values to remove</param>
        /// <param name="toInsert">The string to be inserted into that range</param>
        /// <returns>The list with the range replaced</returns>
        private static List<string> Replace(List<string> listToReplace, int startIndex, int rangeToReplace, string toInsert)
        {
            listToReplace.RemoveRange(startIndex, rangeToReplace);
            listToReplace.Insert(startIndex, toInsert);
            return listToReplace;
        }// end Replace
    }
}
