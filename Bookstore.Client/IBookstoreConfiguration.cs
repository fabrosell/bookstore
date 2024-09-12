namespace Bookstore.Client
{
    public interface IBookstoreConfiguration
    {
        string Get_API_Base_URL();
        string Get_API_URL(string relative_url);
    }
}