using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace MainProject.Services;

public class JoinCommunityService:ConnectionBaseService
{
    private JoinCommunityViewModel _joinCommunityViewModel;
    public JoinCommunityService(JoinCommunityViewModel joinCommunityViewModel)
    {
        _joinCommunityViewModel = joinCommunityViewModel;
    }

    public void Execute()
    {
        try
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("AddCommunityMessage",connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userID", _joinCommunityViewModel.LoginModel.ID);
                        command.Parameters.AddWithValue("@communityID", _joinCommunityViewModel.CommunityCardModel.ID);
                        command.ExecuteNonQuery();
                        _joinCommunityViewModel.JoinCommunityWindow.Close();
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