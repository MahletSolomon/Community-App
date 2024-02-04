using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using MainProject.MVVM.Model;

namespace WpfApp1.Services;

public class UserRegistrationService:ConnectionBaseService
{
    private UserInformationModel _userInformationModel;
    private bool result=false;
    public UserRegistrationService(UserInformationModel userInformationModel)
    {
        _userInformationModel = userInformationModel;
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertIntoUser", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        
                        command.Parameters.AddWithValue("@UserUserName", _userInformationModel.Username);
                        command.Parameters.AddWithValue("@UserFirstName", _userInformationModel.FirstName);

                        if (_userInformationModel.MiddleName!=null)
                        {
                            command.Parameters.AddWithValue("@UserMiddleName", _userInformationModel.MiddleName);
                        }

                        command.Parameters.AddWithValue("@UserLastName", _userInformationModel.LastName);
                        command.Parameters.AddWithValue("@UserEmail", _userInformationModel.Email);
                        command.Parameters.AddWithValue("@UserPassword", _userInformationModel.Password);
                        command.Parameters.AddWithValue("@UserGender", _userInformationModel.Gender);
                        command.Parameters.AddWithValue("@UserDOB", _userInformationModel.DateOfBirth);
                        if (_userInformationModel.ProfilePictureUrl != null)
                        {
                            command.Parameters.AddWithValue("@UserProfilePicture", _userInformationModel.ProfilePictureUrl);
                        }
                        command.ExecuteNonQuery();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        result = false;

                    }
                }


               
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

   public bool GetResult()
    {
        return result;
    }
}