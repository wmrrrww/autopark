using System.Linq;
using System.Windows;
using autopark;

namespace autopark
{
    public partial class RentalsWindow : Window
    {
        public RentalsWindow()
        {
            InitializeComponent();
            LoadClientsData();
        }

        private void LoadClientsData()
        {
            using (var context = new auto_parkEntities())
            {
                RentalsGrid.ItemsSource = context.Аренда.ToList();
            }
        }
    }
}
