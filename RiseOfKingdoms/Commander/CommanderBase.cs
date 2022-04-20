using RiseOfKingdoms.Characteristic;
using RiseOfKingdoms.Common;
using RiseOfKingdoms.Equip;
using RiseOfKingdoms.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RiseOfKingdoms.Common.MethodBase;
using static RiseOfKingdoms.Skill.SkillBase;

namespace RiseOfKingdoms.Commander
{
    internal class CommanderBase
    {
        public string site = string.Empty;

        public double maxTroop = 0;
        public double troop = 0;
        // 방패피해흡수량
        public double shield = 0;
        public int shieldTurn = 0;

        // 침묵효과. 
        public int silenceTurn = 0;
        public double maxRage = 1000;
        public double rage = 0;
        // 금수효과
        public int forbiddenTurn = 0;
        // 피의갈증효과
        public int thirstForBloodTurn = 0;
        public double thirstForBloodFactor = 0;
        
        public enum BattleState { Field, Conquering, Garrison }
        public BattleState battleState = BattleState.Field;

        // 병종
        public enum ArmyType { Infantry, Cavalry, Archer, Mixed }
        public ArmyType armyType = ArmyType.Infantry;

        // 병종별 기본 능력
        public double baseAttack = 0;
        public double baseDefence = 0;
        public double baseHealth = 0;

        // 연구+장비+사령관 패시브+특성+스킨+문명 총합
        public double additionalAttack = 0;
        public double additionalDefence = 0;
        public double additionalHealth = 0;
        public double additionalDamageIncrease = 0;
        public double additionalDamageDecrease = 0;
        public double additionalSkillDamageIncrease = 0;
        public double additionalSkillDamageDecrease = 0;
        public double additionalNormalDamageIncrease = 0;
        public double additionalNormalDamageDecrease = 0;
        public double additionalCounterDamageIncrease = 0;
        public double additionalCounterDamageDecrease = 0;
        public double additionalSpeedIncrease = 0;
        public double additionalHealingEffect = 0;

        // 패시브 스킬 등으로 인한 임시 증감분. 다음턴에 초기화
        public double ragePlus = 0;
        public double rageMinus = 0;
        public double normalAttackDamage = 0;
        public double counterAttackDamage = 0;
        public double skillDamage = 0;
        public double additionalSkillDamage = 0;
        public double heal = 0;
        public bool isSkillUsed = false;
        public double tempAttack = 0;
        public double tempDefence = 0;
        public double tempHealth = 0;
        public double tempDamageIncrease = 0;
        public double tempDamageDecrease = 0;
        public double tempSkillDamageIncrease = 0;
        public double tempSkillDamageDecrease = 0;
        public double tempNormalDamageIncrease = 0;
        public double tempNormalDamageDecrease = 0;
        public double tempCounterDamageIncrease = 0;
        public double tempCounterDamageDecrease = 0;
        public double tempSpeedIncrease = 0;
        public double tempAdditionalSkillDamageIncrease = 0;
        public double tempHealingEffect = 0;
        public bool tempSkillDamageIncreaseCancel = false;

        // 액티브 스킬로 인한 증감분
        public double activeAttack_bf = 0;
        public double activeAttack_dbf = 0;
        public double activeDefence_bf = 0;
        public double activeDefence_dbf = 0;
        public double activeHealth_bf = 0;
        public double activeHealth_dbf = 0;
        public double activeDamageIncrease_bf = 0;
        public double activeDamageIncrease_dbf = 0;
        public double activeDamageDecrease_bf = 0;
        public double activeDamageDecrease_dbf = 0;
        public double activeSkillDamageIncrease_bf = 0;
        public double activeSkillDamageIncrease_dbf = 0;
        public double activeSkillDamageDecrease_bf = 0;
        public double activeSkillDamageDecrease_dbf = 0;
        public double activeNormalDamageIncrease_bf = 0;
        public double activeNormalDamageIncrease_dbf = 0;
        public double activeNormalDamageDecrease_bf = 0;
        public double activeNormalDamageDecrease_dbf = 0;
        public double activeCounterDamageIncrease_bf = 0;
        public double activeCounterDamageIncrease_dbf = 0;
        public double activeCounterDamageDecrease_bf = 0;
        public double activeCounterDamageDecrease_dbf = 0;
        public double activeSpeedIncrease_bf = 0;
        public double activeSpeedIncrease_dbf = 0;
        public double activeHealingEffect_bf = 0;
        public double activeHealingEffect_dbf = 0;

        public List<DelegateMethod> before_skill;
        public List<DelegateMethod> after_skill;
        public List<DelegateMethod> active_skill;
        public Queue<DelegateMethod> active_skill_queue;
        public List<List<DelegateMethod>> active_skill_bonus_list;
        public List<List<DelegateMethod>> before_skill_bonus_list;

        public List<(MethodBase, bool)> commanderClassList;
        public List<(MethodBase, int)> characterClassList;
        public List<(MethodBase, bool)> equipmentClassList;

        public List<Enum> commanderCharacter;

        public CommanderBase()
        {
            before_skill = new List<DelegateMethod>();
            active_skill = new List<DelegateMethod>();
            after_skill = new List<DelegateMethod>();
            active_skill_queue = new Queue<DelegateMethod>();
            active_skill_bonus_list = new List<List<DelegateMethod>>();
            before_skill_bonus_list = new List<List<DelegateMethod>>();
            commanderCharacter = new List<Enum>();
            commanderClassList = new List<(MethodBase, bool)>();
            characterClassList = new List<(MethodBase, int)>();
            equipmentClassList = new List<(MethodBase, bool)>();
        }

        public void Final()
        {
            ragePlus = 0;
            rageMinus = 0;
            normalAttackDamage = 0;
            counterAttackDamage = 0;
            skillDamage = 0;
            additionalSkillDamage = 0;
            heal = 0;
            isSkillUsed = false;
            tempAttack = 0;
            tempDefence = 0;
            tempHealth = 0;
            tempDamageIncrease = 0;
            tempDamageDecrease = 0;
            tempSkillDamageIncrease = 0;
            tempSkillDamageDecrease = 0;
            tempNormalDamageIncrease = 0;
            tempNormalDamageDecrease = 0;
            tempCounterDamageIncrease = 0;
            tempCounterDamageDecrease = 0;
            tempSpeedIncrease = 0;
            tempAdditionalSkillDamageIncrease = 0;
            tempHealingEffect = 0;
            silenceTurn--;
            forbiddenTurn--;
            shieldTurn--;
            thirstForBloodTurn--;
            if (shieldTurn == 0)
                shield = 0;
            tempSkillDamageIncreaseCancel = false;
        }

        public void Reset()
        {
            troop = maxTroop;
            shield = 0;
            rage = 0;
            silenceTurn = 0;
            forbiddenTurn = 0;
            shieldTurn = 0;
            thirstForBloodTurn = 0;
            thirstForBloodFactor = 0;
            activeAttack_bf = 0;
            activeAttack_dbf = 0;
            activeDefence_bf = 0;
            activeDefence_dbf = 0;
            activeHealth_bf = 0;
            activeHealth_dbf = 0;
            activeDamageIncrease_bf = 0;
            activeDamageIncrease_dbf = 0;
            activeDamageDecrease_bf = 0;
            activeDamageDecrease_dbf = 0;
            activeSkillDamageIncrease_bf = 0;
            activeSkillDamageIncrease_dbf = 0;
            activeSkillDamageDecrease_bf = 0;
            activeSkillDamageDecrease_dbf = 0;
            activeNormalDamageIncrease_bf = 0;
            activeNormalDamageIncrease_dbf = 0;
            activeNormalDamageDecrease_bf = 0;
            activeNormalDamageDecrease_dbf = 0;
            activeCounterDamageIncrease_bf = 0;
            activeCounterDamageIncrease_dbf = 0;
            activeCounterDamageDecrease_bf = 0;
            activeCounterDamageDecrease_dbf = 0;
            activeSpeedIncrease_bf = 0;
            activeSpeedIncrease_dbf = 0;
            maxRage = 1000;

            before_skill = new List<DelegateMethod>();
            active_skill = new List<DelegateMethod>();
            after_skill = new List<DelegateMethod>();
            active_skill_queue = new Queue<DelegateMethod>();
            active_skill_bonus_list = new List<List<DelegateMethod>>();
            before_skill_bonus_list = new List<List<DelegateMethod>>();
            foreach (var data in commanderClassList)
            {
                data.Item1.Init(this, data.Item2);
            }
            foreach (var data in characterClassList)
            {
                data.Item1.Init(this, cnt : data.Item2);
            }
            foreach (var data in equipmentClassList)
            {
                data.Item1.Init(this, data.Item2);
            }
            
        }

    }
}
