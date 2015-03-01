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
        //List to hold Paragraphs
        private List<Paragraph> Paragraphs = new List<Paragraph>();

        //total number of paragraphs in the list
        private int NumParagraphs { get { return Paragraphs.Count; } }

        //Average length of the paragraphs in the list 
        private double AverageLength { get
        { 
            //initialize counter to 0
            int total = 0; 

            //for each Paragraph "p" in the List Object Paragraphs 
            foreach (Paragraph p in Paragraphs) 
            {
                //Add each Words Property of each paragraph object to the total
                total+=p.Words; 
            }// end foreach
            //total equals total divided by the total number of Paragraph objects in Paragraphs 
            total/=Paragraphs.Count; 
            //return the average
            return total;
            } //end getter
        } // end property

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ParagraphList() {
            Paragraphs = null;
        } // end default constructor

        /// <summary>
        /// Paramaterized Constructor
        /// </summary>
        /// <param name="Text object passed in for creation of Paragraph"></param>
        public ParagraphList(Text text) {
            //initialize paragraph object with text object
            Paragraph p = new Paragraph(text);
            //add the object to our Paragraphs list 
            Paragraphs.Add(p);
        }// end constructor

        /// <summary>
        /// Add a paragraph object to the list 
        /// </summary>
        /// <param name="p">Paragraph object passed in</param>
        public void AddParagraph(Paragraph p) {
            //Add paragraph object to our Paragraphs list 
            Paragraphs.Add(p);
        }// end method 

        /// <summary>
        /// Add a text object to be parsed into a Paragraph object, then added to the list
        /// </summary>
        /// <param name="t">Text object passed in</param>
        public void AddTextObject(Text t) {
            //initialize our paragraph object with our text object
            Paragraph p = new Paragraph(t);
            //Add it to the Paragraphs list 
            Paragraphs.Add(p);
        }// end method

        /// <summary>
        /// Format string for output in main driver class
        /// </summary>
        /// <returns>returns formatted string for console display</returns>
        public string Display() {
            //initialize counter to 0
            int counter =0;

            //initialize string to header statement 
            string str = "Sentences Found in Text:\n";

            //for each paragraph object in Paragraphs
            foreach (Paragraph p in Paragraphs) {
                //append the Sentence counter to the string 
                str += "\nSentence " + (counter + 1) + ".\n\n";

                //append the current paragraph object's ToString method to str 
                str += p.ToString() + "\n";

                //increment the counter by 1
                counter++;

            }// end foreach
            str += "\n\nThere are : " + NumParagraphs + " Paragraphs." + "           " + "The average number of words in the paragraph is: " + AverageLength + "\n";

            return str;
        }//end method


    }// end class
}// end namespace
