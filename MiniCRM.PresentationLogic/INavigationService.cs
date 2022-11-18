
namespace MiniCRM.PresentationLogic
{
    public interface INavigationService
    {
        void ShowWindow<TViewModel>(bool showDialog = true, object parametr = null) where TViewModel : BaseViewModel;
    }
}