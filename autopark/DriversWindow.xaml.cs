using System;
using System.Linq;
using System.Windows;
using autopark;

namespace autopark
{
    public partial class DriversWindow : Window
    {
        private readonly auto_parkEntities _context;

        public DriversWindow()
        {
            InitializeComponent();
            _context = new auto_parkEntities();
            LoadClientsData();
        }

        private void LoadClientsData()
        {
            DriversGrid.ItemsSource = _context.Водители.ToList();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Водители selectedDriver = (Водители)DriversGrid.SelectedItem;

                if (selectedDriver != null)
                {
                    _context.SaveChanges();
                    LoadClientsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Водители selectedDriver = (Водители)DriversGrid.SelectedItem;

                if (selectedDriver != null)
                {
                    Водители newDriver = new Водители
                    {
                        ID_Водителя = selectedDriver.ID_Водителя,
                        ФИО = selectedDriver.ФИО,
                        ID_Маршрута = selectedDriver.ID_Маршрута,
                        Номер_ВУ = selectedDriver.Номер_ВУ,
                        Телефон = selectedDriver.Телефон,

                    };

                    _context.Водители.Add(newDriver);
                    _context.SaveChanges();

                    LoadClientsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.InnerException?.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedDriver = DriversGrid.SelectedItem as Водители;
                if (selectedDriver == null)
                {
                    MessageBox.Show("Пожалуйста, выберите клиента для удаления.");
                    return;
                }

                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этого клиента?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _context.Водители.Remove(selectedDriver);
                    _context.SaveChanges();
                    LoadClientsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
