namespace WpfApp1.Services;

public class ConnectionBaseService
{
   protected string ConnectionString { get; }
    public ConnectionBaseService()
    {
        ConnectionString = "Data Source=mssql-162881-0.cloudclusters.net,15342;Initial Catalog=FinalProjectV2;User Id=admin;Password=Password1";
        
    }
}