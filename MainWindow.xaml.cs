using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private bool isBrutto = true;


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string fullName = FullNameTextBox.Text;
                int hoursWorked = int.Parse(HoursWorkedTextBox.Text);
                decimal hourlyRate = decimal.Parse(HourlyRateTextBox.Text);
                decimal experienceBonus = decimal.Parse(ExperienceBonusTextBox.Text);
                decimal additionalBonus = decimal.Parse(AdditionalBonusTextBox.Text);


                decimal salary = CalculateSalary(hoursWorked, hourlyRate, experienceBonus, additionalBonus);


                if (isBrutto)
                {
                    MessageBox.Show($"Wynagrodzenie brutto dla {fullName}: {salary:C}");
                }
                else
                {
                    decimal nettoSalary = CalculateNetto(salary);
                    MessageBox.Show($"Wynagrodzenie netto dla {fullName}: {nettoSalary:C}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
        }


        private decimal CalculateSalary(int hoursWorked, decimal hourlyRate, decimal experienceBonus, decimal additionalBonus)
        {
            decimal baseSalary = hoursWorked * hourlyRate;
            return baseSalary + experienceBonus + additionalBonus;
        }


        private decimal CalculateNetto(decimal bruttoSalary)
        {
            decimal taxRate = 0.20m;
            return bruttoSalary * (1 - taxRate);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null)
            {
                if (radioButton.Content.ToString() == "BRUTTO")
                {
                    isBrutto = true;
                }
                else if (radioButton.Content.ToString() == "NETTO")
                {
                    isBrutto = false;
                }
            }
        }
    }
}

