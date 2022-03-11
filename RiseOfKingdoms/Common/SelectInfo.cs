using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RiseOfKingdoms.Commander.CommanderBase;
using static RiseOfKingdoms.Common.Character;
using static RiseOfKingdoms.Common.Commanders;
using static RiseOfKingdoms.Common.Equipment;
using static RiseOfKingdoms.Common.Tiers;

namespace RiseOfKingdoms.Common
{
    internal static class SelectInfo
    {
        public static void SetIsField(CommanderBase commander)
        {
            while (true)
            {
                Console.WriteLine("1. 필드");
                Console.WriteLine("2. 집결");
                Console.WriteLine("3. 수성");
                string numString = Console.ReadLine();
                int num = int.Parse(numString);
                if (num != 1 && num != 2 && num != 3)
                {
                    Console.WriteLine("정확한 번호를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("{0}을(를) 선택하셨습니다.", num == 1? "필드":(num == 2? "집결":"수성"));
                    Console.WriteLine();
                    BattleState battleState = (num == 1 ? BattleState.Field : (num == 2? BattleState.Conquering : BattleState.Garrison));
                    commander.battleState = battleState;
                    break;
                }
            }
        }
        public static void SetCommander(CommanderBase commander, bool isFirst, bool isAttacker)
        {
            while (true)
            {
                foreach (CommanderList data in Enum.GetValues(typeof(CommanderList)))
                {
                    Console.WriteLine((int)data + ". " + data);
                }
                string commanderNum = Console.ReadLine();
                if (Enum.IsDefined(typeof(CommanderList), int.Parse(commanderNum)) == false)
                {
                    Console.WriteLine("정확한 번호를 입력해주세요.");
                }
                else
                {
                    var enumCommander = Enum.Parse(typeof(CommanderList), commanderNum);
                    Console.WriteLine("선택하신 사령관은 {0} 입니다.", Enum.GetName(typeof(CommanderList), int.Parse(commanderNum)));
                    Console.WriteLine();

                    if (isAttacker)
                    {
                        Commanders.atkeyValuePairs[(CommanderList)enumCommander].Init(commander, isFirst);
                        commander.commanderClassList.Add((Commanders.atkeyValuePairs[(CommanderList)enumCommander], isFirst));
                    }
                    else
                    {
                        Commanders.dfkeyValuePairs[(CommanderList)enumCommander].Init(commander, isFirst);
                        commander.commanderClassList.Add((Commanders.dfkeyValuePairs[(CommanderList)enumCommander], isFirst));
                    }
                    break;
                }
            }
        }
        public static void SetTroopType(CommanderBase commander, bool isAttacker)
        {
            while (true)
            {
                foreach (TierList data in Enum.GetValues(typeof(TierList)))
                {
                    Console.WriteLine((int)data + ". " + data);
                }
                string tier = Console.ReadLine();
                if (Enum.IsDefined(typeof(TierList), int.Parse(tier)) == false)
                {
                    Console.WriteLine("정확한 번호를 입력해주세요.");
                }
                else
                {
                    var enumTier = Enum.Parse(typeof(CommanderList), tier);
                    Console.WriteLine("선택하신 병종은 {0} 입니다.", Enum.GetName(typeof(TierList), int.Parse(tier)));
                    Console.WriteLine();
                    if (isAttacker)
                        Tiers.atkeyValuePairs[(TierList)enumTier].Init(commander);
                    else
                        Tiers.dfkeyValuePairs[(TierList)enumTier].Init(commander);
                    break;
                }
            }
        }
        public static void SetTroopAmount(CommanderBase commander)
        {
            while (true)
            {
                int stat;
                string statString = Console.ReadLine();
                if (int.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 부대수는 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.maxTroop = stat;
                    commander.troop = stat;
                    break;
                }
            }
        }
        public static void SetAdditionalAttack(CommanderBase commander)
        {
            while (true)
            {
                double stat;
                string statString = Console.ReadLine();
                if (double.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 추가공격력은 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.additionalAttack += stat;
                    break;
                }
            }
        }
        public static void SetAdditionalDefence(CommanderBase commander)
        {
            while (true)
            {
                double stat;
                string statString = Console.ReadLine();
                if (double.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 추가방어력은 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.additionalDefence += stat;
                    break;
                }
            }
        }
        public static void SetAdditionalHealth(CommanderBase commander)
        {
            while (true)
            {
                double stat;
                string statString = Console.ReadLine();
                if (double.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 추가생명력은 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.additionalHealth += stat;
                    break;
                }
            }
        }


        public static void SetAdditionalDamageIncrease(CommanderBase commander)
        {
            while (true)
            {
                double stat;
                string statString = Console.ReadLine();
                if (double.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 모든피해량은 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.additionalDamageIncrease += stat;
                    break;
                }
            }
        }
        public static void SetAdditionalNormalDamageIncrease(CommanderBase commander)
        {
            while (true)
            {
                double stat;
                string statString = Console.ReadLine();
                if (double.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 일반공격피해량은 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.additionalNormalDamageIncrease += stat;
                    break;
                }
            }
        }
        public static void SetAdditionalCounterDamageIncrease(CommanderBase commander)
        {
            while (true)
            {
                double stat;
                string statString = Console.ReadLine();
                if (double.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 반격피해량은 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.additionalCounterDamageIncrease += stat;
                    break;
                }
            }
        }
        public static void SetAdditionalSkillDamageIncrease(CommanderBase commander)
        {
            while (true)
            {
                double stat;
                string statString = Console.ReadLine();
                if (double.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 스킬피해량은 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.additionalSkillDamageIncrease += stat;
                    break;
                }
            }
        }

        public static void SetAdditionalDamageDecrease(CommanderBase commander)
        {
            while (true)
            {
                double stat;
                string statString = Console.ReadLine();
                if (double.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 모든피해감소량은 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.additionalDamageDecrease += stat;
                    break;
                }
            }
        }
        public static void SetAdditionalNormalDamageDecrease(CommanderBase commander)
        {
            while (true)
            {
                double stat;
                string statString = Console.ReadLine();
                if (double.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 일반피해감소량은 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.additionalNormalDamageDecrease += stat;
                    break;
                }
            }
        }
        public static void SetAdditionalCounterDamageDecrease(CommanderBase commander)
        {
            while (true)
            {
                double stat;
                string statString = Console.ReadLine();
                if (double.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 반격피해감소량은 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.additionalCounterDamageDecrease += stat;
                    break;
                }
            }
        }
        public static void SetAdditionalSkillDamageDecrease(CommanderBase commander)
        {
            while (true)
            {
                double stat;
                string statString = Console.ReadLine();
                if (double.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 스킬피해감소량은 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.additionalSkillDamageDecrease += stat;
                    break;
                }
            }
        }


        public static void SetCharacter(CommanderBase commander)
        {
            while (true)
            {
                foreach (CharacterList data in Enum.GetValues(typeof(CharacterList)))
                {
                    Console.WriteLine((int)data + ". " + data);
                }
                string st = Console.ReadLine();
                st = st.Replace(" ", "");
                string[] stList = st.Split(',');
                if (stList.Length != 3)
                {
                    Console.WriteLine("3개의 특성을 선택해주세요.");
                }
                bool success = true;
                foreach (string ch in stList)
                {
                    int num = int.Parse(ch);
                    if (Enum.IsDefined(typeof(CharacterList), num) == false)
                    {
                        Console.WriteLine("정확한 번호를 입력해주세요.");
                        success = false;
                        break;
                    }
                }
                if (success == true)
                {
                    foreach (string ch in stList)
                    {
                        int num = int.Parse(ch);
                        var enumCharacter = Enum.Parse(typeof(CharacterList), ch);
                        Console.Write("{0} ", Enum.GetName(typeof(CharacterList), num));
                        commander.commanderCharacter.Add((CharacterList)enumCharacter);
                    }   
                    Console.WriteLine("특성을 입력하셨습니다.");
                    Console.WriteLine();
                    break;
                }
            }
        }

        public static void SetSubCharacter(CommanderBase commander, bool isAttacker)
        {
            while (true)
            {
                foreach (var eNum in commander.commanderCharacter)
                {
                    Console.WriteLine("- {0}. 특성번호와 Level을 입력해주세요. ex) 1-3,2-3,4-3", eNum);
                    foreach (var data in Enum.GetValues(Character.CharacterSubCharacterPairs[(CharacterList)eNum].GetType()))
                    {
                        Console.WriteLine((int)data + ". " + data);
                    }
                    string st = Console.ReadLine();
                    st = st.Replace(" ", "");
                    string[] stList = st.Split(',');
                    foreach (string ch in stList)
                    {
                        string[] numCount = ch.Split('-');
                        if (numCount.Length == 1)
                            continue;

                        int num = int.Parse(numCount[0]);
                        int count = int.Parse(numCount[1]);
                        var enumCharacter = Enum.Parse(Character.CharacterSubCharacterPairs[(CharacterList)eNum].GetType(), numCount[0]);
                        Console.Write("{0} {1}단계 ", Enum.GetName(Character.CharacterSubCharacterPairs[(CharacterList)eNum].GetType(), num), count);
                        if (isAttacker == true)
                        {
                            Character.atkeyValuePairs[(Enum)enumCharacter].Init(commander, count);
                            commander.characterClassList.Add((Character.atkeyValuePairs[(Enum)enumCharacter], count));
                        }
                        else
                        {
                            Character.dfkeyValuePairs[(Enum)enumCharacter].Init(commander, count);
                            commander.characterClassList.Add((Character.dfkeyValuePairs[(Enum)enumCharacter], count));
                        }
                    }
                    Console.WriteLine("입력하셨습니다.");
                    Console.WriteLine();
                }
                break;
            }
        }

        public static void SetEquipment(CommanderBase commander, bool isAttacker)
        {
            while (true)
            {
                foreach (EquipmentList data in Enum.GetValues(typeof(EquipmentList)))
                {
                    Console.WriteLine((int)data + ". " + data);
                }
                string st = Console.ReadLine();
                st = st.Replace(" ", "");
                string[] stList = st.Split(',');
                foreach (string ch in stList)
                {
                    int num = int.Parse(ch);
                    if (Enum.IsDefined(typeof(EquipmentList), num) == false)
                    {
                        Console.WriteLine("정확한 번호를 입력해주세요.");
                    }
                    else
                    {
                        var enumEquipment = Enum.Parse(typeof(EquipmentList), ch);
                        Console.WriteLine("선택하신 장비는 {0} 입니다.", Enum.GetName(typeof(EquipmentList), num));
                        Console.WriteLine();
                        if (isAttacker)
                        {
                            Equipment.atkeyValuePairs[(EquipmentList)enumEquipment].Init(commander, (num % 2 == 0 ? true : false));
                            commander.equipmentClassList.Add((Equipment.atkeyValuePairs[(EquipmentList)enumEquipment], (num % 2 == 0 ? true : false)));
                        }
                        else
                        {
                            Equipment.dfkeyValuePairs[(EquipmentList)enumEquipment].Init(commander, (num % 2 == 0 ? true : false));
                            commander.equipmentClassList.Add((Equipment.dfkeyValuePairs[(EquipmentList)enumEquipment], (num % 2 == 0 ? true : false)));
                        }
                    }
                }
                break;
            }
        }

        public static void SetRunType(CommanderBase at, CommanderBase df)
        {
            while (true)
            {
                string numString = Console.ReadLine();
                int num = 0;
                if (int.TryParse(numString, out num) == false || (num < 1 || num > 10000))
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요. 최대 10000까지 입력 가능");
                }
                else
                {
                    if (num == 1)
                    {
                        UsingLog.usingLog = true;
                        Main.Run(at, df, false);
                    }

                    else
                    {
                        UsingLog.usingLog = false;
                        Main.RepeatRun(at, df, num);
                    }
                        
                    break;
                }
            }
        }
    }
}
