using System.Data;
using DatabasesComplusory.Application.Events;
using DatabasesComplusory.Application.Interfaces;
using DatabasesComplusory.Domain.Entities.Write;
using DatabasesComplusory.Domain.Interfaces;

namespace DatabasesComplusory.Application.Commands.ListingCommands;

public class CreateListingCommandHandler
{
    private readonly IListingRepository _listingRepository;
    private readonly IBlobStorageService _blobStorageService;
    private readonly IMediaRepository _mediaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventBus _eventBus;
    
    public CreateListingCommandHandler(IListingRepository listingRepository, IBlobStorageService blobStorageService, IMediaRepository mediaRepository, IEventBus eventBus, IUnitOfWork unitOfWork)
    {
        _listingRepository = listingRepository;
        _blobStorageService = blobStorageService;
        _mediaRepository = mediaRepository;
        _eventBus = eventBus;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Listing> HandleAsync(CreateListingCommand command)
    {
        using var transaction = await _unitOfWork.BeginTransactionAsync(IsolationLevel.Serializable);

        try
        {
            var listing = new Listing
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                Quantity = command.Quantity,
                SellerId = command.SellerId,
            };

            var created = await _listingRepository.AddAsync(listing);
            await _unitOfWork.SaveChangesAsync();
            var allMedias = new List<Media>();
            foreach (var file in command.Media)
            {
                var uri = await _blobStorageService.UploadFileAsync("media", file.OpenReadStream(), file.FileName,
                    file.ContentType);
                var media = new Media
                {
                    ListingId = created.ListingId,
                    Url = uri
                };
                var createdMedia = await _mediaRepository.AddAsync(media);
                allMedias.Add(createdMedia);
            }

            await _unitOfWork.SaveChangesAsync();
            var listingCreatedEvent = new ListingCreatedEvent
            {
                ListingId = created.ListingId,
                Name = created.Name,
                Description = created.Description,
                Price = created.Price,
                SellerId = created.SellerId,
                Quantity = created.Quantity,
                Media = allMedias
            };

            await _eventBus.Publish(listingCreatedEvent);
            await _unitOfWork.CommitAsync();
            return created;

        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
        
    }
    
    
}