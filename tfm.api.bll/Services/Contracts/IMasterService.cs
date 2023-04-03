using tfm.api.bll.DTO.Master;

namespace tfm.api.bll.Services.Contracts
{
    public interface IMasterService
    {
        Task<int> AddNewAsync(int id);

        Task DeleteAsync(int masterId);

        Task<bool> IsBlockedAsync(int masterId);

        Task BlockAsync(int masterId);

        Task UnblockAsync(int masterId);

        Task AddPriceAsync(AddMasterPriceDto newMaster);

        Task DeletePriceAsync(int stylePriceId);

        Task AddExampleAsync(AddMasterExampleDto masterExample);
    }
}