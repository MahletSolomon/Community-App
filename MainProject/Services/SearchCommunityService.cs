using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace MainProject.Services;

public class SearchCommunityService:ConnectionBaseService
{
    private ObservableCollection<CommunityCardModel> _communityCardModels;
    public SearchCommunityService(ObservableCollection<CommunityCardModel> communityCardModels)
    {
        _communityCardModels = communityCardModels;
    }

    public void Execute(string SearchPattern)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM SearchCommunity(@SearchPattern)", connection))
            {
                try
                {
                  
                    connection.Open();
                    command.Parameters.AddWithValue("@SearchPattern", SearchPattern);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                _communityCardModels.Add(new CommunityCardModel
                                {
                                    MemberTotal = reader["communityMemberTotal"].ToString(),
                                    PictureUrl = reader["communityProfilePictureURL"].ToString(),
                                    PostTotal = int.Parse(reader["communityPostTotal"].ToString()),
                                    CreatedDate = DateTime.Parse(reader["communityCreatedDate"].ToString()),
                                    Name = reader["communityName"].ToString(),
                                    ID = int.Parse(reader["communityID"].ToString())
                                });
                            });
                        }

                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
    
}