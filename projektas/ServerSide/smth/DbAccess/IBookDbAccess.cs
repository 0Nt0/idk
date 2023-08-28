namespace smth.DbAccess
{
    public interface IBookDbAccess
    {
        Task<List<T>> LoadInfo<T, U>(string info, U need, string connect);
        Task SaveInfo<T>(string info, T need, string connect);
    }
}