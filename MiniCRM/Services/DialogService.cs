using MiniCRM.PresentationLogic;
using System.Windows;

namespace MiniCRM.Services
{
    public class DialogService : IDialogService
    {
        public void ShowMessageError(string error)
        {
            _ = MessageBox.Show($"Ошибка: {error}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowMessageInformation(string message)
        {
            _ = MessageBox.Show($"Информация: {message}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public MessageBoxResult ShowMessageQuestion(string question)
        {
            return MessageBox.Show(question, "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
