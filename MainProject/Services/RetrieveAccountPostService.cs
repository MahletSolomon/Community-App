using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using MainProject.MVVM.Model;

namespace WpfApp1.Services;

public class RetrieveAccountPostService:ConnectionBaseService
{

    public ObservableCollection<PostModel> _postModels;
    private string UserID;

    public RetrieveAccountPostService(string userId,ObservableCollection<PostModel> postModels)
    {
        UserID = userId;
        _postModels = postModels;

    }
    public void Execute()
    {
        
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM GetUserPosts(@userID)", connection))
                {
                    command.Parameters.AddWithValue(@"userID", UserID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _postModels.Add(new PostModel()
                            {
                                PostID = reader["postID"].ToString(),
                                PostImagePath = reader["imageURL"].ToString(),
                                PostCaption = reader["postDescription"].ToString(),
                                PostDate = DateTime.Parse(reader["postDate"].ToString()),
                                TotalLike = int.Parse(reader["postLike"].ToString()),
                                TotalComment = int.Parse(reader["postComment"].ToString()),
                                UserProfilePicture = reader["userProfilePicture"].ToString(),
                                PostCommunity = int.Parse(reader["postCommunity"].ToString())
                            });
                           
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }

    }

 
}