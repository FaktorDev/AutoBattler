namespace GameLogic.Units.Enums;

public enum UnitClasses
{
    None = 0,
    Assassin,
    Buffer,
    Controller,
    Healer,
    Mage,
    Marksman,
    Support,
    Tank,
    Warrior,
    Universal,
}

public static class EUnitClassParse
{
    public static UnitClasses Parse(string data)
    {
        return data switch
        {
            "Assassin" => UnitClasses.Assassin,
            "Buffer" => UnitClasses.Buffer,
            "Controller" => UnitClasses.Controller,
            "Healer" => UnitClasses.Healer,
            "Mage" => UnitClasses.Mage,
            "Marksman" => UnitClasses.Marksman,
            "Support" => UnitClasses.Support,
            "Tank" => UnitClasses.Tank,
            "Warrior" => UnitClasses.Warrior,
            "Universal" => UnitClasses.Universal,
            _ => UnitClasses.None,
        };
    }

    public static string Parse(UnitClasses data)
    {
        return data switch
        {
            UnitClasses.Assassin => "Assassin",
            UnitClasses.Buffer => "Buffer",
            UnitClasses.Controller => "Controller",
            UnitClasses.Healer => "Healer",
            UnitClasses.Mage => "Mage",
            UnitClasses.Marksman => "Marksman",
            UnitClasses.Support => "Support",
            UnitClasses.Tank => "Tank",
            UnitClasses.Warrior => "Warrior",
            UnitClasses.Universal => "Universal",
            _ => "None",
        };
    }
}