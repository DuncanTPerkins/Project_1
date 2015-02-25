//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		SentenceList.cs
//	Description:    Converts text files into tokens
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Duncan Perkins, perkinsdt@goldmail.etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Thursday, February 15, 2015
//	Copyright:		Duncan Perkins, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class SentenceList
    {
        public List<Sentence> Sentences { get { return _sentences; } set { _sentences = value; } }
        private List<Sentence> _sentences;
        public int SentencesCount { get { return _sentencescount; } set { _sentencescount = value; } }
        private int _sentencescount;
        public double AverageLength { get { return _averagelength; } set { _averagelength = value; } }
        private double _averagelength;

        public SentenceList()
        {
            Sentences = null;
            SentencesCount = 0;
            AverageLength = 0;
        }
    

    
    
    }
    
}
