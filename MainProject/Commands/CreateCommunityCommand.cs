using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Commands;

public class CreateCommunityCommand : CommandBase
{
    HomeViewModel ViewModel;
    Window Window;

    public CreateCommunityCommand(Window window, HomeViewModel viewModel)
    {
        Window = window;
        ViewModel = viewModel;
        ViewModel.CommunityName = "";
        ViewModel.CommunityPicture = "";
        ViewModel.CommunityDescription = "";
    }
    public override void Execute(object parameter)
    {
        
        var newCommunity = new CommunityCardModel(){Name = "hello",PictureUrl = "/Images/art1.png"};
        ViewModel.CommunityCardModels.Add(newCommunity);
        ViewModel.CommunityName = "";
        ViewModel.CommunityDescription = "";
        ViewModel.CommunityPicture = "";
        Window.Hide();
    }
}