//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		Paragraph.cs
//	Description:    Calculates the number of sentences and words in a paragraph
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Chris Harris, harriscr1@goldmail.etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Wednesday, February 24th, 2015
//	Copyright:		Chris Harris, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project1
{
    /// <summary>
    /// Class for returning the number of sentences and average words per sentence
    /// </summary>
    class Paragraph
    {
        //Variables for the number of sentences in the paragraph
        private int _sentences;
        public int Sentences { get { return _sentences; } set { _sentences = value; } }

        //Variables for the number of words
        public int Words
        {
            get
            {
                //Initialize the counter
                int gettercounter = 0;

                //Loops through the tokens counting any token that is not a delimiter
                foreach (string s in GetParagraph)
                {
                    match = IsLetter.Match(s);
                    if (match.Success)
                    {
                        gettercounter++;
                    }
                }
                return gettercounter;
            }
        }

        //Variables for the length of words in the sentence
        private double _averagelength;
        private double AverageLength { get { return _averagelength; } set { _averagelength = value; } }

        //Variables for the first token
        private string _firstToken;
        public string FirstToken { get { return _firstToken; } set { _firstToken = value; } }

        //Variables for the last token
        private string _lastToken;
        public string LastToken { get { return _lastToken; } set { _lastToken = value; } }
        
        //Variables for the list that will store the sentences
        private List<string> _getparagraph;
        public List<string> GetParagraph { get { return _getparagraph; } set { _getparagraph = value; } }

        //Regex pattern used to determine the end of a paragraph
        private static Regex EndParagraph = new Regex(@"\n{2}");

        //Regex pattern for checking the end of a sentence
        private static Regex EndSentence = new Regex("[?.!]");

        //Regex pattern for checking if it is a letter
        private static Regex IsLetter = new Regex(@"^[a-zA-Z0-9_]+$");

        //Regex pattern for checking if it is a word
        private static Regex IsWord = new Regex("\\w+");

        //Create the match object to perform matching using regular expressions
        private static Match match;

        //Variable used to store the ending index of the paragraph
        private static int EndingIndex;

        /// <summary>
        /// Default constructor for the paragraph class
        /// </summary>
        public Paragraph()
        {
            //This initializes everything in the class
            Sentences = 0;
            AverageLength = 0;
            FirstToken = "";
            LastToken = "";
            GetParagraph = null;

        } //end of the default constructor

        /// <summary>
        /// Parameterized constructor for the paragraph class
        /// </summary>
        /// <param name="text">The object that holds the tokenized input</param>
        public Paragraph(Text text)
        {
            //This populates the GetParagraph list with the tokens from the tokenize method
            GetParagraph = text.Tokens;

            //Sets the first token
            FirstToken = GetParagraph[0];

            //int counter = 0;
            for(int i =0; i < GetParagraph.Count; i++) 
            { 
                //Checks for the end of the paragraph using two new line characters, two carriage return characters or the end of the list
                if((GetParagraph[i] == "\\n" && GetParagraph[i+1] == "\\n") || (GetParagraph[i] == "\\r" && GetParagraph[i+1] == "\\r") || i + 1 == GetParagraph.Count)
                {
                    EndingIndex = i + 1;
                    break;
                } // end if
            } //end for

            //Cut out the tokens that are not in the paragraph
            GetParagraph = GetParagraph.GetRange(0, EndingIndex);

        } //end of the parameterized constructor

        /// <summary>
        /// Gets the number of sentences and assigns it to the sentences variable, also evaluates the average words per sentence.
        /// </summary>
        /// <returns>Number of Sentences</returns>
        public int GetStats()
        {
            int counter = 0;
            
            //Loops through the list checking for punctuation marks
            foreach(string s in GetParagraph)
            {
                //If it's the end of a sentence
                match = EndSentence.Match(s);
                if (match.Success) {
                    counter++;
                } //end if  
            } //end foreach

            //Assigns the value of counter (number of sentences) to Sentences
            Sentences = counter;

            //Divide the number of words by the sentences to get the average length
            AverageLength = (Words / Sentences);

            return Sentences;
        } //end method 

        /// <summary>
        /// The overriding method that returns the formatted result
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            //Initialize the string str as null
            string str = "";

            //Loops through the tokens adding spaces after words only if it is not the first token
            foreach (string s in GetParagraph)
            {
                //initalize match with Word Regex and current string token
                match = IsWord.Match(s);

                //if the match is a success and we aren't on the first token
                if (match.Success && s != FirstToken)
                {
                    //append a space to str (so the output looks nice)
                    str += " ";
                } //end if 

                //append the current token to the string 
                str += s;
            }//end method 

            //Sets the variable to display the stats needed
            str += "\n\n" + "Total Sentences: " + GetStats() + "     " + "Average Words Per Sentence: " + AverageLength;

            //Returns the string
            return str;
        } //end of overriding ToString method
    } //end of class
} //end of namespace