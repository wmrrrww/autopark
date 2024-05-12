using System;
using System.Linq;
using System.Windows;
using autopark;

namespace autopark
{
    public partial class PaymentsWindow : Window
    {
        private readonly auto_parkEntities _context;

        public PaymentsWindow()
        {
            InitializeComponent();
            _context = new auto_parkEntities();
            LoadClientsData();
        }

        private void LoadClientsData()
        {
            PaymentsGrid.ItemsSource = _context.Платежи.ToList();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _context.SaveChanges();
                LoadClientsData();
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
                Платежи selectedPayment = (Платежи)PaymentsGrid.SelectedItem;

                if (selectedPayment != null)
                {
                    Платежи newPayment = new Платежи
                    {
                        Сумма = selectedPayment.Сумма,
                        Дата_Платежа = selectedPayment.Дата_Платежа,
                        Номер_Счета = selectedPayment.Номер_Счета,
                        Метод_Оплаты = selectedPayment.Метод_Оплаты,
                    };

                    _context.Платежи.Add(newPayment);
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
                var selectedPayment = PaymentsGrid.SelectedItem as Платежи;
                if (selectedPayment == null)
                {
                    MessageBox.Show("Пожалуйста, выберите платеж для удаления.");
                    return;
                }

                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этот платеж?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _context.Entry(selectedPayment).State = System.Data.Entity.EntityState.Deleted;
                    _context.SaveChanges();
                    LoadClientsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
