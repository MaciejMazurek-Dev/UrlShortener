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

        public string[] Generate(int quantity, int startIndex, int tokenLength)
        {
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
    }
}
