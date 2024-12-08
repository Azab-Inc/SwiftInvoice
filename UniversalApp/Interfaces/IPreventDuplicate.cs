namespace UniversalApp.Interfaces
{
    public interface IPreventDuplicate<T>
    {
        bool alreadyExists(int userId, string search);
    }
}
