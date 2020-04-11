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

namespace Day04ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> peopleList = new List<Person>();
        private Person selectedPerson;

        public MainWindow()
        {
            InitializeComponent();
            lvPeople.ItemsSource = peopleList;
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            if (null == name.Trim())
            {
                MessageBox.Show(this, "Name must be 1-150 characters", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int age;
            if (!int.TryParse(tbAge.Text, out age))
            {
                MessageBox.Show(this, "Age must be 1-150", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            tbName.Text = "";
            tbAge.Text = "";
            peopleList.Add(new Person(name, age));
            lvPeople.Items.Refresh();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (null == selectedPerson)
            {
                MessageBox.Show(this, "You must select a person", "Operation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show(this, $"Are you sure you want to delete the poerson <{selectedPerson}>", "Operation Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (MessageBoxResult.Yes == messageBoxResult)
            {
                tbName.Text = "";
                tbAge.Text = "";
                peopleList.Remove(selectedPerson);
                lvPeople.Items.Refresh();
            }
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            if (null == selectedPerson)
            {
                MessageBox.Show(this, "You must select a person", "Operation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string name = tbName.Text;
            if (null == name.Trim())
            {
                MessageBox.Show(this, "Name must be 1-150 characters", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int age;
            if (!int.TryParse(tbAge.Text, out age))
            {
                MessageBox.Show(this, "Age must be 1-150", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            tbName.Text = "";
            tbAge.Text = "";
            selectedPerson.Name = name;
            selectedPerson.Age = age;
            lvPeople.Items.Refresh();
        }

        private void lvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPerson = (Person)lvPeople.SelectedItem;
            if (null != selectedPerson)
            {
                tbName.Text = selectedPerson.Name;
                tbAge.Text = selectedPerson.Age.ToString();
            }
        }
    }
}