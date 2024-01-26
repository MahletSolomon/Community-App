using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using MainProject.MVVM.Model;

namespace WpfApp1.Services;

public class RetrieveUserInformationService:ConnectionBaseService
{
    private string _userID;
    private UserInformationModel _userInformationModel;
    
    public RetrieveUserInformationService(string userID)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetUserByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            _userInformationModel = new UserInformationModel()
                            {
                                Id = reader["userID"].ToString(),
                                Username = reader["userUserName"].ToString(),
                                FirstName = reader["userFirstName"].ToString(),
                                LastName = reader["userLastName"].ToString(),
                                Email = reader["userEmail"].ToString(),
                                Gender = reader["userGender"].ToString(),
                                DateOfBirth = reader["userDOB"].ToString(),
                                ProfilePictureUrl = reader["userProfilePicture"].ToString(),
                            };
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

    public UserInformationModel GetInformation()
    {
        return _userInformationModel;
    }
    
}