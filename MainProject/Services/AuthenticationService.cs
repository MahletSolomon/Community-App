using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using MainProject.MVVM.Model;

namespace WpfApp1.Services;

public class AuthenticationService : ConnectionBaseService
{
    private LoginModel _loginModel;
    private Dictionary<string, string> dictionary;

    public AuthenticationService(LoginModel loginModel)
    {
        dictionary = new Dictionary<string, string>();
        _loginModel = loginModel;
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("select * from Users", connection);

    //                DataTable dt = new DataTable();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string userName = reader["userUserName"].ToString();
                    string password = reader["userPassword"].ToString();
                    dictionary[userName] = password;
                }

            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public bool Execute()
    {
        if (dictionary.ContainsKey(_loginModel.Username))
        {
            if (dictionary[_loginModel.Username] == _loginModel.Password)
            {
                return true;
            }
        }
            MessageBox.Show("Username not found");
            return false;
    }
}