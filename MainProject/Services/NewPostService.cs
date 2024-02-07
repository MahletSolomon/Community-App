using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using MainProject.Utilities;

namespace WpfApp1.Services;

public class NewPostService:ConnectionBaseService
{
    private PostModel _postModel;
    private LoginModel _loginModel;
    private CreatePostViewModel _createPostViewModel;
    public NewPostService(CreatePostViewModel createPostViewModel,LoginModel loginModel )
    {
        _loginModel = loginModel;
        _createPostViewModel = createPostViewModel;
     
       
    }

    public async Task Execute()
    {
        _postModel = new PostModel()
        {
            PostCaption = _createPostViewModel.Caption,
            PostBy = _loginModel.ID,
            PostCommunity = _createPostViewModel.communityCardModel.ID,
            PostImagePath = _createPostViewModel.Picture,
            UserProfileName = _createPostViewModel._userInformationModel.FirstName + " " + _createPostViewModel._userInformationModel.LastName,
            UserProfilePicture =  _createPostViewModel._userInformationModel.ProfilePictureUrl,
            PostDate = DateTime.Today
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
                    SqlParameter outputParam = new SqlParameter("@postID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParam);
                    command.ExecuteNonQuery();
                    _postModel.PostID = Convert.ToInt32(outputParam.Value).ToString();

                }
            }

            StackObservableCollection<PostModel> newPost = new StackObservableCollection<PostModel>();
            foreach (var v in _createPostViewModel.PostFeedViewModel.Posts)
            {
                newPost.Push(v);
            }
            newPost.Push(_postModel);
            _createPostViewModel.PostFeedViewModel.Posts=newPost;
            _createPostViewModel.PostFeedViewModel.HomeViewModel.PostStorage[_createPostViewModel.communityCardModel.ID] = newPost;
            _createPostViewModel.communityCardModel.PostTotal += 1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
        
    }
    
}