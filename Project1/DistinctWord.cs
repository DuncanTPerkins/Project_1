//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		DistinctWord.cs
//	Description:    Holds a distinct word and the number of times it appears in the File
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
    /// Class to hold distinct words and the number of times that they appear
    /// </summary>
    class DistinctWord : IEquatable<DistinctWord> , IComparable<DistinctWord>
    {
        //Private variable to hold the lowercase distinct word
        private string _word;

        #region Properties

        //Property to access private variable _word
        public string Word
        {
            get
            {
                return _word;
            }
            set
            {
                _word = value.ToLower();
            }
        }

        //Property that holds the number of times this word occurs in the file
        public int Count { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor for DistinctWord Class, sets the property Word to an empty string
        /// </summary>
        public DistinctWord()
        {
            Word = "";
        }//End Method

        /// <summary>
        /// Parameterized constructor for Distinct Word class
        /// </summary>
        /// <param name="word">Word to add to object</param>
        public DistinctWord(string word)
        {
            _word = word.ToLower();
            Count++;
        }//End Method

        #endregion

        #region IEquatable<DistinctWord> Members

        /// <summary>
        /// Overriden Equals Method used to compare the DistinctWord Class
        /// </summary>
        /// <param name="obj">Object to compare to</param>
        /// <returns>If obj is null, uses base equals compare, if Object is a Distinct word returns outcome of IEquatable</returns>
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return base.Equals(obj);
            }

            if (!(obj is DistinctWord))
            {
                throw new ArgumentException("Parameter is not a DistinctWord");
            }
            else
                return Equals(obj as DistinctWord);
        }//End Method

        /// <summary>
        /// Implemented IEquatable Equals Method
        /// </summary>
        /// <param name="word">Word object to compare to</param>
        /// <returns>True if Words are the same, false if they aren't</returns>
        bool IEquatable<DistinctWord>.Equals(DistinctWord word)
        {
            return _word == word.Word;
        }//End Method

        /// <summary>
        /// Overrides bool operator == to use IEquatable method
        /// </summary>
        /// <param name="word1">Object comparing</param>
        /// <param name="word2">Object being compared to </param>
        /// <returns>True if words are the same, false otherwise</returns>
        public static bool operator == (DistinctWord word1, DistinctWord word2)
        {
            return word1.Equals(word2);
        }//End Method

        /// <summary>
        /// Overrides bool operator != to use IEquatable method
        /// </summary>
        /// <param name="word1">Object comparing</param>
        /// <param name="word2">Object being compared to </param>
        /// <returns>True if words are the different, false otherwise</returns>
        public static bool operator != (DistinctWord word1, DistinctWord word2)
        {
            return !(word1.Equals(word2));
        }//End Method

        /// <summary>
        /// Overrides GetHashCode
        /// </summary>
        /// <returns>Has Code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        /// <summary>
        /// Overrides .ToString Method to display object contents
        /// </summary>
        /// <returns>Formatted String of object contents</returns>
        public override string ToString()
        {
            return String.Format("{0,-24}{1,-10}", Word, Count.ToString());
        }//End Method
    

        #region IComparable<DistinctWord> Members

        /// <summary>
        /// Implementation of IComparable used to order Distinct words
        /// </summary>
        /// <param name="wordToCompare">Word that will be compared to</param>
        /// <returns>0 if they are equal, > 0 if this is greater</returns>
        public int CompareTo(DistinctWord wordToCompare)
        {
            return this._word.CompareTo(wordToCompare._word);
        }//End Method

        #endregion
    }//End Class DistinctWord
}
