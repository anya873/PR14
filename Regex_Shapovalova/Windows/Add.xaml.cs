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
using System.Windows.Shapes;

namespace Regex_Shapovalova.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Classes.Passport EditPassports;
        public Add()
        {
            InitializeComponent();
            if(EditPassports != null)
            {
                Name.Text = EditPassports.Name;
                FirstName.Text = EditPassports.FirstName;
                LastName.Text = EditPassports.LastName;
                Issued.Text = EditPassports.Issued;
                DateOfIssued.Text = EditPassports.DateOfIssued;
                DepartmentCode.Text = EditPassports.DepartmentCode;
                SeriesAndNumber.Text= EditPassports.SeriesAndNumber;
                DateOfBirth.Text = EditPassports.DateOfBirth;
                PlaceOfBirth.Text= EditPassports.PlaceOfBirth;
                this.EditPassports = EditPassports;
                BthAdd.Content = "Изменить";
            }
        }
        private void AddPassport(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", Name.Text))
            {
                MessageBox.Show("Неправильно указано имя пользователя");
                return;
            }

            if (string.IsNullOrEmpty(FirstName.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", FirstName.Text))
            {
               MessageBox.Show("Неправильно указана фамилия пользователя");
               return;
            }
            if (string.IsNullOrEmpty(LastName.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", LastName.Text))
            {
                MessageBox.Show("Неправильно указано отчество пользователя");
                return;
            }
            if (string.IsNullOrEmpty(Issued.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", Issued.Text))
            {
                MessageBox.Show("Неправильно указан орган выдачи пасспорта");
                return;
            }
            if (string.IsNullOrEmpty(DateOfIssued.Text) || !Classes.Common.CheckRegex.Match("^\d{2}.\d{2}.\d{4}", DateOfIssued.Text))
            {
                MessageBox.Show("Неправильно указана дата выдачи паспорта");
                return;
            }
            if (string.IsNullOrEmpty(DepartmentCode.Text) || !Classes.Common.CheckRegex.Match("^\d{2}.\d{2}.\d{4}", DepartmentCode.Text))
            {
                MessageBox.Show("Неправильно указан код подразделения паспорта");
                return;
            }
            if (string.IsNullOrEmpty(SeriesAndNumber.Text) || !Classes.Common.CheckRegex.Match("^\d{2}.\d{2}.\d{4}", SeriesAndNumber.Text))
            {
                MessageBox.Show("Неправильно указаны серия и номер паспорта");
                return;
            }
            if (string.IsNullOrEmpty(DateOfBirth.Text) || !Classes.Common.CheckRegex.Match("^\d{2}.\d{2}.\d{4}", DateOfBirth.Text))
            {
                MessageBox.Show("Неправильно указана дата рождения пользователя");
                return;
            }
            if (string.IsNullOrEmpty(DateOfIssued.Text) || !Classes.Common.CheckRegex.Match("^\d{2}.\d{2}.\d{4}", DateOfIssued.Text))
            {
                MessageBox.Show("Неправильно указана дата выдачи паспорта");
                return;
            }
            if (EditPassports == null)
            {
                EditPassports = new Classes.Passport();
                MainWindow.init.Passports.Add(EditPassports);
            }
            EditPassports.Name= Name.Text;
            EditPassports.FirstName= FirstName.Text;
            EditPassports.LastName= LastName.Text;
            EditPassports.Issued = Issued.Text;
            EditPassports.DateOfIssued = DateOfIssued.Text;
            EditPassports.DepartmentCode = DepartmentCode.Text;
            EditPassports.SeriesAndNumber = SeriesAndNumber.Text;
            EditPassports.DateOfBirth = DateOfBirth.Text;
            EditPassports.PlaceOfBirth = PlaceOfBirth.Text;
            MainWindow.init.LoadPassport();
            this.Close();
        }
    }
}
