using Presentation.Services.Notification;
using Presentation.View;
using Presentation.ViewModel;
using Services.Notification.Base;
using Services.User;
using Services.User.Base;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowViewModel(notificationService, userManagmentService);

            mainWindow.Show();
            base.OnStartup(e);
        }


        private readonly INotificationService notificationService = new MessageBoxNotificationService();
        private readonly IUserManagmentService userManagmentService = new UserManagementService();
    }

}
