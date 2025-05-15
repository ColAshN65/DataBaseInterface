namespace Services.User.Entity;

public record UserDto(int КодПользователя,
    string Имя,
    string Фамилия,
    string Пароль,
    string ЭлектроннаяПочта,
    string КодовоеСлово,
    string ОтветНаСекрет,
    int КодСекретногоВопроса);
