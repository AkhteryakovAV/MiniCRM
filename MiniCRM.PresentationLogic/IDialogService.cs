using System.Windows;

namespace MiniCRM.PresentationLogic
{
    public interface IDialogService
    {
        void ShowMessageInformation(string message);
        void ShowMessageError(string error);
        MessageBoxResult ShowMessageQuestion(string question);
    }
}
