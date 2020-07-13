namespace ProjectDicksonBackEnd.Repository
{
    public interface ISql
    {
        string ConnectionStringBuilder();
        void TestConnection();
    }
}