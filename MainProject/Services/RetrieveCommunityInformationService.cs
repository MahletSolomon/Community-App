using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Services;

public class RetrieveCommunityInformationService:ConnectionBaseService
{
    private ObservableCollection<CommunityCardModel> _communityCardModels;
    public string _userID;
    private HomeViewModel _homeViewModel;
    public RetrieveCommunityInformationService(ObservableCollection<CommunityCardModel> CommunityCardModels,string UserID,HomeViewModel homeViewModel=null)
    {
        _communityCardModels = CommunityCardModels;
        _userID = UserID;
        _homeViewModel = homeViewModel;
    }
    
    public async void Execute()
    {
        _homeViewModel.IsLoading = true;
        try
        {
            await RunQuery();

        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        _homeViewModel.IsLoading = false;
    }

    private async Task RunQuery()
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
                                ID = int.Parse(reader["communityID"].ToString()),
                                Name = reader["communityName"].ToString(),
                                OwnerID = reader["communityOwnerID"].ToString(),
                                Description = reader["communityDescription"].ToString(),
                                PictureUrl = reader["communityProfilePictureURL"].ToString(),
                                OwnerPictureUrl = reader["userProfilePicture"].ToString(),
                                OwnerName = firstName + " " + lastName,
                                MemberTotal = reader["communityMemberTotal"].ToString(),
                                PostTotal = reader["communityPostTotal"].ToString(),
                                CreatedDate = DateTime.Parse(reader["communityCreatedDate"].ToString())
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