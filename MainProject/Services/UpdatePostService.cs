using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Services;

public class UpdatePostService:ConnectionBaseService
{
    

    public UserPostViewModel UserPostViewModel;

    public UpdatePostService(UserPostViewModel userPostViewModel)
    {
        UserPostViewModel = userPostViewModel;
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
                    
                    command.Parameters.AddWithValue("@Caption", UserPostViewModel.PostModel.PostCaption);
                    
                    command.Parameters.AddWithValue("@ID", UserPostViewModel.PostModel.PostID);
                    int rowsAffected = command.ExecuteNonQuery();
                    
                    // Check if the update was successful
                    if (rowsAffected > 0)
                    {
                        // Update was successful
                        MessageBox.Show("Post updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Post not found or not updated.");
                    }
                  
                 
                }


                
            }
            MessageBox.Show($"New Caption: {UserPostViewModel.PostModel.PostCaption}");

            
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

}