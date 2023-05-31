using ImitationGame.Core;
using ImitationGame.Core.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImitationGame.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Type> _algoritmeList;

        public MainWindow()
        {
            InitializeComponent();

            var type = typeof(IAlgoritme);
            var assembly = Assembly.GetAssembly(type);
            _algoritmeList = assembly!.GetTypes()
                                .Where(t => type.IsAssignableFrom(t)
                                    && t.IsClass == true)
                                .ToList();

            AlgoritmeComboBox.ItemsSource = _algoritmeList
                .OrderBy(t => t.Name)
                .Select(t => t.Name)
                .ToList();
            AlgoritmeComboBox.SelectedIndex = _algoritmeList.Any() ? 0 : -1;
        }

        private void OffButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAlgoritme = AlgoritmeComboBox.SelectedValue;
            var type = _algoritmeList.First(t => t.Name.Equals(selectedAlgoritme));
            var instance = Activator.CreateInstance(type) as IAlgoritme;

            int number = 0;
            _ = int.TryParse(KeyText.Text, out number);

            var enigma = new Enigma();
            enigma.SetAlgoritme(instance!);
            var encryptedText = enigma.Decrypt(EncryptedText.Text, number);

            DecryptedText.Text = "Decrypting...";
            await Task.Delay(10000);

            DecryptedText.Text = encryptedText;
        }

        private async void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAlgoritme = AlgoritmeComboBox.SelectedValue;
            var type = _algoritmeList.First(t => t.Name.Equals(selectedAlgoritme));
            var instance = Activator.CreateInstance(type) as IAlgoritme;

            int number = 0;
            _ = int.TryParse(KeyText.Text, out number);

            var enigma = new Enigma();
            enigma.SetAlgoritme(instance!);
            var encryptedText = enigma.Encrypt(DecryptedText.Text, number);

            EncryptedText.Text = "Encrypting...";
            await Task.Delay(10000);

            EncryptedText.Text = encryptedText;
        }
    }
}
