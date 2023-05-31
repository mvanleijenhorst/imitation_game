namespace ImitationGame.Core.Encryption;

public class AsciiAlgoritme : IAlgoritme
{
    public string Encrypt(string message, int key)
    {
        var encryptedMessage = string.Empty;
        foreach (var character in message.ToCharArray())
        {
            var numberCharacter = (int)character;
            encryptedMessage += (numberCharacter + key).ToString("D5");
        }

        return encryptedMessage;
    }


    public string Decrypt(string message, int key)
    {
        var decryptedMessage = string.Empty;
        var text = message;
        while (text.Length > 5)
        {
            var sub = text[..5]; 
            text = text[5..]; 
            var number = int.Parse(sub) - key;

            decryptedMessage += (char)number;
        }

        return decryptedMessage;
    }
}
