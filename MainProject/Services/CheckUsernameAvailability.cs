using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;

namespace WpfApp1.Services;

public class CheckUsernameAvailability:ConnectionBaseService
{
    private bool result;
    public CheckUsernameAvailability(string username)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SELECT dbo.CheckUsernameAvailability(@inputUsername)", connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@inputUsername", username);

                     result = (bool)command.ExecuteScalar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }

    public bool GetResult()
    {
        return result;
    }
}