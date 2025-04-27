using GameLogic.Battles.Manager;
using GameLogic.Main;
using GameLogic.Units;
using GameLogic.Units.Dtos;

namespace GameLogic.Battles.System;

public class Team
{
    public Guid Token { get; } = Guid.NewGuid();
    public Player Player { get; }
    public List<Unit> Units { get; } = [];

    public Team(TeamParameters configuration, Battle battle, UnitFactory factory)
    {
        Player = configuration.Player;
        Units = factory.GetUnits(configuration.UnitConfigurations, this, battle);
    }

    public bool IsTeamAilve()
    {
        byte AliveSoldiers = 0;
        foreach (var unit in Units)
        {
            if (unit.IsAlive())
                AliveSoldiers++;

        }
        if (AliveSoldiers == 0)
            return false;
        return true;
    }
}

public class TeamParameters
{
    public Player Player { get; set; }
    public List<UnitParameters> UnitConfigurations { get; set; }

    public TeamParameters(Player player, List<UnitParameters> unitConfigurations)
    {
        Player = player;
        UnitConfigurations = unitConfigurations;
    }
}
