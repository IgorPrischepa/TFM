using tfm.api.bll.Models.Example;
using tfm.api.bll.Models.Master;

namespace tfm.api.bll.Services.Contracts
{
    public interface IMasterService
    {
        Task<int> AddNewAsync(int id);

        Task DeleteAsync(int masterId);

        Task<bool> IsBlockedAsync(int masterId);

        Task BlockAsync(int masterId);

        Task UnblockAsync(int masterId);

        Task AddPriceAsync(AddMasterPriceModel newMaster);

        Task DeletePriceAsync(int stylePriceId);

        Task AddExampleAsync(AddMasterExampleModel masterExample);
        
        Task DeleteExampleAsync(int exampleId);
        
        Task<ShowExampleDto?> GetExampleAsync(int exampleId);
    }
}