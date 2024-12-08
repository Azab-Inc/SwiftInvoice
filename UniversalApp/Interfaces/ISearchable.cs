namespace UniversalApp.Interfaces
{
    public interface ISearchable<T>
    {
        public List<T> dbSearch(int userId, string search);
    }
}
