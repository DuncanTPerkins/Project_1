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

        //Variables for the humber of words
        public int Words
        {
            get
            {
                int gettercounter = 0;
                foreach (string s in GetParagraph)
                {
                    string delims = "?!,';:*(){}+-. ";
                    char[] charArray = delims.ToCharArray();
                    int IsntWord = s.IndexOfAny(charArray);
                    if (IsntWord == 1)
                    {
                        gettercounter++;
                        break;
                    }
                    else
                    {
                        gettercounter++;
                    }
                }
                return gettercounter;
            }
        }

        //Variables for the length of words in the sentence
        private double _length;
        private double Length { get { return _length; } set { _length = value; } }

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
        private static Regex EndParagraph = new Regex("\n{2}|\r{2}");

        private static Regex EndSentence = new Regex(@"[\?\.!]");

        private static Match match;
        private static int EndingIndex;
        /// <summary>
        /// Default constructor for the paragraph class
        /// </summary>
        public Paragraph()
        {
            //This initializes everything in the class
            Sentences = 0;
            Length = 0;
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
            GetParagraph = text.Tokens;

            //Sets the first token
            FirstToken = GetParagraph[0];

            int counter = 0;
            foreach (string s in GetParagraph)
            {
                match = EndParagraph.Match(s);
                if (match.Success)
                {
                    //end of paragraph
                    EndingIndex = counter;
                    break;
                }               
                counter++;
            }
            GetParagraph = GetParagraph.GetRange(0, EndingIndex);
            //Counts the number of sentences in the paragraph
            _sentences = GetParagraph.Count;
        } //end of the parameterized constructor

        public int GetStats()
        {
            int counter = 0;
            foreach(string s in GetParagraph)
            {
                //if it's the end of a sentence
                match = EndSentence.Match(s);
                if (match.Success) {
                    counter++;
                    Console.WriteLine("kek");
                } 
            }
            Length = GetParagraph.Count / counter;
            return counter;
        }

        /// <summary>
        /// The overriding method that returns the formatted result
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            string str = "Total Sentences:" + GetStats() + "     " + "Average Words Per Sentence: " + Length;
            return str;
        } //end of overriding ToString method

    } //end of class
} //end of namespace