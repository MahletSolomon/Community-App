using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using MainProject.MVVM.Model;

namespace WpfApp1.Services;

public class AuthenticationService : ConnectionBaseService
{
    private LoginModel _loginModel;
    private string result;
    public AuthenticationService(LoginModel loginModel)
    {
        _loginModel = loginModel;
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT dbo.CheckUserCredentials(@inputUsername, @inputPassword)", connection))
                {
                    command.Parameters.AddWithValue("@inputUsername", _loginModel.Username);
                    command.Parameters.AddWithValue("@inputPassword", _loginModel.Password);

                    // ExecuteScalar is used for scalar functions that return a single value
                    result = Convert.ToString(command.ExecuteScalar());
                }


               
            }
        }
        catch (Exception ex)
        {
           Debug.WriteLine($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public bool Execute()
    {

        if (result != "")
        {
            return true;
        }
        return false;
    }

    public string GetID()
    {
        return result;
    }
}