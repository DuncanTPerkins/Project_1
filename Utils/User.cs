//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 1
//	File Name:		User.cs
//	Description:    Uses Regex to parse data to ensure data is correct when being stored in the class
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Chance Reichenberg, reichenberg@etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Thursday, February 5, 2015
//	Copyright:		Chance Reichenberg, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Utils
{
    /// <summary>
    /// Class to hold user information and check that information for accuracy using Regex.
    /// </summary>
    public class User
    {
        private Regex emailPattern = new Regex(@"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})");
        private Regex phonePattern = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

        private string _name;           //private variable to hold the user's Name
        private string _phoneNumber;    //private variable to hold the user's Phone Number
        private string _emailAddress;   //private variable to hold the user's Email Address

        //public that returns the user's Name and sets the user's name while removing extra whitespace
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value.Trim();
            }
        }    
        //public property that returns the user's Phone Number. It set's the number if it is a valid number and throws an exception if it is invalid.
        public string PreferredTelephoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                //Match match = phonePattern.Match(value);
                if (phonePattern.IsMatch(value))
                {
                    _phoneNumber = value.Trim();
                }
                else
                {
                    throw new Exception(string.Format("An exception occurred in processing this user: \"{0}\" is not a valid telephone number.. Please Try Again.\n\n.", value));
                }//End if
            }
        }

        //public property that returns the user's Email Address. It set's the address if it is a valid email address and throws an exception if it is invalid.
        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                Match match = emailPattern.Match(value);
                if (match.Success)
                {
                    _emailAddress = value.Trim();
                }
                else
                {
                    throw new Exception(string.Format("An exception occurred in processing this user: \"{0}\" is not a valid Email Address.. Please Try Again.\n\n.", value));
                }//End if
            }
                
        }

        /// <summary>
        /// Default Constructor for the User class
        /// </summary>
        public User()
        {
           Name = "";
           _phoneNumber = "";
           _emailAddress = "";
        }//End Constructor

        /// <summary>
        /// Parameterized constructor for the User class
        /// </summary>
        /// <param name="name">Name of the User</param>
        /// <param name="phone"> Phone number of the user</param>
        /// <param name="email">Email address of the User</param>
        public User(string name, string phone, string email)
        {
            Name = name;
            PreferredTelephoneNumber = phone;
            EmailAddress = email;
        }//End Constructor

        
        /// <summary>
        /// Overriddes the ToString() method for the User class to implement its own ToString method.
        /// </summary>
        /// <returns>String of user information</returns>
        public override string ToString()
        {
            return string.Format("\n\nThe user's information:\nName: {0} \nEmail: {1}\nPhone: {2}\n\n", Name, _emailAddress, _phoneNumber);
        }//End Method
    }
}
