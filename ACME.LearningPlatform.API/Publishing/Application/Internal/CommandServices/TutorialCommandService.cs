using ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningPlatform.API.Publishing.Domain.Services;
using ACME.LearningPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningPlatform.API.Publishing.Application.Internal.CommandServices;

public class TutorialCommandService: ITutorialCommandService
{
    private readonly ITutorialRepository _tutorialRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TutorialCommandService(ITutorialRepository tutorialRepository, IUnitOfWork unitOfWork)
    {
        _tutorialRepository = tutorialRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Tutorial> Handle(AddVideoAssetToTutorialCommand command)
    {
        var tutorial = await _tutorialRepository.FindByIdAsync(command.TutorialId);
        if (tutorial is null)
        {
            throw new Exception("Tutorial not found");
        }
        tutorial.AddVideo(command.VideoUrl);
        await _unitOfWork.CompleteAsync();
        return tutorial;
    }
}