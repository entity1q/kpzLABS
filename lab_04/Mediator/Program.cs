using Mediator;

var commandCentre = new CommandCentre(
    [
        new Runway(),
        new Runway(),
        new Runway(),
    ]
);

var aircraft1 = new Aircraft("Flight-1", commandCentre);
var aircraft2 = new Aircraft("Flight-2", commandCentre);
var aircraft3 = new Aircraft("Flight-3", commandCentre);

aircraft1.RequestLanding();
aircraft2.RequestLanding();
aircraft3.RequestLanding();

aircraft1.RequestTakeOff();
aircraft3.RequestLanding();