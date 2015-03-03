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
using System.Text.RegularExpressions;
using Utils;

namespace Project1
{
    /// <summary>
    /// Class used to display Distinct words found in a text file
    /// </summary>
    class Words
    {
        //Used to match words in the list
        private Regex wordPattern = new Regex(@"^\w");

        #region Properties

        // Public property that holds the distinct words
        public List<DistinctWord> DistinctWords { get; private set; }

        // Public read-only property that holds the number of distinct words
        public int Count
        {
            get
            {
                return DistinctWords.Count;
            }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor for the Words class
        /// </summary>
        public Words()
        {
            DistinctWords = new List<DistinctWord>();
        }//End Method

        /// <summary>
        /// Parameterized constructor that takes a text object and puts the tokens into the list of Distinct words.
        /// </summary>
        /// <param name="words">Text object containing File text</param>
        public Words(Text words)
        {
            DistinctWords = new List<DistinctWord>();

            //Loops through the list and checks if the item is a word
            foreach(var item in words.Tokens)
            {
                if(wordPattern.IsMatch(item))
                {
                    DistinctWord matchedWord = new DistinctWord(item);

                    AddWordOrCount(matchedWord);
                }//End If
            }//End Foreach
            DistinctWords.Sort();
        }//End Method

        #endregion

        /// <summary>
        /// Method used to display Distinct words 
        /// </summary>
        public void Display()
        {
            int count = 0;

            Console.WriteLine("Distinct words found in the text with their number of occurrences.");
            Console.WriteLine(Utility.FormatText("  Word\t\t\tCount",5,40));
            Console.WriteLine(Utility.FormatText("  ----\t\t\t----",5,40));
            foreach(var item in DistinctWords)
            {
                count++;
                Console.WriteLine(Utility.FormatText(String.Format("{0,3}.  {1}",count, item), 2, 40));
            }//End Foreach
        }//End Method

        /// <summary>
        /// Tests to see whether the word should be added to an existing word's count or added to the list
        /// </summary>
        /// <param name="tempWord">The word to be added</param>
        private void AddWordOrCount(DistinctWord tempWord)
        {
            //if it is a word it checks to see if it is already in the list and adds it to the respective words count
            if (!DistinctWords.Contains(tempWord))
            {
                DistinctWords.Add(tempWord);
            }
            else
            {
                foreach (var word in DistinctWords)
                {
                    word.Count += (word.Word == tempWord.Word) ? 1 : 0;
                }//End Foreach
            }//End If
        }
    }//End Class Words
}
