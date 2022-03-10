using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Calculate
{
    internal static class CalcDamage
    {
        public static double CalcMatchEffect(CommanderBase at, CommanderBase df)
        {
            double matchEffect = 0;
            if ((at.armyType == CommanderBase.ArmyType.Infantry && df.armyType == CommanderBase.ArmyType.Cavalry) ||
                (at.armyType == CommanderBase.ArmyType.Cavalry && df.armyType == CommanderBase.ArmyType.Archer) ||
                (at.armyType == CommanderBase.ArmyType.Archer && df.armyType == CommanderBase.ArmyType.Infantry))
                matchEffect = 5;
            else if ((at.armyType == CommanderBase.ArmyType.Infantry && df.armyType == CommanderBase.ArmyType.Archer) ||
                (at.armyType == CommanderBase.ArmyType.Cavalry && df.armyType == CommanderBase.ArmyType.Infantry) ||
                (at.armyType == CommanderBase.ArmyType.Archer && df.armyType == CommanderBase.ArmyType.Cavalry))
                matchEffect = -5;
            return matchEffect;
        }
        public static double CalcActiveSkillDamage(CommanderBase at, CommanderBase df, double factor, bool applyNow = true)
        {
            double matchEffect = CalcMatchEffect(at, df);

            double skillDamagePlus = at.additionalSkillDamageIncrease + at.tempSkillDamageIncrease + at.activeSkillDamageIncrease_bf;
            if (at.tempSkillDamageIncreaseCancel == true)
                skillDamagePlus = 0;

            double damage = factor * 0.005 / 0.00517
                * Math.Sqrt(at.troop) 
                * (at.baseAttack * (100 + at.additionalAttack + +at.tempAttack + at.activeAttack_bf - at.activeAttack_dbf) / 100.0) 
                * ((100 + matchEffect + at.additionalDamageIncrease + at.tempDamageIncrease + skillDamagePlus
                + at.activeDamageIncrease_bf - at.activeDamageIncrease_dbf - at.activeSkillDamageIncrease_dbf 
                - (df.additionalDamageDecrease + df.tempDamageDecrease + df.additionalSkillDamageDecrease + df.tempSkillDamageDecrease
                + df.activeDamageDecrease_bf - df.activeDamageDecrease_dbf + df.activeSkillDamageDecrease_bf - df.activeSkillDamageDecrease_dbf)) / 100.0) 
                * (1 + (at.troop + df.troop) / 1000000.0)
                / ((df.baseDefence * (100 + df.additionalDefence + df.tempDefence + df.activeDefence_bf - df.activeDefence_dbf) / 100.0) 
                * (df.baseHealth * (100 + df.additionalHealth + df.tempHealth + df.activeHealth_bf - df.activeHealth_dbf)/100.0));

            if (applyNow == true)
                df.skillDamage += damage;

            return damage;
        }
        public static void CalcAdditionalSkillDamage(CommanderBase df, double damage)
        {
            df.skillDamage += damage;
        }
        public static void CalcNormalDamage(CommanderBase at, CommanderBase df, double factor = 1 / 0.00517)
        {
            double matchEffect = CalcMatchEffect(at, df);
            double damage = factor
                * Math.Sqrt(at.troop)
                * (at.baseAttack * (100 + at.additionalAttack + at.tempAttack + at.activeAttack_bf - at.activeAttack_dbf) / 100.0)
                * ((100 + matchEffect + at.additionalDamageIncrease + at.tempDamageIncrease + at.additionalNormalDamageIncrease + at.tempNormalDamageIncrease
                + at.activeDamageIncrease_bf - at.activeDamageIncrease_dbf + at.activeNormalDamageIncrease_bf - at.activeNormalDamageIncrease_dbf
                - (df.additionalDamageDecrease + df.tempDamageDecrease + df.additionalNormalDamageDecrease + df.tempNormalDamageDecrease
                + df.activeDamageDecrease_bf - df.activeDamageDecrease_dbf + df.activeNormalDamageDecrease_bf - df.activeNormalDamageDecrease_dbf)) / 100.0)
                * (1 + (at.troop + df.troop) / 1000000.0)
                / ((df.baseDefence * (100 + df.additionalDefence + df.tempDefence + df.activeDefence_bf - df.activeDefence_dbf) / 100.0)
                * (df.baseHealth * (100 + df.additionalHealth + df.tempHealth + df.activeHealth_bf - df.activeHealth_dbf) / 100.0));

            df.normalAttackDamage += damage;
            at.ragePlus += 86;
        }
        public static void CalcCounterDamage(CommanderBase at, CommanderBase df, double factor = 1 / 0.00517)
        {
            double matchEffect = CalcMatchEffect(at, df);
            double damage = factor
                * Math.Sqrt(at.troop)
                * (at.baseAttack * (100 + at.additionalAttack + at.tempAttack + at.activeAttack_bf - at.activeAttack_dbf) / 100.0)
                * ((100 + matchEffect + at.additionalDamageIncrease + at.tempDamageIncrease + at.additionalNormalDamageIncrease + at.tempNormalDamageIncrease + at.additionalCounterDamageIncrease + at.tempCounterDamageIncrease
                + at.activeDamageIncrease_bf - at.activeDamageIncrease_dbf + at.activeNormalDamageIncrease_bf - at.activeNormalDamageIncrease_dbf + at.activeCounterDamageIncrease_bf - at.activeCounterDamageIncrease_dbf
                - (df.additionalDamageDecrease + df.tempDamageDecrease + df.additionalNormalDamageDecrease + df.tempNormalDamageDecrease + df.additionalCounterDamageDecrease + df.tempCounterDamageDecrease
                + df.activeDamageDecrease_bf - df.activeDamageDecrease_dbf + df.activeNormalDamageDecrease_bf - df.activeNormalDamageDecrease_dbf + df.activeCounterDamageDecrease_bf - df.activeCounterDamageDecrease_dbf)) / 100.0)
                * (1 + (at.troop + df.troop) / 1000000.0)
                / ((df.baseDefence * (100 + df.additionalDefence + df.tempDefence + df.activeDefence_bf - df.activeDefence_dbf) / 100.0)
                * (df.baseHealth * (100 + df.additionalHealth + df.tempHealth + df.activeHealth_bf - df.activeHealth_dbf) / 100.0));

            df.counterAttackDamage += damage;
            at.ragePlus += 16;
        }
        public static double CalcHealingEffect(CommanderBase at, CommanderBase df, double factor)
        {
            double heal = factor
                * Math.Sqrt(at.troop)
                * at.baseAttack
                * ((100 + at.additionalHealingEffect + at.tempHealingEffect) / 100.0)
                / (at.baseDefence * at.baseHealth);

            at.heal += heal;

            return heal;
        }

    }
}
