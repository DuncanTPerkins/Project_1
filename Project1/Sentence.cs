//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		Sentence.cs
//	Description:    Converts text files into tokens
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Duncan Perkins, perkinsdt@goldmail.etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Tuesday, February 23rd, 2015
//	Copyright:		Duncan Perkins, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Project1
{
    /// <summary>
    /// Class for parsing Sentence from tokens 
    /// </summary>
    class Sentence 
    {
        //public and private variables for the number of tokens counted
        public int WordCount { get { return _wordcount; } set { _wordcount = value; } }
        private int _wordcount;

        //public and private variables for Average Length of tokens
        //we round the Average number when we take it in because otherwise it's unwieldy
        public Double AverageLength { get { return _averagelength; } set { _averagelength = Math.Round(value, 1, MidpointRounding.AwayFromZero); } }
        private Double _averagelength;

        //public and private variables for storage of the first token extracted
        public string FirstToken { get { return _firsttoken; } set { _firsttoken = value; } }
        private string _firsttoken;

        //public and private variables for storage of the last token extracted
        public string LastToken { get { return _lasttoken; } set { _lasttoken = value; } }
        private string _lasttoken;

        //public and private variables for storage of the sentence as we manipulate it based upon our parameters
        public List<string> SentenceList { get { return _sentencelist; } set { _sentencelist = value; } }
        private List<string> _sentencelist;

        //private counter for finding the location of the first sentence-ending token (.!?)
        private static int _counter;

        //Regular Expression for matching against a sentence-ending token (.!?)
        private static Regex EndSentence = new Regex(@"[\?\.!]");

        //Regular Expression for matching against any Letter, Number, 
        //or Underscore for the purpose of spacing the sentence correctly when .ToString is called
        private static Regex isLetter = new Regex(@"^[a-zA-Z0-9_]+$");

        //An instance of the match class for matching against Regular Expressions
        private static Match match;

        /// <summary>
        /// default constructor for Sentence class. Initializes everything to empty.
        /// </summary>
        public Sentence()
        {
            WordCount = 0;
            AverageLength = 0;
            FirstToken = "";
            LastToken = "";
            SentenceList = null;
            _counter = 0;
        } //end constructor

        /// <summary>
        /// Constructor for Sentence class
        /// </summary>
        /// <param name="text">An instance of the Text object that contains tokenized input from a text file</param>
        /// <param name="StartingToken">The location index of the Beginning of a sentence in the Text object's List of Tokens</param>
        public Sentence(Text text, int StartingToken)
        {
                //retrieve tokens from text class 
                SentenceList = text.Tokens;
                //get length of current list 
                int ListSize = (SentenceList.Count);
                //subtract the starting position of the sentence that was passed to us 
                int NewListSize = ((ListSize) - (StartingToken));
                //Cut the beginning of the token list to the StartingToken index
                SentenceList = SentenceList.GetRange(StartingToken, NewListSize);
                //initialize counter
                _counter = 0;
                //loop for finding sentencing-ending tokens (.!?)
                foreach (string s in SentenceList)
                {
                    //Compare the current index list item to the Regular Expression
                    match = EndSentence.Match(s);
                    //if it's a match
                    if (match.Success)
                    {
                        //we found the first sentence-ending token (.?!)
                        //increment counter by one and break from loop
                        _counter++;
                        break;
                    }
                    else
                    {
                        //increment counter by one and go to next list item
                        _counter++;
                    } //end else 
                } //end foreach

                //trim the end of our sentence list to the index of the first sentence-ending token (.?!)
                SentenceList = SentenceList.GetRange(0, _counter);
                //Get Word Count, Average Length, and First and Last tokens
                GetMetrics();
            

            
        } //end constructor

        /// <summary>
        /// Calculate Word Count, Average Word Length, and First and Last Tokens of the Sentence
        /// </summary>
        public void GetMetrics()
        {
            //Get length of Sentence
            WordCount = SentenceList.Count;
            //Get average from GetAverage method
            AverageLength = GetAverage();
            //token at 0 index is first token
            FirstToken = SentenceList[0];
            //token at max index is last token
            LastToken = (SentenceList[SentenceList.Count-1]);
        }//end method 

        /// <summary>
        /// Calculate Average Word Length of Sentence 
        /// </summary>
        /// <returns></returns>
        public double GetAverage()
        {   //initialize average to 0
            double average = 0;
            //for every token in the sentence, add the length of the token to average...
            foreach (string s in SentenceList)
            {
                average += s.Length;
            } //end foreach

            //...and then divide by total number of tokens 
            average /= SentenceList.Count;

            //return average
            return average;
        }//end method

        /// <summary>
        /// Prints out Sentence with metrics in easy to read manner
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            //initialize string to empty
            string str = "";
            //for every token in the Sentence 
            foreach (string s in SentenceList)
            {
                //Compare token against Regular Expression to check if it's a Letter or Number
                match = isLetter.Match(s);
                //if the token IS a letter or number, AND we aren't on the first iteration...
                if (match.Success && str!=s)
                {
                    //...append a space 
                    str += " ";
                } //end if 
                //append the token
                str += s;    
                
            }//end foreach

            //append Word Count to String 
            str+="\n\nTotal Words: " + WordCount + "             " + "Average Word Length: " + AverageLength;

            //trim leading and trailing white spaces when returning Sentence
            return str;
        } //end method 
    } //end class
} //end namespace