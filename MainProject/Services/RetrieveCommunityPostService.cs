using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Services;

public class RetrieveCommunityPostService:ConnectionBaseService
{
     private ObservableCollection<PostModel> _post;
    public int _communityID;
    private HomeViewModel _homeViewModel;
    public RetrieveCommunityPostService(ObservableCollection<PostModel> postModels,int CommunityID)
    {
        _post = postModels;
        _communityID = CommunityID;
    }
    
    public async void Execute()
    {
        // _homeViewModel.IsLoading = true;
        try
        {
            await RunQuery();

        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        // _homeViewModel.IsLoading = false;
    }

    private async Task RunQuery()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.GetPostInCommunityInfo(@CommunityID,@UserID)", connection))
                {
                    command.Parameters.AddWithValue("@CommunityID", _communityID);
                    command.Parameters.AddWithValue("@UserID", "AbiyMera73");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader["userFirstName"].ToString();
                            string lastName = reader["userLastName"].ToString();
                            int IsLikedInt = int.Parse(reader["IsLiked"].ToString());
                            bool IsLiked = IsLikedInt == 1 ? true:false;

                            _post.Add(new PostModel()
                            {
                                PostCaption =  reader["postDescription"].ToString(),
                                PostID =  reader["postID"].ToString(),
                                PostImagePath =  reader["imageURL"].ToString(),
                                PostDate =  reader["postDate"].ToString(),
                                TotalLike = int.Parse(reader["postLike"].ToString()),
                                TotalComment = int.Parse(reader["postComment"].ToString()),
                                UserProfilePicture =  reader["userProfilePicture"].ToString(),
                                UserProfileName =  firstName + " " + lastName,
                                IsLiked = IsLiked
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