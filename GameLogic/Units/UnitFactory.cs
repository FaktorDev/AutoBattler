using GameLogic.Battles.Manager;
using GameLogic.Battles.System;
using GameLogic.Tools.ShellImporters.ConfigReaders;
using GameLogic.Units.Content.Characters;
using GameLogic.Units.Dtos;

namespace GameLogic.Units;

public class UnitFactory(CharacterConfigReader characterConfigReader)
{
    private readonly CharacterConfigReader _characterConfigReader = characterConfigReader;

    private Unit GetUnit(UnitParameters parameters, Team team, Battle battle)
    {
        return parameters.Id switch
        {
            (int)Enums.Units.Unit0001 => new Unit_0001(parameters, team, _characterConfigReader, battle),
            (int)Enums.Units.Unit2 => new Unit_0002(parameters, team, _characterConfigReader, battle),
            (int)Enums.Units.Unit3 => new Unit_0003(parameters, team, _characterConfigReader, battle),
            (int)Enums.Units.Unit4 => new Unit_0004(parameters, team, _characterConfigReader, battle),
            (int)Enums.Units.Unit5 => new Unit_0005(parameters, team, _characterConfigReader, battle),
            (int)Enums.Units.Unit6 => new Unit_0006(parameters, team, _characterConfigReader, battle),
            (int)Enums.Units.Unit7 => new Unit_0007(parameters, team, _characterConfigReader, battle),
            (int)Enums.Units.Unit8 => new Unit_0008(parameters, team, _characterConfigReader, battle),
            (int)Enums.Units.Unit9 => new Unit_0009(parameters, team, _characterConfigReader, battle),
            (int)Enums.Units.Unit10 => new Unit_0010(parameters, team, _characterConfigReader, battle),
            _ => throw new Exception("unit creation error"),
        };
    }

    internal List<Unit> GetUnits(List<UnitParameters> unitConfigurations, Team team, Battle battle)
    {
        var units = new List<Unit>();

        foreach (var unitConfiguration in unitConfigurations)
        {
            var unit = GetUnit(unitConfiguration, team, battle);
            units.Add(unit);
        }
        return units;
    }
}
