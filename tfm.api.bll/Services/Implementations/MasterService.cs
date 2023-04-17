using Microsoft.Extensions.Logging;
using tfm.api.bll.Models.Example;
using tfm.api.bll.Models.Master;
using tfm.api.bll.Services.Contracts;
using tfm.api.dal.Entities;
using tfm.api.dal.Repos.Contracts;
using tfm.api.exceptions;

namespace tfm.api.bll.Services.Implementations
{
    internal sealed class MasterService : IMasterService
    {
        private readonly IUserRepo _users;
        private readonly IMasterRepo _masters;
        private readonly IStyleRepo _styles;
        private readonly IStylePriceRepo _stylePrices;
        private readonly IExamplesService _examples;
        private readonly IPhotoFileService _photoFiles;
        private readonly ILogger<MasterService> _logger;

        public MasterService(IUserRepo userService,
            IMasterRepo masterRepo,
            IStylePriceRepo stylePrice,
            IStyleRepo styleRepo,
            IExamplesService examples,
            IPhotoFileService photoFileService,
            ILogger<MasterService> logger)
        {
            _users = userService;
            _masters = masterRepo;
            _styles = styleRepo;
            _stylePrices = stylePrice;
            _examples = examples;
            _photoFiles = photoFileService;
            _logger = logger;
        }

        public async Task AddExampleAsync(AddMasterExampleModel masterExample)
        {
            if (!await _stylePrices.IsExistAsync(masterExample.MasterId, masterExample.StyleId))
            {
                throw new MissingStyleException(
                    "Master Id or style id is invalid. Ensure style is existing for master before assign.");
            }

            int examplesCount = await _examples.CountAsync(masterExample.MasterId, masterExample.StyleId);

            if (examplesCount == 5)
            {
                throw new TooManyExamplesException("For one style and master allowed less or equal to 5 pics.");
            }

            int exampleId = await _examples.AddAsync(new ExampleEntity()
            {
                MasterId = masterExample.MasterId,
                StyleId = masterExample.StyleId,
                ShortDescription = masterExample.ShortDescription
            });

            if (exampleId == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(exampleId),"Example id can't be less or equals to zero");
            }

            int photoId = await _photoFiles.AddAsync(masterExample.ExamplePhoto, exampleId);

            if (photoId == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(photoId),"Photo id can't be less or equals to zero");
            }

            await _examples.AttachPhotoAsync(exampleId, photoId);
        }

        public async Task DeleteExampleAsync(int exampleId)
        {
            ExampleDto? example = await _examples.GetAsync(exampleId);

            if (example == null)
            {
                _logger.LogWarning("Example doesn't found");
                return;
            }

            await _photoFiles.DeleteAsync(example.PhotoFileId);

            await _examples.DeleteAsync(exampleId);
        }

        public async Task<ShowExampleDto?> GetExampleAsync(int exampleId)
        {
            ExampleDto? example = await _examples.GetAsync(exampleId);

            if (example == null)
            {
                return null;
            }

            return new ShowExampleDto()
            {
                Id = example.Id,
                MasterId = example.MasterId,
                StyleId = example.StyleId,
                PhotoBase64 = await _photoFiles.GetBase64Async(exampleId),
                ShortDescription = example.ShortDescription
            };
        }

        public async Task<int> AddNewAsync(int id)
        {
            UserEntity? user = await _users.FindByIdAsync(id)
                               ?? throw new ArgumentException("Invalid user id.");

            return await _masters.AddNewAsync(user);
        }

        public async Task AddPriceAsync(AddMasterPriceModel newMasterPrice)
        {
            StyleEntity? targetStyle = await _styles.GetAsync(newMasterPrice.StyleId)
                                       ?? throw new NotFoundException(
                                           $"Style not found. Check value = {newMasterPrice.StyleId}");

            MasterEntity? targetMaster = await _masters.GetAsync(newMasterPrice.MasterId)
                                         ?? throw new NotFoundException(
                                             $"Master not found. Check value = {newMasterPrice.MasterId}");

            StylePriceEntity stylePrice = new()
            {
                Master = targetMaster,
                Style = targetStyle,
                Price = newMasterPrice.Price
            };

            await _stylePrices.AddAsync(stylePrice);
        }

        public async Task BlockAsync(int masterId)
        {
            await _masters.BlockAsync(masterId);
        }

        public async Task DeleteAsync(int masterId)
        {
            await _masters.DeleteAsync(masterId);
        }

        public async Task DeletePriceAsync(int stylePriceId)
        {
            await _stylePrices.DeleteAsync(stylePriceId);
        }

        public Task<bool> IsBlockedAsync(int masterId)
        {
            return _masters.IsBlockedAsync(masterId);
        }

        public async Task UnblockAsync(int masterId)
        {
            await _masters.UnblockAsync(masterId);
        }
    }
}