using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using MainProject.Services;

namespace WpfApp1.Commands;

public class CreateCommunityCommand : CommandBase
{
    private CreateCommunityService _createCommunityService;
    public CreateCommunityCommand(CreateCommunityService createCommunityService)
    {
        _createCommunityService = createCommunityService;
        
    }
    public override void Execute(object parameter)
    {
        _createCommunityService.Execute();
    }
}