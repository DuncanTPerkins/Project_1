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
    class Paragraph
    {
        private int _sentences;
        public int Sentences { get { return _sentences; } set { _sentences = value; } }

        private int _words;
        public int Words { get { return _words; } set { _words = value; } }

        private double _length;
        private double Length { get { return _length; } set { _length = value; } }

        public string FirstToken { get { return _firstToken; } set { _firstToken = value; } }
        private string _firstToken;

        public string LastToken { get { return _lastToken; } set { _lastToken = value; } }
        private string _lastToken;

        public List<string> SentenceList { get { return _sentencelist; } set { _sentencelist = value; } }
        private List<string> _sentencelist;

        private static Regex EndSentence = new Regex(@"[\?\.!]");

        public Paragraph()
        {
            Sentences = 0;
            Words = 0;
            Length = 0;
            FirstToken = "";
            LastToken = "";
        }

        public Paragraph(Text text)
        {
            SentenceList = text.Tokens;
            foreach(string s in SentenceList)
            {
                _sentences++;
            }
        }

        public override String ToString()
        {
            string str = "";

            return str;
        }
    }
}
