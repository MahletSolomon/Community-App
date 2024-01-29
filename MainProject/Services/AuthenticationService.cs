using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MainProject.MVVM.Model;

namespace WpfApp1.Services;

public class AuthenticationService : ConnectionBaseService
{
    private LoginModel _loginModel;
    private string result;
    public AuthenticationService()
    {
       
    }

    public async Task Execute(LoginModel loginModel)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT dbo.CheckUserCredentials(@inputUsername, @inputPassword)", connection))
                {
                    command.Parameters.AddWithValue("@inputUsername", loginModel.Username);
                    command.Parameters.AddWithValue("@inputPassword", loginModel.Password);

                    // ExecuteScalar is used for scalar functions that return a single value
                    result = Convert.ToString(command.ExecuteScalar());
                }


               
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
    }

    public bool GetResult()
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