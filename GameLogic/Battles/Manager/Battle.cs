﻿using GameLogic.Battles.Dtos;
using GameLogic.Battles.System;
using GameLogic.Tools.ShellImporters.ConfigReaders;
using GameLogic.Units;
using GameLogic.Units.Actions.Abilitys;
using GameLogic.Units.Actions.Abilitys.Interfaces;
using System.Diagnostics;

namespace GameLogic.Battles.Manager;

public class Battle
{
    // Tools
    private readonly UnitFactory _unitFactory;
    public BattleLogger Logger { get; private set; }

    // Main
    public BattleParameters Parameters { get; }
    public BattleResult BattleResult { get; protected set; }
    public Random Random { get; set; }

    // Battle 
    public ulong Timeline { get; set; } = 0;
    public List<Team> AllTeam { get; protected set; } = [];
    public List<Unit> AllUnits { get; protected set; } = [];
    public List<IBattleAction> AllBattleActions { get; protected set; } = [];

    // Events
    public event EventHandler? OnBattleStart;
    public event EventHandler? OnBattleEnd;
    public event EventHandler? OnBattleDayPassed;

    // Settings
    public bool IsVisual { get; set; } = false;

    // Const
    public const float TIMILINE_MAX_VALUE = 86400000f;

    public Battle(BattleParameters battleConfiguration, CharacterConfigReader characteConfigReader, bool isVisual = false)
    {
        IsVisual = isVisual;

        _unitFactory = new(characteConfigReader);
        Parameters = battleConfiguration;
        Random = new Random(battleConfiguration.Seed);

        InitializeBattleConfiguration();

        Logger = new(DateTime.Now, this);
        BattleResult = new(battleConfiguration, this);

        void InitializeBattleConfiguration()
        {
            foreach (var teamConfig in battleConfiguration.TeamConfigurations)
            {
                AllTeam.Add(new(teamConfig, this, _unitFactory));
            }
            AllUnits = AllTeam.SelectMany(t => t.Units).ToList();
            AllBattleActions = AllUnits
            .SelectMany(u => u.Actions)
            .OfType<IBattleAction>()
            .ToList();
        }   
    }

    public BattleResult CalculateBattle()
    {
        var stopwatch = new Stopwatch();

        try
        {
            StartingBattleCalculation();

            InitializeUnits();
            InitializeTeams();

            OnBattleStart?.Invoke(this, new EventArgs());

            while (BattleResult.Stats.TeamWinner == Guid.Empty) // Game loop
            {
                BattleTick();
                FindAndExecuteAction();
            }

            EndBattleCalculation();
        }
        catch (Exception e)
        {
            Logger.LogError(e.Message);
            return BattleResult;
        }
        return BattleResult;



        void InitializeUnits()
        {
            foreach (var unit in AllUnits)
            {
                unit.OnDead += Unit_OnDead;
            }

            void Unit_OnDead(object? sender, DeadEventArgs e)
            {
                if (sender is Unit unit)
                {
                    foreach (var action in unit.Actions) // Remove the skills of a dead unit
                    {
                        action.RemoveFromBattle();
                    }
                    FindWinner();
                }
            }
        }
        void InitializeTeams() // NEED MAKE BE COMPLEX
        {
            PlaceUnit();

            void PlaceUnit()
            {
                float startPostition = -5f;
                float stepBetweenTeam = 10f;

                foreach (var team in AllTeam)
                {
                    foreach (var unit in team.Units)
                    {
                        unit.TeleportTo(startPostition);
                    }
                    startPostition += stepBetweenTeam;
                }
            }
        }
        void StartingBattleCalculation()
        {
            stopwatch.Start();
        }
        void EndBattleCalculation()
        {
            stopwatch.Stop();
            BattleResult.Stats.ActualDuration = stopwatch.ElapsedMilliseconds;
            BattleResult.EndTime = DateTime.UtcNow;
            BattleResult.Stats.TotalTimeline = Timeline;

            OnBattleEnd?.Invoke(this, new EventArgs());
        }
        void BattleTick()
        {
            if (Timeline > TIMILINE_MAX_VALUE)
            {
                OnBattleDayPassed?.Invoke(this, new EventArgs());
                EndBattleCalculation();
                throw new Exception("The battle has been going on for a very long time");
            }
        }
    }

    private void FindAndExecuteAction()
    {
        if (AllBattleActions.Count <= 0)
            throw new Exception("No BattleAction");

        foreach (var battleAction in AllBattleActions)
        {
            if (battleAction is not IPeriodicAbility)
            {
                battleAction.Action();
                AllBattleActions.Remove(battleAction);
                return;
            }
        }

        var reloadableBattleActions = new List<RechargingAbility>();
        foreach (var battleAction in AllBattleActions)
            reloadableBattleActions.Add((RechargingAbility)battleAction);

        var reloadableBattleAction = reloadableBattleActions.OrderBy(a => a.Time.NextUse).First();

        Timeline = reloadableBattleAction.Time.NextUse;
        reloadableBattleAction.Action();
    }
    private void FindWinner()
    {
        var AliveTeams = new List<Team>();

        foreach (var team in AllTeam)
        {
            if (team.IsTeamAilve())
                AliveTeams.Add(team);
            if (AliveTeams.Count > 1)
                return;
        }

        if (AliveTeams.Count == 0)
            throw new Exception("No alive teams");

        else if (AliveTeams.Count == 1)
        {
            BattleResult.Stats.TeamWinner = AliveTeams.First().Token;
            var team = AllTeam.First(t => t.Token == BattleResult.Stats.TeamWinner);
            Logger.LogCustom("battle-win", $" \nID: {BattleResult.Stats.TeamWinner}\nNAME: {team.Player.Username}\n ");
            return;
        }
        Logger.LogCustom("battle-info", $" No team to win ");
    }
}
