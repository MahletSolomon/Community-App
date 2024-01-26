using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Firebase.Storage;

namespace WpfApp1.Commands;

public class UploadProfilePictureService
{
    private string _imgaePath;
    private string _imageUrl;
    public UploadProfilePictureService(string imagePath)
    {
        _imgaePath = imagePath;
    }
    public async Task Post()
    {
        try
        {
        
            using (var stream = File.Open(_imgaePath, FileMode.Open))
            {
                var task = new FirebaseStorage("pomy-portfolio.appspot.com")
                    .Child("data")
                    .Child("file.png")
                    .PutAsync(stream);

                task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                _imageUrl = await task;

                MessageBox.Show($"Download URL: {_imageUrl}");
                
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public string GetUrl()
    {
        return _imageUrl;
    }
}