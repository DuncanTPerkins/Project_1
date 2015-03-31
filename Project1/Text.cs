//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		Text.cs
//	Description:    Converts text files into tokens
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Duncan Perkins, perkinsdt@goldmail.etsu.edu, Chance Reichenberg, reichenberg@etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Thursday, February 15, 2015
//	Copyright:		Duncan Perkins, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Utils;
namespace Project1
{
    /// <summary>
    /// Text object used to work with text file 
    /// </summary>
    class Text
    {
        //Original string to be tokenized
        public string Original { get; set; }
        //StreamReader for reading from file 
        private StreamReader reader = null;
        //List of Tokenized tokens 
        public List<String> Tokens { get; set; }
        //filename of txt file to read from
        private string _fileName = null;
        //delimeters to tokenize against 
        String delims = @"?!,';:*(){}+-\/. ";
        //file dialog for getting txt file 
        OpenFileDialog _OpenDlg = new OpenFileDialog();

        /// <summary>
        /// Default constructor
        /// </summary>
        public Text()
        {
            Original = "";
            GetFile();
            GetTokens();
        }

        /// <summary>
        /// constructor for passing in a file path to be tokenized
        /// </summary>
        /// <param name="input">path to file the user wants tokenized, or a string to be tokenized</param>
        /// <param name="context">tells us the context of what string input contains</param>
        public Text(string input, int context)
        {
            //if the context is 0, string input is the directory to a text file 
            if (context == 0)
            {
                Original = "";
                _fileName = input;
            }

            //if the context is 1, string input is a string to be tokenized 
            if (context == 1)
            {
                Tokens = Utility.Tokenize(input, delims);
            }

        }
        /// <summary>
        /// Gets the txt file from the user, then breaks it into tokens using the tokenize method 
        /// </summary>
        public void GetTokens()
        {

            //reading from file 
            try
            {
                //initialize the StreamReader with the directory from the user 
                using (reader = new StreamReader(_fileName))
                {
                    //variable for single line of input from file 
                    string line;
                    //while we aren't at the end of the file, copy the next line from the file to line
                    while ((line = reader.ReadLine()) != null)
                    {
                        //append the current line to the "Original" String 
                        Original += line;
                    }
                }
            }
            //in case anything goes wrong 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Tokenize the string into a list of tokens
            Tokens = Utility.Tokenize(Original, delims);
        }

        /// <summary>
        /// Method for opening file dialog and getting file path from user
        /// </summary>
        public void GetFile()
        {
            //Open in the Resources Folder
            _OpenDlg.InitialDirectory = Application.StartupPath;
            //If the user opened a file, copy the directory to _fileName 
            if (DialogResult.Cancel != _OpenDlg.ShowDialog())
            {
                _fileName = _OpenDlg.FileName;

            }
        }

    }
}
