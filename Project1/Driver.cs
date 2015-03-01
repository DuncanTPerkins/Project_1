//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		Driver.cs
//	Description:    ?????
//	Course:			CSCI 2210-001 - Data Structures
//	Authors:		Chance Reichenberg, reichenberg@etsu.edu, Duncan Perkins, perkinsdt@goldmail.etsu.edu,  Department of Computing, East Tennessee State University
//	Created:	    Thursday, February 5, 2015
//	Copyright:		Chance Reichenberg, Duncan Perkins 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
namespace Project1
{
    class Driver
    {
        [STAThread]
        static void Main(string[] args)
        {
            Text test = new Text();
            test.GetTokens();
            //Sentence s = new Sentence(test, 0);

            //Console.WriteLine(Utility.FormatText(s.ToString()));
            SentenceList sl = new SentenceList(test);
            sl.Display();
            //Words testWords = new Words(test);
            //testWords.Display();
            //foreach(var i in test.Tokens)
            //{
            //    Console.WriteLine(i);
            //}

            //Paragraph getSentences = new Paragraph(test);
            //Console.WriteLine(getSentences.ToString());
            //ParagraphList p = new ParagraphList(test);
            //Console.WriteLine(p.Display());
            Console.ReadLine();
        }
        }
    }

