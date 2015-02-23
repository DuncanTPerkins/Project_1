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
    
    class Text
    {
        //Original string to be tokenized
        public string Original { get; set; }
        private StreamReader reader = null;
        //List of Tokenized tokens 
        public List<String> Tokens { get; set; }
        private string _fileName;
        String delims = @"?!,';:*(){}+-\/ ";

        public Text()
        {
            Original = "";
        }
        public void GetTokens()
        {
           OpenFileDialog _OpenDlg= new OpenFileDialog();
            _OpenDlg.InitialDirectory = Application.StartupPath + @"..\..\Resources";
            if (DialogResult.Cancel != _OpenDlg.ShowDialog())
            {
                _fileName = _OpenDlg.FileName;

            }
            try
            {
                using (reader = new StreamReader(_fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Original += line;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Tokens = Utility.Tokenize(Original, delims);
        }

    }
}
