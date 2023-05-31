namespace ImitationGame.Core.Encryptie;

public class SwapLetterAlgoritme : IAlgoritme
{
    private const int Letter_A = 65;
    private const int Letter_Z = 90;
    private const int Letter_a = 97;
    private const int Letter_z = 122;
    private const int Number_0 = 48;
    private const int Number_9 = 57;

    public string Decrypt(string message, int key)
    {
        var encryptedMessage = string.Empty;
        foreach (var character in message.ToCharArray())
        {
            var index = (int)character;
            bool isLower = index >= Letter_a && index <= Letter_z;
            bool isUpper = index >= Letter_A && index <= Letter_Z;
            bool isNumber = index >= Number_0 && index <= Number_9;

            if (isLower)
            {
                encryptedMessage += SwapLetter(key, index, Letter_a, Letter_z);
            }
            else if (isUpper)
            {
                encryptedMessage += SwapLetter(key, index, Letter_A, Letter_Z);
            }
            else if (isNumber)
            {
                encryptedMessage += SwapLetter(key, index, Number_0, Number_9);
            }
            else
            {
                encryptedMessage += character;
            }
        }

        return encryptedMessage;
    }

    public string Encrypt(string message, int key)
    {
        var decryptedMessage = string.Empty;
        foreach (var character in message.ToCharArray())
        {
            var index = (int)character;
            bool isLower = index >= Letter_a && index <= Letter_z;
            bool isUpper = index >= Letter_A && index <= Letter_Z;
            bool isNumber = index >= Number_0 && index <= Number_9;

            if (isLower)
            {
                decryptedMessage += SwapLetter(key * -1, index, Letter_a, Letter_z);
            }
            else if (isUpper)
            {
                decryptedMessage += SwapLetter(key * -1, index, Letter_A, Letter_Z);
            }
            else if (isNumber)
            {
                decryptedMessage += SwapLetter(key * -1, index, Number_0, Number_9);
            }
            else
            {
                decryptedMessage += character;
            }
        }

        return decryptedMessage;
    }



    private static char SwapLetter(int key, int index, int beginIndex, int endIndex)
    {
        var result = index + key;
        if (result > endIndex)
        {
            return (char)(result - endIndex + beginIndex - 1);
        }
        else if (result < beginIndex)
        {
            return (char)(result - beginIndex + endIndex + 1);
        }

        return (char)result;
    }
}
