using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using FizzBuzzLibrary;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FizzBuzzWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<FizzBuzzCondition> Conditions;

        public MainWindow()
        {
            InitializeComponent();

            SetInitialConditions();
        }

        private void SetInitialConditions()
        {
            Conditions = new List<FizzBuzzCondition>();
            Conditions.Add(new FizzBuzzCondition(3, "Fizz"));
            Conditions.Add(new FizzBuzzCondition(5, "Buzz"));
            Conditions.Add(new FizzBuzzCondition(13, "Custom"));
            dgvConditions.ItemsSource = Conditions;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            if(IsDataValid())
            {
                GetFizzBuzzFromService();
            }
        }
        private bool IsDataValid()
        {
            bool check = true;

            if(string.IsNullOrWhiteSpace(txtLowNumber.Text) || string.IsNullOrWhiteSpace(txtLowNumber.Text))
            {
                MessageBox.Show("Must enter a low and a high number!");
                check = false;
            }
            else if(Convert.ToInt32(txtLowNumber.Text) >= Convert.ToInt32(txtHighNumber.Text))
            {
                MessageBox.Show("Low Number must be less than High Number");
                check = false;
            }

            return check;
        }
        private void GetFizzBuzzFromService()
        {
            FizzBuzzRequest Request = new FizzBuzzRequest();
            Request.Conditions = Conditions;
            Request.LowNumber = Convert.ToInt32(txtLowNumber.Text);
            Request.HighNumber = Convert.ToInt32(txtHighNumber.Text);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:49999");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("/api/FizzBuzz", Request).Result;

            if (response.IsSuccessStatusCode)
            {
                lstOutput.ItemsSource = response.Content.ReadAsAsync<IEnumerable<string>>().Result;
            }
            else
            {
                MessageBox.Show("Error: Failed communication with FizzBuzzService." + Environment.NewLine + response.RequestMessage);
            }
        }


        private void btnConditionAdd_Click(object sender, RoutedEventArgs e)
        {
            if(IsConditionDataValid())
            {
                AddCondition();
            }
        }
        private bool IsConditionDataValid()
        {
            bool check = true;

            if(string.IsNullOrWhiteSpace(txtConditionDivider.Text) || string.IsNullOrWhiteSpace(txtConditionText.Text))
            {
                MessageBox.Show("Must enter a divider and text!");
                check = false;
            }
            else if(IsDividerOnList())
            {
                MessageBox.Show("Divider is already on list, remove existing condition first!");
                check = false;
            }

            return check;
        }
        private bool IsDividerOnList()
        {
            var existingItem = Conditions.Where(x => x.Divider == Convert.ToInt32(txtConditionDivider.Text)).FirstOrDefault();
            if (existingItem==null)
            {
                return false;
            }
            return true;
        }
        private void AddCondition()
        {
            Conditions.Add(new FizzBuzzCondition(Convert.ToInt32(txtConditionDivider.Text),txtConditionText.Text));
            dgvConditions.Items.Refresh();
        }
        private void dgvConditions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgvConditions.SelectedIndex != -1)
            {
                Conditions.Remove(((FizzBuzzCondition)dgvConditions.SelectedItem));
                txtConditionDivider.Text = "";
                txtConditionText.Text = "";
                dgvConditions.Items.Refresh();
            }
        }

        private void ForceNumeric(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

    }
}
