using ImitationGame.Core;
using ImitationGame.Core.Encryption;

var file = args[0];
var message = File.ReadAllText(file);

var machine = new Enigma();
//machine.SetAlgoritme(...); todo: set the encryption algoritme
machine.Encrypt(message, 0); // key is now zero (0)

Console.ReadKey();