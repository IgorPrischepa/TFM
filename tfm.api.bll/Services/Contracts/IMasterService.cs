namespace tfm.api.bll.Services.Contracts
{
    public interface IMasterService
    {
        Task<int> AddNewAsync(int id);

        Task DeleteAsync(int masterId);

        Task<bool> IsBlockedAsync(int masterId);

        Task BlockAsync(int masterId);

        Task UnblockAsync(int masterId);
    }
}