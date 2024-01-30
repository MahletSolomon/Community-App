using System.Threading.Tasks;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using Microsoft.Win32;

namespace WpfApp1.Commands;

public class UploadCommunityPictureCommand:AsyncCommandBase
{
    private UploadProfilePictureService _uploadProfilePictureService;
    private CreateCommunityViewModel _createCommunityViewModel;
    public UploadCommunityPictureCommand(CreateCommunityViewModel createCommunityViewModel)
    {
        _createCommunityViewModel = createCommunityViewModel;
        _uploadProfilePictureService = new UploadProfilePictureService(createCommunityViewModel.LoginModel.ID+'Z');
    }
    protected override async Task ExecuteAsync(object parameter)
    {
        string filePath;
        Microsoft.Win32.OpenFileDialog openFileDialog = new OpenFileDialog();
        bool? response = openFileDialog.ShowDialog();
        if (response == true)
        {
            filePath = openFileDialog.FileName;
            await _uploadProfilePictureService.Post(filePath);
            _createCommunityViewModel.CommunityCardModel.PictureUrl = _uploadProfilePictureService.GetUrl();
            MessageBox.Show(_uploadProfilePictureService.GetUrl());
        }
    }
}