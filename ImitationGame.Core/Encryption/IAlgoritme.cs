namespace ImitationGame.Core.Encryption;

/// <summary>
/// Algoritme for encryption and decryption
/// </summary>
public interface IAlgoritme
{
    /// <summary>
    /// Encrypt.
    /// </summary>
    /// <param name="message">Message to encrypt</param>
    /// <param name="key">Key for encryption</param>
    /// <returns>Encrypted messages</returns>
    string Encrypt(string message, int key);


    /// <summary>
    /// Decrypt.
    /// </summary>
    /// <param name="message">Message to decrypt</param>
    /// <param name="key">Key for encryption</param>
    /// <returns>Decrypted messages</returns>
    string Decrypt(string message, int key);
}
