using System.Linq;
using System.Windows;
using autopark;

namespace autopark
{
    public partial class CarsWindow : Window
    {
        public CarsWindow()
        {
            InitializeComponent();
            LoadClientsData();
        }

        private void LoadClientsData()
        {
            using (var context = new auto_parkEntities())
            {
                CarsGrid.ItemsSource = context.Автомобили.ToList();
            }
        }
    }
}
