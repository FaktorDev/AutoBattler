using GameLogic.Units.Enums;

namespace GameLogic.Tools.Formulas;

internal class UnitClassFormulas
{
    /// <summary>
    /// Отримати пріорітети атаки кожного класу
    /// </summary>
    public static Dictionary<UnitClasses, float> WeightToSelect(UnitClasses unitClass1, UnitClasses unitClass2)
    {
        const float COEF_POWER_OF_SUB_CLASS = 0.5f;

        var dictionary = new Dictionary<UnitClasses, float>
        {
            { UnitClasses.None, 1f },
            { UnitClasses.Assassin, 1.5f },
            { UnitClasses.Buffer, 0.75f },
            { UnitClasses.Controller, 1f },
            { UnitClasses.Healer, 1f },
            { UnitClasses.Mage, 1f },
            { UnitClasses.Marksman, 1f },
            { UnitClasses.Support, 0.5f },
            { UnitClasses.Tank, 5f },
            { UnitClasses.Warrior, 2.5f },
            { UnitClasses.Universal, 1f }
        };
        ConsiderСlass(dictionary, unitClass1);
        ConsiderСlass(dictionary, unitClass2, COEF_POWER_OF_SUB_CLASS);
        return dictionary;

        static void ConsiderСlass(Dictionary<UnitClasses, float> dictionary, UnitClasses unitClass, float powerCoef = 1f)
        {
            switch (unitClass)
            {
                case UnitClasses.Assassin:
                    dictionary[UnitClasses.Healer] *= 2 * powerCoef;
                    dictionary[UnitClasses.Marksman] *= 2 * powerCoef;
                    dictionary[UnitClasses.Support] *= 2 * powerCoef;
                    dictionary[UnitClasses.Tank] /= 2 * powerCoef;
                    dictionary[UnitClasses.Warrior] /= 2 * powerCoef;
                    break;
                case UnitClasses.Marksman:
                    dictionary[UnitClasses.Assassin] *= 2 * powerCoef;
                    dictionary[UnitClasses.Tank] /= 5 * powerCoef;
                    dictionary[UnitClasses.Warrior] /= 2.5f * powerCoef;
                    break;
                case UnitClasses.Controller:
                    dictionary[UnitClasses.Assassin] *= 2 * powerCoef;
                    dictionary[UnitClasses.Healer] *= 2 * powerCoef;
                    dictionary[UnitClasses.Support] *= 2 * powerCoef;
                    break;
                case UnitClasses.Tank:
                    dictionary[UnitClasses.Assassin] *= 3 * powerCoef;
                    dictionary[UnitClasses.Tank] *= 3 * powerCoef;
                    dictionary[UnitClasses.Warrior] *= 3 * powerCoef;
                    break;

                case UnitClasses.Universal:
                case UnitClasses.Warrior:
                case UnitClasses.Mage:
                case UnitClasses.Buffer:
                case UnitClasses.Support:
                case UnitClasses.Healer:
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
