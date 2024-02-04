using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace MainProject.Services;

public class AddCommentService:ConnectionBaseService
{
    private CommentViewModel _commentViewModel;

    public AddCommentService(CommentViewModel commentViewModel)
    {
        _commentViewModel = commentViewModel;
   
    }

    public void Execute()
    {
        try
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("InsertIntoComments",connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@commentMessage", _commentViewModel.NewComment);
                        command.Parameters.AddWithValue("@userID",_commentViewModel.LoginModel.ID);
                        command.Parameters.AddWithValue("@postID",_commentViewModel.Post.PostID);
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