//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		ParagraphList.cs
//	Description:    Creates a list that holds the paragraph objects
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
using System.Threading.Tasks;

namespace Project1
{
    class ParagraphList
    {
        //The list that holds the paragraphs
        private List<Paragraph> Paragraphs = new List<Paragraph>();

        //Variable to hold the number of paragraphs in the list
        private int NumParagraphs { get { return Paragraphs.Count; } }

        //Variable to hold the average length of the paragraphs in the list 
        private double AverageLength 
        { 
            get
            { 
                //Create and initialize the counter
                int total = 0; 

                //Loops through the list of paragraphs
                foreach (Paragraph p in Paragraphs) 
                {

                    //Adds the Words property of each paragraph to the counter
                    total += p.Words; 

                }// end loop

                //Calculates the average words per sentence
                total /= Paragraphs.Count;

                //Returns the average
                return total;

                } // end getter
        } // end property

        /// <summary>
        /// Default constructor for the class ParagraphList
        /// </summary>
        public ParagraphList() 
        {

            //Initialize the Paragraphs list to null
            Paragraphs = null;

        } // end default constructor

        /// <summary>
        /// Paramaterized Constructor
        /// </summary>
        /// <param name="text">Text object being passed</param>
        public ParagraphList(Text text) 
        
        {
            //Initialize the Paragraph object passing the Text object
            Paragraph p = new Paragraph(text);

            //Adds the paragraph to the Paragraphs list
            Paragraphs.Add(p);

        } // end constructor

        /// <summary>
        /// Add a paragraph object to the list 
        /// </summary>
        /// <param name="p">Paragraph object passed in</param>
        public void AddParagraph(Paragraph p) 
        
        {
            //Add paragraph object to the Paragraphs list 
            Paragraphs.Add(p);

        } // end method 

        /// <summary>
        /// Add a text object to be parsed into a Paragraph object, then added to the list
        /// </summary>
        /// <param name="t">Text object being passed</param>
        public void AddTextObject(Text t) 
        
        {
            //Initialize the Paragraph object passing the Text object
            Paragraph p = new Paragraph(t);

            //Adds the paragraph to the Paragraphs list
            Paragraphs.Add(p);

        } // end method

        /// <summary>
        /// Format string for output in main driver class
        /// </summary>
        /// <returns>returns formatted string for console display</returns>
        public string Display() 
        {
            //Create and initialize the counter
            int counter = 0;

            //Create and initialize the string str
            string str = "Paragraphs found in the text:\n";

            //Loops through the list of paragraphs
            foreach (Paragraph p in Paragraphs) 
            {

                //Appends the paragraph counter to the string str
                str += "\nParagraph " + (counter + 1) + ".\n\n";

                //Appends the paragraphs overriding ToString method to the string str
                str += p.ToString() + "\n";

                //Increments the counter by 1
                counter++;

            } // end loop

            //Appends the number of paragraphs and the average to the string str
            str += "\n\nThere are " + NumParagraphs + " paragraphs." + "          " + "The average number of words in the paragraphs is: " + AverageLength + "\n";

            //Returns the string str
            return str;

        } // end method
    } // end class
} // end namespace
