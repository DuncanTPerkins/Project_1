using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Sentence : IEquatable<Sentence>, IComparable<Sentence>
    {
        public int WordCount { get { return _wordcount; } set { _wordcount = value; } }
        private int _wordcount;
        public int AverageLength { get { return _averagelength; } set { _averagelength = value; } }
        private int _averagelength;
        public string FirstToken { get { return _firsttoken; } set { _firsttoken = value; } }
        private string _firsttoken;
        public string LastToken { get { return _lasttoken; } set { _lasttoken = value; } }
        private string _lasttoken;
        public List<string> Sentence { get { return _sentence; } set { _sentence = value; } }
        private List<string> _sentence;
        private List<string> FinalList;
        /// <summary>
        /// default constructor for Sentence class. Sets everything to empty.
        /// </summary>
        public Sentence()
        {
            WordCount = 0;
            AverageLength = 0;
            FirstToken = "";
            LastToken = "";
            Sentence = null;
        }

        /// <summary>
        /// Constructor for Sentence class
        /// </summary>
        /// <param name="text">An instance of the Text object that contains tokenized input from a text file</param>
        /// <param name="StartingToken">The location index of the Beginning of a sentence in the Text object's List of Tokens</param>
        public Sentence(Text text, int StartingToken)
        {
            Char[] EndingCondition = new Char[] { '?', '!', '.' };
            text.GetTokens();
            List<String> StartingText = text.Tokens;
            int ListSize = StartingText.Count;
            int NewListSize = (ListSize - StartingToken);
            StartingText = StartingText.GetRange(StartingToken, NewListSize);
            int index = StartingText.indexOf(EndingCondition);
        }

        public void GetMetrics()
        {
            WordCount = FinalList.Count;
            AverageLength = 
        }
    }
}
