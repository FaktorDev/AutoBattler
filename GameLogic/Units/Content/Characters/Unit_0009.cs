﻿using GameLogic.Battles.Manager;
using GameLogic.Battles.System;
using GameLogic.Tools.ShellImporters.ConfigReaders;
using GameLogic.Units.Content.Abilitys;
using GameLogic.Units.Dtos;

namespace GameLogic.Units.Content.Characters;

internal class Unit_0009 : Character
{
    public Unit_0009(UnitParameters config, Team team, CharacterConfigReader pathConfig, Battle battle) : base(config, pathConfig, team, battle)
    {
        Actions.Add(new AbilityAutoAttack(battle, this));
    }
}
