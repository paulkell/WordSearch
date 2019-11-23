using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch
{
    public class ValidWord
    {
        public string Word { get; set; }
        public string Length { get; set; }
        public string Order { get; set; }
        public ValidWord(string word, int order)
        {
            Word = word;
            Length = word.Length.ToString();
            Order = order.ToString();
        }
        public ValidWord()
        {
            Length = "-";
            Order = "New";
        }
    }
}
