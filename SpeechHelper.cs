using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace JuansLibrary
{
    public static class SpeechHelper
    {

        /// <summary>
        /// returns a grammar with choices. The choices are passed in the string by enclosing them in parenthesis
        /// ie: Please fly to {Boston, Florida, New York} on {Saturday, Sunday}
        /// </summary>
        /// <returns></returns>
        public static Grammar CreateGrammar(string text)
        {
            var builder = new GrammarBuilder();
            Choices choices = new Choices();
            var finalBuilder = new GrammarBuilder();
            var finalChoices = new Choices();
            Grammar returnGrammar;

            string data = text.Trim();
            char delim = ' ';
            string[] words = data.Split(delim); // holds the data already split by words
            bool insideList = false;
            string phrase = "";

            foreach (var word in words)
            {
                if (word.StartsWith("{"))
                {
                    if (phrase.Length > 0)
                    {
                        phrase = phrase.Trim();
                        builder.Append(phrase);
                        phrase = "";
                    }
                    choices = new Choices();
                    insideList = true;
                    if (word.EndsWith(","))
                    {
                        choices.Add(word.TrimNonLetters());
                    }
                    else
                        phrase += word.TrimNonLetters() + " ";

                }
                else if (word.EndsWith("}"))
                {
                    word.TrimNonLetters();
                    if (phrase.Length > 0)
                    {
                        phrase += word;
                        choices.Add(phrase);
                        phrase = "";
                    }
                    else
                        choices.Add(word);
                    builder.Append(choices);
                    insideList = false;
                }
                else if (word.EndsWith(","))
                {
                    if (insideList)
                    {
                        phrase += word.TrimNonLetters();
                        choices.Add(phrase);
                        phrase = "";
                    }
                    else
                        phrase += word + " ";
                }
            }

            if (phrase.Length > 0)
                builder.Append(phrase.Trim());


            finalChoices.Add(builder);

            var beforeBuilder = new GrammarBuilder();
            beforeBuilder.AppendWildcard();
            var beforeKey = new SemanticResultKey("beforeKey", beforeBuilder);

            var afterBuilder = new GrammarBuilder();
            afterBuilder.AppendWildcard();
            var afterKey = new SemanticResultKey("afterKey", afterBuilder);


            finalBuilder.Append(beforeBuilder);
            finalBuilder.Append(finalChoices);
            finalBuilder.Append(afterBuilder);

            returnGrammar = new Grammar(finalBuilder);

            return returnGrammar;
        }
    }
}
