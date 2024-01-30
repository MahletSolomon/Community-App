using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Services;

public class LikeService:ConnectionBaseService
{
    private PostFeedViewModel _postFeedViewModel;
    public LikeService(PostFeedViewModel postFeedViewModel)
    {
        _postFeedViewModel = postFeedViewModel;
    }

    public void ExecuteLikeAdd(PostModel post)
    {
        // _postFeedViewModel._LoginModel.ID;
        try
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("AddLike",connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userID", _postFeedViewModel._LoginModel.ID);
                        command.Parameters.AddWithValue("@postID", post.PostID);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
    public void ExecuteLikeDelete(PostModel post)
    {
        // _postFeedViewModel._LoginModel.ID;
        try
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("DeleteLike",connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userID", _postFeedViewModel._LoginModel.ID);
                        command.Parameters.AddWithValue("@postID", post.PostID);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
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