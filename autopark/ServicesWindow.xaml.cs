using System.Linq;
using System.Windows;
using autopark;

namespace autopark
{
    public partial class ServicesWindow : Window
    {
        public ServicesWindow()
        {
            InitializeComponent();
            LoadClientsData();
        }

        private void LoadClientsData()
        {
            using (var context = new auto_parkEntities())
            {
                ServicesGrid.ItemsSource = context.Услуги_По_Обслуживанию.ToList();
            }
        }
    }
}
