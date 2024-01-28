using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using MainProject.MVVM.Model;

namespace WpfApp1.Services;

public class RetrieveCommunityInformationService:ConnectionBaseService
{
    private ObservableCollection<CommunityCardModel> _communityCardModels;
    public string _userID;
    public RetrieveCommunityInformationService(ObservableCollection<CommunityCardModel> CommunityCardModels,string UserID)
    {
        _communityCardModels = CommunityCardModels;
        _userID = UserID;

    }

    public void Execute()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.GetCommunityByUserID(@UserID)", connection))
                {
                    command.Parameters.AddWithValue("@UserID", _userID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader["userFirstName"].ToString();
                            string lastName = reader["userLastName"].ToString();
                            _communityCardModels.Add(new CommunityCardModel()
                            {
                                ID = reader["communityID"].ToString(),
                                Name = reader["communityName"].ToString(),
                                OwnerID = reader["communityOwnerID"].ToString(),
                                Description = reader["communityDescription"].ToString(),
                                PictureUrl = reader["communityProfilePictureURL"].ToString(),
                                OwnerPictureUrl = reader["userProfilePicture"].ToString(),
                                OwnerName = firstName + " " + lastName,
                                MemberTotal = Convert.ToInt32(reader["communityMemberTotal"]),
                                PostTotal = Convert.ToInt32(reader["communityPostTotal"]),
                                CreatedDate = reader["communityCreatedDate"].ToString()
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