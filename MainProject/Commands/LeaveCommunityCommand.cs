using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class LeaveCommunityCommand:AsyncCommandBase
{
  
    private LeaveCommunityService _leaveCommunityService;

    public LeaveCommunityCommand(LeaveCommunityService leaveCommunityService)
    {

        _leaveCommunityService = leaveCommunityService;
    }
    protected override async Task ExecuteAsync(object parameter)
    {
        MessageBoxResult result = MessageBox.Show($"Are you sure you want to leave the community", "Leave Confirmation", MessageBoxButton.OKCancel);
        if (result == MessageBoxResult.OK)
        {
            _leaveCommunityService.Execute();

        }
       
    }
}