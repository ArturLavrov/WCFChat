namespace ChatBL.CryptographyAlghoritms
{
    public class CheaserChipher:IAbstractAlghoritm
    {
        public string Encoding(string text, int k)
        {
            char[] buffer = text.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                letter = (char)((letter + k) % 256);
                buffer[i] = letter;
            }
            return new string(buffer);
        }

        public string Decoding(string text, int k)
        {
            char[] buffer = text.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                letter = (char)((letter + 256 - k) % 256);
                buffer[i] = letter;
            }
            return new string(buffer);
        }
    }
}
