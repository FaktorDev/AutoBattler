using GameLogic.Battles.Enums;
using GameLogic.Battles.System;
using GameLogic.BattleSystem.Enums;
using Manager.BattleSystem;
using System.Text.Json.Serialization;

namespace GameLogic.Battles.Dtos;

public class BattleParameters
{
    public int Seed { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BattleTypes BattleType { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DayTimes DayTime { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Tempeturas Tempetura { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Terrains Terrain { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Weathers Weather { get; set; }

    public List<TeamParameters> TeamConfigurations { get; set; }

    public BattleParameters(
        int randomSeed,
        BattleTypes battleType,
        DayTimes dayTime,
        Tempeturas tempetura,
        Terrains terrain,
        Weathers weather,
        List<TeamParameters> teams)
    {
        Seed = randomSeed;
        BattleType = battleType;

        DayTime = dayTime;
        Tempetura = tempetura;
        Terrain = terrain;
        Weather = weather;

        TeamConfigurations = teams;
    }

    public BattleParameters()
    {

    }
}
