using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Services;

public class NewPostService:ConnectionBaseService
{
    private PostModel _postModel;
    private LoginModel _loginModel;
    private PostFeedViewModel _postFeedViewModel;
    public NewPostService(PostFeedViewModel postFeedViewModel,LoginModel loginModel )
    {
        _loginModel = loginModel;
        _postFeedViewModel = postFeedViewModel;
     
       
    }

    public async Task Execute()
    {
        _postModel = new PostModel()
        {
            PostCaption = _postFeedViewModel.Caption,
            PostBy = _loginModel.ID,
            PostCommunity = _postFeedViewModel.communityCardModel.ID,
            PostImagePath = _postFeedViewModel.Picture,
            UserProfileName = _postFeedViewModel._userInformationModel.FirstName + " " + _postFeedViewModel._userInformationModel.LastName,
            UserProfilePicture =  _postFeedViewModel._userInformationModel.ProfilePictureUrl,
        };

        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertIntoPosts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@imageURL", _postModel.PostImagePath);
                    command.Parameters.AddWithValue("@postDescription", _postModel.PostCaption);
                    command.Parameters.AddWithValue("@postedBy", _postModel.PostBy);
                    command.Parameters.AddWithValue("@postedCommunity", _postModel.PostCommunity);
                    command.ExecuteNonQuery();
                }
            }
            _postFeedViewModel.Posts.Add(_postModel);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
        
    }
    
}