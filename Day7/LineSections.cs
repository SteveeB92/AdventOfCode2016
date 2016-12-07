using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class LineSections
    {
        public string firstSection { get; set; }
        public string secondSection { get; set; }
        public string thirdSection { get; set; }

        public LineSections(string line)
        {
            firstSection = line.Substring(0, line.IndexOf('['));
            secondSection = line.Substring(line.IndexOf('[') + 1, line.IndexOf(']') - (line.IndexOf('[') + 1));
            thirdSection = line.Substring(line.IndexOf(']') + 1, line.Length - (line.IndexOf(']') + 1));
        }
        
        public bool isIPSupportsTLS()
        {
            return ((sectionContainsABBASequence(firstSection) || sectionContainsABBASequence(thirdSection))
                      && !sectionContainsABBASequence(secondSection));        
        }

        public bool sectionContainsABBASequence(string section)
        {
            char[] charsInSection = section.ToCharArray();
            
            for (int i = 0; i < charsInSection.Length - 3; i++)
            {
                if (checkFourCharsAreABBA(charsInSection, i))
                    return true;
            }

            return false;
        }

        public bool checkFourCharsAreABBA(char[] chars, int offset)
        {
            return chars[offset] == chars[3 + offset] && chars[1 + offset] == chars[2 + offset] && chars[offset] != chars[1 + offset];
        }
    }
}
