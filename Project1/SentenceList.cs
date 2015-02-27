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
        public int SentencesCount { get { return Sentences.Count; } }
        public double AverageLength {
            get {
                int count = 0;
                foreach (Sentence s in Sentences) {
                    count += s.GetTotalLength();
                }
                return count;
            }
            
        }

        public SentenceList()
        {
            Sentences = null;
        }

        public SentenceList(Text text) {
            Sentence sentence = new Sentence(text, 0);
            Sentences.Add(sentence);
        }

        public void AddSentence(Sentence s) {
            Sentences.Add(s);  
        }

        public void Display() {
            Console.WriteLine("Sentences Found in the Text:\n");
            for (int i = 0; i < Sentences.Count; i++) {
                Console.WriteLine("Sentence " + (i + 1) + "\n");
                Console.WriteLine(Sentences[i].ToString());
            }
        }
        

    }
    
}
