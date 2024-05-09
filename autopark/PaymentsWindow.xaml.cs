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
                Платежи selectedPayment = (Платежи)PaymentsGrid.SelectedItem;

                if (selectedPayment != null)
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
                Платежи selectedPayment = (Платежи)PaymentsGrid.SelectedItem;

                if (selectedPayment != null)
                {
                    Платежи newPayment = new Платежи
                    {
                        ID_Платежа = selectedPayment.ID_Платежа,
                        ID_Сотрудника = selectedPayment.ID_Сотрудника,
                        ID_Клиента = selectedPayment.ID_Клиента,
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
                    MessageBox.Show("Пожалуйста, выберите клиента для удаления.");
                    return;
                }

                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этого клиента?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _context.Платежи.Remove(selectedPayment);
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
