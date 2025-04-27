using GameLogic.Battles.Manager;
using GameLogic.Battles.System;

namespace GameLogic.Units.Actions;

public abstract class UnitAction(Battle battle, Unit unit) : BattleAction(battle)
{
    protected Unit _unit = unit;

    protected virtual void RemoveLogic()
    {
        _battle.AllBattleActions.Remove(this);
    }
}
