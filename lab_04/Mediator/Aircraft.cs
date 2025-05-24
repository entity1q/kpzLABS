namespace Mediator;

public class Aircraft(string name, ICommandCentre commandCentre)
{
    public string Name { get; } = name;
    public bool IsTakingOff { get; set; } =  true;

    public void RequestLanding()
    {
        Console.WriteLine($"\nAircraft {Name} requesting landing...");
        commandCentre.HandleLandingRequest(this);
    }

    public void RequestTakeOff()
    {
        Console.WriteLine($"\nAircraft {Name} requesting takeoff...");
        commandCentre.HandleTakeOffRequest(this);
    }
}