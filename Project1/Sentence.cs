using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Project1
{
    class Sentence 
    {
        public int WordCount { get { return _wordcount; } set { _wordcount = value; } }
        private int _wordcount;
        public Double AverageLength { get { return _averagelength; } set { _averagelength = value; } }
        private Double _averagelength;
        public string FirstToken { get { return _firsttoken; } set { _firsttoken = value; } }
        private string _firsttoken;
        public string LastToken { get { return _lasttoken; } set { _lasttoken = value; } }
        private string _lasttoken;
        public List<string> FinalSentence { get { return _sentence; } set { _sentence = value; } }
        public List<string> list2;
        private List<string> _sentence;
        private static int counter;
        private static Regex EndSentence = new Regex(@"!{0,1}.{0,1}?{0,1}");
        private static Match match;
        /// <summary>
        /// default constructor for Sentence class. Sets everything to empty.
        /// </summary>
        public Sentence()
        {
            WordCount = 0;
            AverageLength = 0;
            FirstToken = "";
            LastToken = "";
            FinalSentence = null;
            counter = 0;
        }

        /// <summary>
        /// Constructor for Sentence class
        /// </summary>
        /// <param name="text">An instance of the Text object that contains tokenized input from a text file</param>
        /// <param name="StartingToken">The location index of the Beginning of a sentence in the Text object's List of Tokens</param>
        public Sentence(Text text, int StartingToken)
        {
           
            
                text.GetTokens();
                List<String> StartingText = text.Tokens;
                int ListSize = (StartingText.Count);
                int NewListSize = (ListSize - (StartingToken+1));
                list2 = StartingText.GetRange(StartingToken, NewListSize);
                counter = 0;
                foreach (string s in list2)
                {
                    match = EndSentence.Match(s);
                    if (match.Success)
                    {
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                }
                FinalSentence = list2.GetRange(0, counter);
                GetMetrics();
            

            
        }

        public void GetMetrics()
        {
            WordCount = FinalSentence.Count;
            AverageLength = GetAverage();
            FirstToken = FinalSentence[0];
            LastToken = FinalSentence[FinalSentence.Count-1];
        }

        public double GetAverage()
        {
            double average =0;
            foreach (string s in FinalSentence)
            {
                average += s.Length;
            }
            average /= FinalSentence.Count;

            return average;
        }

        public override String ToString()
        {
            string str = "";
            foreach (string s in FinalSentence)
            {
                str += s;
            }
            return str;
        }
    }
}