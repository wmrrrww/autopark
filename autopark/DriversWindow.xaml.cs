using System.Linq;
using System.Windows;
using autopark;

namespace autopark
{
    public partial class DriversWindow : Window
    {
        public DriversWindow()
        {
            InitializeComponent();
            LoadClientsData();
        }

        private void LoadClientsData()
        {
            using (var context = new auto_parkEntities())
            {
                DriversGrid.ItemsSource = context.Водители.ToList();
            }
        }
    }
}
