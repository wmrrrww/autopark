using System.Linq;
using System.Windows;
using autopark;

namespace autopark
{
    public partial class PaymentsWindow : Window
    {
        public PaymentsWindow()
        {
            InitializeComponent();
            LoadClientsData();
        }

        private void LoadClientsData()
        {
            using (var context = new auto_parkEntities())
            {
                PaymentsGrid.ItemsSource = context.Платежи.ToList();
            }
        }
    }
}
