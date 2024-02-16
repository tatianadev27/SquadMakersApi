namespace Domain.Services
{
    public interface IJokeServiceFactory
    {
        IJokeService Create(string type);
    }
}
