using Services.User.Entity;

namespace Services.User.Base;

public interface IUserManagmentService
{
    public IEnumerable<SecretQuestionDto> GetSecretQuestions();
    public void AddUser(UserDto user);
}
