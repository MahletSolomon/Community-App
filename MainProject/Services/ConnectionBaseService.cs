namespace WpfApp1.Services;

public class ConnectionBaseService
{
   protected string ConnectionString { get; }
    public ConnectionBaseService()
    {
        ConnectionString = "Data Source=mssql-161558-0.cloudclusters.net,10019;Initial Catalog=FinalProjectV1;User Id=admin;Password=Password1";
        
    }
}