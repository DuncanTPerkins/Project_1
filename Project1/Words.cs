//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		Words.cs
//	Description:    Holds a list of distinct words for sorting and displaying
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Chance Reichenberg, reichenberg@etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Monday, February 23, 2015
//	Copyright:		Chance Reichenberg, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    /// <summary>
    /// Class used to display Distinct words found in a text file
    /// </summary>
    class Words
    {
        /// <summary>
        /// Public property that holds the distinct words
        /// </summary>
        public List<DistinctWord> DistinctWords { get; private set; }

        /// <summary>
        /// Public read-only property that holds the number of distinct words
        /// </summary>
        public int Count
        {
            get
            {
                return DistinctWords.Count;
            }
        }

        /// <summary>
        /// Default Constructor for the Words class
        /// </summary>
        public Words()
        {
            DistinctWords = null;
        }

        /// <summary>
        /// Parameterized constructor that takes a text object and puts the tokens into the list of Distinct words.
        /// </summary>
        /// <param name="words">Text object containing File text</param>
        public Words(Text words)
        {
            
            DistinctWords.Sort();
        }

        /// <summary>
        /// Method used to display Distinct words 
        /// </summary>
        public void Display()
        {
            int count = 0;

            Console.WriteLine("  Word\tCount");
            Console.WriteLine("  ----\t----");
            foreach(var item in DistinctWords)
            {
                count++;
                Console.WriteLine(count + ". " + item);
            }
        }
    }
}
