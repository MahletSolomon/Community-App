using System.Threading.Tasks;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using Microsoft.Win32;

namespace WpfApp1.Commands;

public class UploadProfilePictureCommand:AsyncCommandBase
{
    private UploadProfilePictureService _uploadProfilePictureService;
    private PostFeedViewModel _postFeedViewModel;
    public UploadProfilePictureCommand(PostFeedViewModel postFeedViewModel)
    {
         _uploadProfilePictureService = new UploadProfilePictureService(postFeedViewModel._LoginModel.ID);
         _postFeedViewModel = postFeedViewModel;
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
            _postFeedViewModel.Picture = filePath;
            MessageBox.Show(_uploadProfilePictureService.GetUrl());
        }
    }
}