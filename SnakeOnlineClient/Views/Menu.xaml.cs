using System.Windows;
using System.Windows.Controls;

namespace SnakeOnlineClient.Views
{
    /// <summary>
    /// Interaction logic for Menu
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ExitCommand(object sender, System.Windows.RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
