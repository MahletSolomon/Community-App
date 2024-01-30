using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Services;

public class UpdatePostService:ConnectionBaseService
{
    private PostModel _postModel;

    public UserPostViewModel UserPostViewModel;

    public UpdatePostService(PostModel postModel)
    {
        _postModel = postModel;
    }
    public void Execute()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Posts SET  postDescription=@Caption WHERE postID=@ID", connection))
                {
                    // Set parameters
                    //command.Parameters.AddWithValue("@ImagePath", _postModel.PostImagePath);
                    command.Parameters.AddWithValue("@Caption", _postModel.PostCaption);
                    
                    command.Parameters.AddWithValue("@ID", int.Parse( _postModel.PostID));
                    MessageBox.Show(_postModel.PostCaption);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(_postModel.PostCaption);

                    UserPostViewModel.UserPostWindow.Hide();
                    // Check if the update was successful
                 
                }


                
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

}