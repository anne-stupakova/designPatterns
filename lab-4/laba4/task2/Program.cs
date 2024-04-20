namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandCentre commandCentre = new CommandCentre();
            Runway runway1 = new Runway();
            Runway runway2 = new Runway();

            commandCentre.AddRunway(runway1);
            commandCentre.AddRunway(runway2);

            Aircraft boeing = new Aircraft("Boeing");
            Aircraft airbus = new Aircraft("Airbus");

            commandCentre.AddAircraft(boeing);
            commandCentre.AddAircraft(airbus);

            boeing.Land();
            airbus.Land();
            boeing.TakeOff();
            airbus.TakeOff();
        }
    }
}
