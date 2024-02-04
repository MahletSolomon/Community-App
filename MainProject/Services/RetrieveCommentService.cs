using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using MainProject.Utilities;

namespace WpfApp1.Services;

public class RetrieveCommentService:ConnectionBaseService
{
    private CommentViewModel _commentViewModel;
    
    private LinkedListObservableCollection<CommentModel> Comments { get; set; }
    

    public RetrieveCommentService(LinkedListObservableCollection<CommentModel> comments, CommentViewModel commentViewModel)
    {
        Comments = comments;
        _commentViewModel = commentViewModel;
    }

    public void Execute()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM GetCommentInfo(@postID)", connection))
                {
                    command.Parameters.AddWithValue("@postID",_commentViewModel.Post.PostID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firsName=reader["userFirstName"].ToString();
                            string lastName=reader["userLastName"].ToString();
                            Comments.AddFirst(new CommentModel()
                            {
                                CommentMessage = reader["commentMessage"].ToString(),
                                UserProfilePicture = reader["userProfilePicture"].ToString(),
                                Name = firsName + " " + lastName
                            });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }

}