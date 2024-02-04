using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace MainProject.Services;

public class DeletePostService:ConnectionBaseService
{
    
    public UserPostViewModel UserPostViewModel;
    public DeletePostService(UserPostViewModel userPostViewModel)
    {
        UserPostViewModel = userPostViewModel;
    }
    public void Execute()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString) { })
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Posts WHERE postID=@ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", UserPostViewModel.PostModel.PostID);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Update was successful
                        MessageBox.Show("Post deleted");
                    }
                    else
                    {
                        MessageBox.Show("Post not found or not deleted.");
                    }
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            
            
        }
    }
    
}