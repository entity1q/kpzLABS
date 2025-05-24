namespace Mediator;

public class CommandCentre : ICommandCentre
{
    private readonly List<Runway> _runways;
    private readonly Dictionary<Runway, Aircraft?> _runwayStatus;

    public CommandCentre(IEnumerable<Runway> runways)
    {
        _runways = new List<Runway>(runways.ToList());
        _runwayStatus = _runways.ToDictionary(r => r, Aircraft? (_) => null);
    }

    public void HandleLandingRequest(Aircraft aircraft)
    {
        if (!aircraft.IsTakingOff)
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is already on a runway.");
            return;
        }
        
        foreach (var runway in _runways)
        {
            Console.WriteLine("Checking runway...");
            if (_runwayStatus[runway] == null)
            {
                runway.HighLightGreen();
                Console.WriteLine($"Aircraft {aircraft.Name} is landing on runway {runway.Id}.");
                _runwayStatus[runway] = aircraft;
                aircraft.IsTakingOff = false;
                return;
            }

            runway.HighLightRed();
        }

        Console.WriteLine($"No free runways for aircraft {aircraft.Name}.");
    }

    public void HandleTakeOffRequest(Aircraft aircraft)
    {
        foreach (var runway in _runways.Where(runway => _runwayStatus[runway] == aircraft))
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is taking off from runway {runway.Id}.");
            _runwayStatus[runway] = null;
            aircraft.IsTakingOff = true;
            runway.HighLightGreen();
            return;
        }

        Console.WriteLine($"Aircraft {aircraft.Name} is not on any runway.");
    }
}