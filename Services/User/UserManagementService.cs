using Services.User.Base;
using Services.User.Context;
using Services.User.Entity;
using System.Collections.Generic;

namespace Services.User;

public class UserManagementService : IUserManagmentService
{
    public void AddUser(UserDto user)
    {
        using (ServiceContext serviceContext = new ServiceContext())
        {
            serviceContext.Пользователь.Add(user);
            serviceContext.SaveChanges();
        }
    }

    public IEnumerable<SecretQuestionDto> GetSecretQuestions()
    {
        List<SecretQuestionDto> result;

        using (ServiceContext serviceContext = new ServiceContext())
        {
            result = new List<SecretQuestionDto>(serviceContext.СекретныйВопрос);
        }

        return result;
    }
}
