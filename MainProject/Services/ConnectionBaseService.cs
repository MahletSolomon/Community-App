namespace WpfApp1.Services;

public class ConnectionBaseService
{
   protected string ConnectionString { get; }
    public ConnectionBaseService()
    {
        ConnectionString = "Data Source=mssql-162161-0.cloudclusters.net,19999;Initial Catalog=FinalProjectV1;User Id=admin;Password=Password1";
        
    }
}