//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		SentenceList.cs
//	Description:    Holds a List of Sentence Objects
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
        //List for holding the Sentence objects
        public List<Sentence> Sentences;

        //number of sentences in List 
        public int SentencesCount { get { return Sentences.Count; } }// end property

        //Average Number of Words per Sentence object
        public double AverageLength
        {
            get
            {
                //initialize counter variable 
                double count = 0;

                //for each Sentence object s in Sentences List
                foreach (Sentence s in Sentences)
                {
                    //Count = Count + the total number of tokens in Sentence s that are words
                    count += s.GetTotalLength();
                }// end foreach loop
                count /= (SentencesCount - 1);
                return count;
            }// end getter 

        }// end property

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public SentenceList()
        {
            Sentences = null;
        }// end default constructor

        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="text">Text Object</param>
        public SentenceList(Text text)
        {
            //return index of each sentence object
            int ReturnIndex = 0;

            //initialize Sentences List 
            Sentences = new List<Sentence>();

            //while the return index is less than the total number of tokens in the Text object
            while (ReturnIndex < text.Tokens.Count)
            {

                //create a new Sentence object, passing in the Text object and the current starting Index 
                Sentence sentence = new Sentence(text, ReturnIndex);

                //add the new Sentence to the Sentences list 
                Sentences.Add(sentence);

                //Add the return index from the Sentence to the total Return Index for Sentence cutting
                ReturnIndex += sentence.ReturnIndex;
            }// end while 
        }// end parameterized constructor

        /// <summary>
        /// print out the Sentence objects and their stats
        /// </summary>
        public void Display()
        {
            //clear console 
            Console.Clear();

            //set console font color to red
            Console.ForegroundColor = ConsoleColor.Red;

            //initial print out message
            Console.WriteLine("Sentences Found in the Text:\n");

            //for every Sentence object in the Sentences List 
            for (int i = 0; i < Sentences.Count - 1; i++)
            {

                //console theming 
                Console.ForegroundColor = ConsoleColor.Red;

                //Append the Sentence number 
                Console.WriteLine("Sentence " + (i + 1) + "\n");

                Console.ForegroundColor = ConsoleColor.Blue;
                //Append the ToString method of the current Sentence object
                Console.WriteLine(Sentences[i].ToString());
            } // end for loop
            Console.ForegroundColor = ConsoleColor.Red;
            //Output total ending data
            Console.WriteLine("\n\nThere are " + (SentencesCount - 1) + " sentences with an average length of " + Math.Round(AverageLength, 1, MidpointRounding.AwayFromZero) + " words.");
        }// end method 


    }// end class

}// end namespace
