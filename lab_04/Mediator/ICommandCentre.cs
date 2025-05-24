namespace Mediator;

public interface ICommandCentre
{
    void HandleLandingRequest(Aircraft aircraft);
    void HandleTakeOffRequest(Aircraft aircraft);
}