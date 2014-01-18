using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuansLibrary
{
    public static class StringHelper
    {
        private static bool IsALetter(this string character)
        {
            return "abcdefghijklmnopqrstvwxyzABCDEFGHIJKLMNOPQRSTVWXYZ".Contains(character);
        }

        /// <summary>
        /// Trims non-letter characters from begining and end of string
        /// </summary>
        /// <returns></returns>
        public static string TrimNonLetters(this string word)
        {
            var finalWord = string.Empty;

            if (word.Length == 0)
                return word;
            else
            {
                for (int i = 0; i < 1; i++)
                {
                    if (!IsALetter(word[i].ToString()))
                    {
                        finalWord = word.Substring(1);
                    }
                    else
                    {
                        finalWord = word;
                    }
                }

                for (int i = word.Length - 1; i > 0; i--)
                {
                    if (!IsALetter(word[i].ToString()))
                    {
                        finalWord = finalWord.Remove(i);
                    }
                }
            }

            return finalWord;
        }
    }
}
