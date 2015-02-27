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
        private int _words;
        public int Words { get { return _words; } set { _words = value; } }

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
        private List<string> _getsentences;
        public List<string> GetSentences { get { return _getsentences; } set { _getsentences = value; } }

        //Regex pattern used to determine the end of a paragraph
        private static Regex EndParagraph = new Regex(@"\n\n");

        /// <summary>
        /// Default constructor for the paragraph class
        /// </summary>
        public Paragraph()
        {
            //This initializes everything in the class
            Sentences = 0;
            Words = 0;
            Length = 0;
            FirstToken = "";
            LastToken = "";
        } //end of the default constructor

        /// <summary>
        /// Parameterized constructor for the paragraph class
        /// </summary>
        /// <param name="text">The object that holds the tokenized input</param>
        public Paragraph(Text text)
        {
            _sentences = GetSentences.Count;
            FirstToken = GetSentences[0];
        } //end of the parameterized constructor

        /// <summary>
        /// The overriding method that returns the formatted result
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            string str = "";

            return str;
        } //end of overriding ToString method
    } //end of class
} //end of namespace