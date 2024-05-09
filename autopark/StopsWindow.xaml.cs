using System.Linq;
using System.Windows;
using autopark;

namespace autopark
{
    public partial class StopsWindow : Window
    {
        public StopsWindow()
        {
            InitializeComponent();
            LoadClientsData();
        }

        private void LoadClientsData()
        {
            using (var context = new auto_parkEntities())
            {
                StopsGrid.ItemsSource = context.Остановки.ToList();
            }
        }
    }
}
