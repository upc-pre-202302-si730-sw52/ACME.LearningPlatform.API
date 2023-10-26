using ACME.LearningPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningPlatform.API.Publishing.Interfaces.Transform;

public static class AddVideoAssetToTutorialCommandFromResourceAssembler
{
    public static AddVideoAssetToTutorialCommand ToCommandFromResource(AddVideoAssetResource addVideoAssetResource,
        int tutorialId)
    {
        return new AddVideoAssetToTutorialCommand(addVideoAssetResource.VideoUrl, tutorialId);
    }
}