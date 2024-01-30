using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Firebase.Storage;

namespace WpfApp1.Commands;

public class UploadProfilePictureService
{
    private string _imageUrl;
    private string _folder1;
    public UploadProfilePictureService(string folder1 )
    {
        _folder1 = folder1;
    }
    public async Task Post(string imagePath)
    {
        try
        {
        
            using (var stream = File.Open(imagePath, FileMode.Open))
            {
                var task = new FirebaseStorage("pomy-portfolio.appspot.com")
                    .Child(_folder1)
                    .Child(imagePath)
                    .PutAsync(stream);

                task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                _imageUrl = await task;

                
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