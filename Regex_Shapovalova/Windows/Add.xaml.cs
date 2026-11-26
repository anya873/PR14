using System.Windows;
using Regex_Shapovalova.Classes.Common;

namespace Regex_Shapovalova.Windows
{
    public partial class Add : Window
    {
        public Classes.Passport EditPassports;

        public Add(Classes.Passport passport) // Передаем паспорт сюда
        {
            InitializeComponent();
            if (passport != null)
            {
                Name.Text = passport.Name;
                FirstName.Text = passport.FirstName;
                LastName.Text = passport.LastName;
                Issued.Text = passport.Issued;
                DateOfIssued.Text = passport.DateOfIssued;
                DepartmentCode.Text = passport.DepartmentCode;
                SeriesAndNumber.Text = passport.SeriesAndNumber;
                DateOfBirth.Text = passport.DateOfBirth;
                PlaceOfBirth.Text = passport.PlaceOfBirth;
                this.EditPassports = passport;
                BthAdd.Content = "Изменить";
            }
        }

        private void AddPassport(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text) || !CheckRegex.Match("^[а-яА-ЯёЁ]+$", Name.Text))
            {
                MessageBox.Show("Неправильно указано имя");
                return;
            }
            if (string.IsNullOrWhiteSpace(FirstName.Text) || !CheckRegex.Match("^[а-яА-ЯёЁ]+$", FirstName.Text))
            {
                MessageBox.Show("Неправильно указана фамилия");
                return;
            }
            if (string.IsNullOrWhiteSpace(LastName.Text) || !CheckRegex.Match("^[а-яА-ЯёЁ]+$", LastName.Text))
            {
                MessageBox.Show("Неправильно указано отчество");
                return;
            }
            if (string.IsNullOrWhiteSpace(Issued.Text) || !CheckRegex.Match("^[а-яА-ЯёЁ]+$", Issued.Text))
            {
                MessageBox.Show("Неправильно указан орган выдачи");
                return;
            }

            if (string.IsNullOrWhiteSpace(DateOfIssued.Text) || !CheckRegex.Match(@"^\d{2}\.\d{2}\.\d{4}$", DateOfIssued.Text))
            {
                MessageBox.Show("Неправильно указана дата выдачи");
                return;
            }

            if (string.IsNullOrWhiteSpace(DepartmentCode.Text) || !CheckRegex.Match(@"^\d{3}-\d{3}$", DepartmentCode.Text))
            {
                MessageBox.Show("Неправильно указан код подразделения");
                return;
            }

            if (string.IsNullOrWhiteSpace(SeriesAndNumber.Text) || !CheckRegex.Match(@"^\d{4} \d{6}$", SeriesAndNumber.Text))
            {
                MessageBox.Show("Неправильно указаны серия и номер");
                return;
            }

            if (string.IsNullOrWhiteSpace(DateOfBirth.Text) || !CheckRegex.Match(@"^\d{2}\.\d{2}\.\d{4}$", DateOfBirth.Text))
            {
                MessageBox.Show("Неправильно указана дата рождения");
                return;
            }
            if (string.IsNullOrWhiteSpace(PlaceOfBirth.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-ЯёЁ\\s-]+$", PlaceOfBirth.Text))
            {
                MessageBox.Show("Неправильно указано место рождения");
                return;
            }

            if (EditPassports == null)
            {
                EditPassports = new Classes.Passport();
                MainWindow.init.Passports.Add(EditPassports);
            }

            EditPassports.Name = Name.Text;
            EditPassports.FirstName = FirstName.Text;
            EditPassports.LastName = LastName.Text;
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