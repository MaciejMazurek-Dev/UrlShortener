using System.Reflection.Metadata.Ecma335;

namespace UrlShortenerMVC.Utilities
{
    public class Token
    {
        private char[] characterSet;
        private int characterSetLength;
        public Token()
        {
            characterSet = "kfjhgldsamnbvcxzpoiuytrewqZXCVBNMASDFGHJKLQWERTYUIOP".ToCharArray();
            characterSetLength = characterSet.Length;
        }

        public string[] Generate(int quantity, int startIndex, int? length)
        {
            int tokenLength = length ?? 5;
            
                string[] result = new string[quantity];
                int index = startIndex;

                for (int q = 0; q < quantity; q++)
                {
                    int tempIndex = index;
                    char[] token = new char[tokenLength];

                    for (int i = tokenLength - 1; i >= 0; i--)
                    {
                        token[i] = characterSet[tempIndex % characterSetLength];
                        tempIndex = tempIndex / characterSetLength;
                    }
                    result[q] = new string(token);
                    index++;
                }
                return result;
            
        }

        public int TokenToIndex(string? token)
        {
            if (token == null)
            {
                return 0;
            }
            else
            {
                int tokenLength = token.Length;
                double result = 0;
                int charPos = tokenLength - 1;

                for (int charIndex = 0; charIndex < tokenLength; charIndex++)
                {
                    result += Math.Pow(characterSetLength, charPos) * Array.IndexOf(characterSet, token[charIndex]);
                    charPos--;
                }
                return (int)result;
            }
        }
    }
}
