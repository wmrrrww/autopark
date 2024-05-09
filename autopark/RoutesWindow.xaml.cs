using System.Linq;
using System.Windows;
using autopark;

namespace autopark
{
    public partial class RoutesWindow : Window
    {
        public RoutesWindow()
        {
            InitializeComponent();
            LoadClientsData();
        }

        private void LoadClientsData()
        {
            using (var context = new auto_parkEntities())
            {
                RoutesGrid.ItemsSource = context.Маршруты.ToList();
            }
        }
    }
}
