using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Services.Notification.Base;
using Services.User.Base;
using Services.User.Entity;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.ViewModel;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _surname;

    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _password;

    [ObservableProperty]
    private string _passwordSecond;

    [ObservableProperty]
    private string _codeWord;

    public ObservableCollection<string> SecretQuestions { get; set; } = new ObservableCollection<string>();

    [ObservableProperty]
    private string _selectedQuestion;

    [ObservableProperty]
    private string _secretAnswer;

    [ObservableProperty]
    private bool _isAgree;

    public MainWindowViewModel(INotificationService notificationService, IUserManagmentService userManagmentService)
    {
        this.notificationService = notificationService;
        this.userManagmentService = userManagmentService;

        secretQuestions = userManagmentService.GetSecretQuestions();
        foreach (SecretQuestionDto secretQuestion in secretQuestions)
            SecretQuestions.Add(secretQuestion.СекретныйВопрос);
    }

    public ICommand AddCommand
    {
        get => new RelayCommand(AddNewUserCommand);
    }

    private void AddNewUserCommand()
    {
        if (IsAgreeValidate() && PasswordMatchValidate())
        {
            int id = secretQuestions.Where(x => x.СекретныйВопрос == SelectedQuestion).First().КодСекретногоВопроса;
            userManagmentService.AddUser(new UserDto(new Random().Next(), Name, Surname, Password, Email, CodeWord, SecretAnswer, id));

            notificationService.NotifySuccess("Успешно создан новый пользователь!");
        }
    }

    private bool PasswordMatchValidate()
    {
        if (Password.Equals(PasswordSecond))
            return true;
        else
        {
            notificationService.NotifyError("Пароли не совпадают!");
            return false;
        }
    }

    private bool IsAgreeValidate()
    {
        if (!IsAgree)
            notificationService.NotifyError("Вы должны согласиться с условиями!");

        return IsAgree;
    }

    private readonly INotificationService notificationService;
    private readonly IUserManagmentService userManagmentService;

    private IEnumerable<SecretQuestionDto> secretQuestions;
}
