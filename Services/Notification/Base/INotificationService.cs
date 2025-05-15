namespace Services.Notification.Base;

/// <summary>
///     Сервис, ответственный за вывод различных уведомлений в соответсвтующей реализации.
/// </summary>
public interface INotificationService
{
    /// <summary>
    ///     Уведомление об успешной операции.
    /// </summary>
    /// <param name="message"></param>
    public void NotifySuccess(string message);

    /// <summary>
    ///     Уведомление об ошибке с минимальным шаблоном
    /// </summary>
    public void NotifyError(string message);

    /// <summary>
    ///     Уведомление об ошибке с подробным описанием
    /// </summary>
    /// <param name="message">Основной текст</param>
    /// <param name="description">Вспомогательный текст</param>
    /// <param name="addition">Контекст ошибки</param>
    public void NotifyError(string message, string description, object source);

    /// <summary>
    ///     Уведомление о выброшенном ожидаемом исключении
    /// </summary>
    public void NotifyException(string message, Exception exception);
}
