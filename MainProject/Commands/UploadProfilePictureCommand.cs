using System.Threading.Tasks;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using Microsoft.Win32;

namespace WpfApp1.Commands;

public class UploadProfilePictureCommand:AsyncCommandBase
{
    private UploadProfilePictureService _uploadProfilePictureService;
    private CreatePostViewModel _createPostView;
    public UploadProfilePictureCommand(CreatePostViewModel createPostView)
    {
         _uploadProfilePictureService = new UploadProfilePictureService(createPostView._LoginModel.ID);
         _createPostView = createPostView;
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
            _createPostView.Picture = _uploadProfilePictureService.GetUrl();
            _createPostView.DefaultUpload = filePath;
        }
    }
}