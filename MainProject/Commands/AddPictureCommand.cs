using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Firebase.Storage;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using Microsoft.Win32;

namespace WpfApp1.Commands;

public class AddPictureCommand:AsyncCommandBase
{
    private UploadPictureViewModel _UploadPictureViewModel  { set; get; }
    private UserInformationModel _userInformationModel;
    private UploadProfilePictureService uploadProfilePictureService;

    public AddPictureCommand(UploadPictureViewModel uploadPictureView,UserInformationModel userInformationModel)
    {
         uploadProfilePictureService = new UploadProfilePictureService(_userInformationModel.Username);
        _UploadPictureViewModel = uploadPictureView;
        _userInformationModel = userInformationModel;

    }
   protected override async Task ExecuteAsync(object parameter)
   {
       string filePath;
       Microsoft.Win32.OpenFileDialog openFileDialog = new OpenFileDialog();
       bool? response = openFileDialog.ShowDialog();
       if (response == true)
       {
           filePath = openFileDialog.FileName;
           
          await uploadProfilePictureService.Post(filePath);
          string url=uploadProfilePictureService.GetUrl();
          _UploadPictureViewModel.ProfileUrl = url;
          _userInformationModel.ProfilePictureUrl = url;
       }

   }



}
