using System;
using System.Linq;
using System.Windows;
using autopark;

namespace autopark
{
    public partial class EmployeesWindow : Window
    {
        private readonly auto_parkEntities _context;

        public EmployeesWindow()
        {
            InitializeComponent();
            _context = new auto_parkEntities();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new auto_parkEntities())
            {
                EmployeesGrid.ItemsSource = context.Сотрудники.ToList();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _context.SaveChanges();
                LoadData();
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
                Сотрудники selectedEmployees = (Сотрудники)EmployeesGrid.SelectedItem;

                if (selectedEmployees != null)
                {
                    Сотрудники newEmployees = new Сотрудники
                    {
                        ФИО = selectedEmployees.ФИО,
                        Должность = selectedEmployees.Должность,
                        Телефон = selectedEmployees.Телефон,
                        Почта = selectedEmployees.Почта,
                    };

                    _context.Сотрудники.Add(newEmployees);
                    _context.SaveChanges();

                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedEmployee = EmployeesGrid.SelectedItem as Сотрудники;
                if (selectedEmployee == null)
                {
                    MessageBox.Show("Пожалуйста, выберите сотрудника для удаления.");
                    return;
                }

                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этого сотрудника?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _context.Сотрудники.Remove(selectedEmployee);
                    _context.SaveChanges();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
