using ImitationGame.Core.Encryption;

namespace ImitationGame.Core;

/// <summary>
/// Engima engine.
/// </summary>
public class Enigma
{
    private IAlgoritme? _algoritme;

    /// <summary>
    /// Set the algoritme to use.
    /// </summary>
    /// <param name="algoritme"><see cref="IAlgoritme"/></param>
    public void SetAlgoritme(IAlgoritme algoritme)
    {
        _algoritme = algoritme;
    }

    /// <summary>
    /// Encrypt the message.
    /// </summary>
    /// <param name="inputMessage">message</param>
    /// <param name="key">key</param>
    /// <returns>Encrypted message</returns>
    /// <exception cref="NotSupportedException">Invalid algoritme</exception>
    public string Encrypt(string inputMessage, int key)
    {
        if (_algoritme == null)
        {
            throw new NotSupportedException("Geen algoritme gezet");
        }

        var outputMessage = _algoritme.Encrypt(inputMessage, key);

        Console.WriteLine("ENCRYPTIE:");
        Console.WriteLine($"key: {key}");
        Console.WriteLine();
        Console.WriteLine("[INPUT]");
        Console.WriteLine($"{inputMessage}");
        Console.WriteLine();
        Console.WriteLine("[OUTPUT]");
        Console.WriteLine($"{outputMessage}");

        return outputMessage;
    }

    /// <summary>
    /// Decrypt message.
    /// </summary>
    /// <param name="inputMessage">message</param>
    /// <param name="key">key</param>
    /// <returns>Decrypted message</returns>
    /// <exception cref="NotSupportedException">Invalid algoritme</exception>
    public string Decrypt(string inputMessage, int key)
    {
        if (_algoritme == null)
        {
            throw new NotSupportedException("Geen algoritme gezet");
        }

        var outputMessage = _algoritme.Decrypt(inputMessage, key);

        Console.WriteLine("DECRYPTIE:");
        Console.WriteLine($"key: {key}");
        Console.WriteLine();
        Console.WriteLine("[INPUT]");
        Console.WriteLine($"{inputMessage}");
        Console.WriteLine();
        Console.WriteLine("[OUTPUT]");
        Console.WriteLine($"{outputMessage}");

        return outputMessage;

    }
}
