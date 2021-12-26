using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibMatrix;
using Library_10;
using Microsoft.Win32;

namespace Практическая__2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private MyMatrix _myMatrix;

        private void FillMatrix_Click(object sender, RoutedEventArgs e)
        {
            _myMatrix = new MyMatrix(int.Parse(matrixSize.Text));
            _myMatrix.FillMatrix();
            dataGrid.ItemsSource = _myMatrix.ToDataTable().DefaultView;
        }

        private void CalculateResult_Click(object sender, RoutedEventArgs e)
        {
            result.Text = _myMatrix.GetSqrtMatrix();
        }

        private void OpenMatrix_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Импорт матрицы";

            if (openFileDialog.ShowDialog() == true)
            {
                _myMatrix.Import(openFileDialog.FileName);
            }
            dataGrid.ItemsSource = _myMatrix.ToDataTable().DefaultView;
        }

        private void SaveMatrix_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Экспорт матрицы";

            if (saveFileDialog.ShowDialog() == true)
            {
                _myMatrix.Export(saveFileDialog.FileName);
            }
            dataGrid.ItemsSource = null;
        }

        private void TaskInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("10. Ввести n целых чисел. Вычислить для чисел > 0 функцию корень из х " +
             "Результат обработки каждого числа вывести на экран.");
        }

        private void DeveloperInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Харенко Кирилл  ИСП-34", "Разработчик", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
