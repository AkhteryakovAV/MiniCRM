
namespace MiniCRM.PresentationLogic
{
    public interface INavigationService
    {
        void ShowWindow<TViewModel>(object parametr = null) where TViewModel : BaseViewModel;
    }
}