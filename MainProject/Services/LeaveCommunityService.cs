using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Services;

public class LeaveCommunityService:ConnectionBaseService
{
    private string _userID;
    private int _communityID;
    private HomeViewModel _homeViewModel;
    public LeaveCommunityService(string userID,int communityId,HomeViewModel homeViewModel)
    {
        _userID = userID;
        _communityID = communityId;
        _homeViewModel = homeViewModel;
    }

    public void Execute()
    {
        try
        {
            using (SqlConnection connection=new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command=new SqlCommand("DeleteCommunityMember",connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userID", _userID);
                        command.Parameters.AddWithValue("@communityID", _communityID);
                        command.ExecuteNonQuery();
                        _homeViewModel.DashBordViewModel.Refresh();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        throw;
                    }
                }
                
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            throw;
        }
    }
    
}