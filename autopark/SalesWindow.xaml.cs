using System.Linq;
using System.Windows;
using autopark;

namespace autopark
{
    public partial class SalesWindow : Window
    {
        public SalesWindow()
        {
            InitializeComponent();
            LoadClientsData();
        }

        private void LoadClientsData()
        {
            using (var context = new auto_parkEntities())
            {
                SalesGrid.ItemsSource = context.Продажи.ToList();
            }
        }
    }
}
