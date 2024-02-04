using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace MainProject.Services;

public class CreateCommunityService:ConnectionBaseService
{
    private CreateCommunityViewModel _createCommunityViewModel;
    public CreateCommunityService(CreateCommunityViewModel createCommunityViewModel)
    {
        _createCommunityViewModel = createCommunityViewModel;
    }

    public void Execute()
    {
        CommunityCardModel communityCardModel = new CommunityCardModel()
        {
            Name = _createCommunityViewModel.CommunityCardModel.Name,
            OwnerID = _createCommunityViewModel.LoginModel.ID,
            Description = _createCommunityViewModel.CommunityCardModel.Description,
            PictureUrl = _createCommunityViewModel.CommunityCardModel.PictureUrl,
            CreatedDate = DateTime.Today,
            MemberTotal = "1",
            PostTotal = 0,
            OwnerPictureUrl = _createCommunityViewModel.HomeViewModel._userInformationModel.ProfilePictureUrl,
            OwnerName = _createCommunityViewModel.HomeViewModel._userInformationModel.FirstName + " " +_createCommunityViewModel.HomeViewModel._userInformationModel.LastName

        };
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertIntoCommunity", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@communityName", communityCardModel.Name);
                    command.Parameters.AddWithValue("@userID", communityCardModel.OwnerID);
                    command.Parameters.AddWithValue("@communityDescription", communityCardModel.Description);
                    command.Parameters.AddWithValue("@communityProfilePictureURL", communityCardModel.PictureUrl);
                    SqlParameter outputParam = new SqlParameter("@communityID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParam);
                    command.ExecuteNonQuery();
                    communityCardModel.ID = Convert.ToInt32(outputParam.Value);
                }
                _createCommunityViewModel.HomeViewModel.CommunityCardModels.Add(communityCardModel);
                _createCommunityViewModel.NewCommunityWindow.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }
}