using FitnessDietApp.Data;
using System.Linq;
using System.Windows.Controls;

namespace FitnessDietApp.UI {
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page {
        public StartPage() {
            InitializeComponent();
            using (var context = new Context()) {
                if (context.PersonInfo.Count() == 0)
                    this.ChooseOldUser.IsEnabled = false;
            }
        }

        private void ChooseNewUser_Click(object sender, System.Windows.RoutedEventArgs e) {
            using (var context = new Context()) {
                context.Database.ExecuteSqlCommand("DELETE FROM DiaryItems");
                context.Database.ExecuteSqlCommand("DELETE FROM PersonInfo");
                context.Database.ExecuteSqlCommand("DELETE FROM Diary");
                context.Database.ExecuteSqlCommand("DELETE FROM PersonNorms");
            }
        }
    }
}
