using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MainProject.MVVM.Model;

namespace WpfApp1.Services;

public class RetriveCommunityFromPostService : ConnectionBaseService
{
    public int communityId;
    private CommunityCardModel _communityCardModel;
    public RetriveCommunityFromPostService(int CommunityID, CommunityCardModel communityCardModel)
    {

        communityId=CommunityID;
        _communityCardModel = communityCardModel;

    }
    public void Execute()
    {
        

        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"SELECT c.communityName, c.communityProfilePictureURL FROM Community c WHERE {communityId}=c.communityID ", connection))
                {
                   

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            _communityCardModel.Name = reader["communityName"].ToString();
                            _communityCardModel.PictureUrl = reader["communityProfilePictureURL"].ToString();
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
