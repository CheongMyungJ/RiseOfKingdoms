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
using System.IO;

namespace RiseOfKingdoms.Common
{
    internal static class SelectInfo
    {
        public static void SetIsField(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                Console.WriteLine("1. 필드");
                Console.WriteLine("2. 집결");
                Console.WriteLine("3. 주둔");
                string str = (sr == null ? Console.ReadLine() : sr.ReadLine());
                int num;
                if (int.TryParse(str, out num) == true)
                {
                    if (num != 1 && num != 2 && num != 3)
                    {
                        Console.WriteLine("정확한 번호를 입력해주세요.");
                        continue;
                    }
                }
                else
                {
                    if (str != "필드" && str != "집결" && str != "주둔")
                    {
                        Console.WriteLine("정확한 이름을 입력해주세요.");
                        continue;
                    }
                }
                Console.WriteLine("{0}을(를) 선택하셨습니다.", num == 0? str : num == 1? "필드":(num == 2? "집결":"주둔"));
                Console.WriteLine();
                BattleState battleState = (num == 0? (str == "필드"? BattleState.Field : (str == "집결"? BattleState.Conquering : BattleState.Garrison)) :(num == 1 ? BattleState.Field : (num == 2 ? BattleState.Conquering : BattleState.Garrison)));
                commander.battleState = battleState;
                break;
                
            }
        }
        public static void SetCommander(CommanderBase commander, bool isFirst, bool isAttacker, StreamReader sr)
        {
            while (true)
            {
                foreach (CommanderList data in Enum.GetValues(typeof(CommanderList)))
                {
                    Console.WriteLine((int)data + ". " + data);
                }
                string str = (sr == null? Console.ReadLine() : sr.ReadLine());
                int num;
                if (int.TryParse(str, out num) == true)
                {
                    if (Enum.IsDefined(typeof(CommanderList), num) == false)
                    {
                        Console.WriteLine("정확한 번호를 입력해주세요.");
                        continue;
                    }
                }
                else
                {
                    if (Enum.IsDefined(typeof(CommanderList), str) == false)
                    {
                        Console.WriteLine("정확한 이름을 입력해주세요.");
                        continue;
                    }
                }
                var enumCommander = Enum.Parse(typeof(CommanderList), str);
                Console.WriteLine("선택하신 사령관은 {0} 입니다.", num == 0? str : Enum.GetName(typeof(CommanderList), num));
                Console.WriteLine();

                if (isAttacker)
                {
                    commander.site = "공격측";
                    Commanders.atkeyValuePairs[(CommanderList)enumCommander].Init(commander, isFirst);
                    commander.commanderClassList.Add((Commanders.atkeyValuePairs[(CommanderList)enumCommander], isFirst));
                }
                else
                {
                    commander.site = "수비측";
                    Commanders.dfkeyValuePairs[(CommanderList)enumCommander].Init(commander, isFirst);
                    commander.commanderClassList.Add((Commanders.dfkeyValuePairs[(CommanderList)enumCommander], isFirst));
                }
                break;
            }
        }
        public static void SetTroopType(CommanderBase commander, bool isAttacker, StreamReader sr)
        {
            while (true)
            {
                foreach (TierList data in Enum.GetValues(typeof(TierList)))
                {
                    Console.WriteLine((int)data + ". " + data);
                }
                string str = (sr == null ? Console.ReadLine() : sr.ReadLine());
                int num;
                if (int.TryParse(str, out num) == true)
                {
                    if (Enum.IsDefined(typeof(TierList), num) == false)
                    {
                        Console.WriteLine("정확한 번호를 입력해주세요.");
                        continue;
                    }
                }
                else
                {
                    if (Enum.IsDefined(typeof(TierList), str) == false)
                    {
                        Console.WriteLine("정확한 이름을 입력해주세요.");
                        continue;
                    }
                }
                var enumTier = Enum.Parse(typeof(TierList), str);
                Console.WriteLine("선택하신 병종은 {0} 입니다.", num == 0 ? str : Enum.GetName(typeof(TierList), num));
                Console.WriteLine();
                if (isAttacker)
                    Tiers.atkeyValuePairs[(TierList)enumTier].Init(commander);
                else
                    Tiers.dfkeyValuePairs[(TierList)enumTier].Init(commander);
                break;
            }
        }
        public static void SetTroopAmount(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                int stat;
                string statString = (sr == null? Console.ReadLine() : sr.ReadLine());
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
        public static void SetAdditionalAttack(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                double stat;
                string statString = (sr == null? Console.ReadLine() : sr.ReadLine());
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
        public static void SetAdditionalDefence(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                double stat;
                string statString = (sr == null? Console.ReadLine() : sr.ReadLine());
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
        public static void SetAdditionalHealth(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                double stat;
                string statString = (sr == null? Console.ReadLine() : sr.ReadLine());
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

        public static void SetAdditionalDamageIncrease(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                double stat;
                string statString = (sr == null? Console.ReadLine() : sr.ReadLine());
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
        public static void SetAdditionalNormalDamageIncrease(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                double stat;
                string statString = (sr == null? Console.ReadLine() : sr.ReadLine());
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
        public static void SetAdditionalCounterDamageIncrease(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                double stat;
                string statString = (sr == null? Console.ReadLine() : sr.ReadLine());
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
        public static void SetAdditionalSkillDamageIncrease(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                double stat;
                string statString = (sr == null? Console.ReadLine() : sr.ReadLine());
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
        public static void SetAdditionalDamageDecrease(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                double stat;
                string statString = (sr == null? Console.ReadLine() : sr.ReadLine());
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
        public static void SetAdditionalNormalDamageDecrease(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                double stat;
                string statString = (sr == null? Console.ReadLine() : sr.ReadLine());
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
        public static void SetAdditionalCounterDamageDecrease(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                double stat;
                string statString = (sr == null? Console.ReadLine() : sr.ReadLine());
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
        public static void SetAdditionalSkillDamageDecrease(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                double stat;
                string statString = (sr == null? Console.ReadLine() : sr.ReadLine());
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
        public static void SetAdditionalHealingEffect(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                double stat;
                string statString = (sr == null ? Console.ReadLine() : sr.ReadLine());
                if (double.TryParse(statString, out stat) == false)
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요.");
                }
                else
                {
                    Console.WriteLine("입력하신 치료효과증가는 {0} 입니다.", stat);
                    Console.WriteLine();
                    commander.additionalHealingEffect += stat;
                    break;
                }
            }
        }


        public static void SetCharacter(CommanderBase commander, StreamReader sr)
        {
            while (true)
            {
                foreach (CharacterList data in Enum.GetValues(typeof(CharacterList)))
                {
                    Console.WriteLine((int)data + ". " + data);
                }
                string st = (sr == null? Console.ReadLine() : sr.ReadLine());
                if (string.IsNullOrEmpty(st))
                    return;

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
        public static void SetSubCharacter(CommanderBase commander, bool isAttacker, StreamReader sr)
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
                    string st = (sr == null? Console.ReadLine() : sr.ReadLine());
                    if (string.IsNullOrEmpty(st))
                        return;

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
                            Character.atkeyValuePairs[(Enum)enumCharacter].Init(commander, true, count);
                            commander.characterClassList.Add((Character.atkeyValuePairs[(Enum)enumCharacter], count));
                        }
                        else
                        {
                            Character.dfkeyValuePairs[(Enum)enumCharacter].Init(commander, true, count);
                            commander.characterClassList.Add((Character.dfkeyValuePairs[(Enum)enumCharacter], count));
                        }
                    }
                    Console.WriteLine("입력하셨습니다.");
                    Console.WriteLine();
                }
                break;
            }
        }
        public static void SetEquipment(CommanderBase commander, bool isAttacker, StreamReader sr)
        {
            while (true)
            {
                foreach (EquipmentList data in Enum.GetValues(typeof(EquipmentList)))
                {
                    Console.WriteLine((int)data + ". " + data);
                }
                string st = (sr == null? Console.ReadLine() : sr.ReadLine());
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

        public static void SetRunType(CommanderBase at, CommanderBase df, StreamReader sr)
        {
            while (true)
            {
                string numString = (sr == null ? Console.ReadLine() : sr.ReadLine());
                int num = 0;
                if (int.TryParse(numString, out num) == false || (num < 1 || num > 100000))
                {
                    Console.WriteLine("정확한 숫자를 입력해주세요. 최대 100000까지 입력 가능");
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

        public static void DirectSetting(string txtName)
        {
            StreamReader sr = string.IsNullOrEmpty(txtName)? null : new StreamReader(txtName);

            CommanderBase commander_at = new CommanderBase();
            CommanderBase commander_df = new CommanderBase();

            Console.WriteLine("▶ 공격측 정보 입력.");
            Console.WriteLine("- 전투 타입 번호 혹은 이름을 선택하세요.");
            SetIsField(commander_at, sr);
            Console.WriteLine("- 주사령관 번호 혹은 이름을 입력하세요");
            SetCommander(commander_at, true, true, sr);
            Console.WriteLine("- 부사령관 번호 혹은 이름을 입력하세요");
            SetCommander(commander_at, false, true, sr);
            Console.WriteLine("- 병종 번호 혹은 이름을 선택해 주세요");
            SetTroopType(commander_at, true, sr);
            Console.WriteLine("- 부대수를 입력해 주세요");
            SetTroopAmount(commander_at, sr);
            Console.WriteLine("- 추가 스탯 입력. [부대창설-상세]에 표시되는 부대버프를 입력해주세요.");
            Console.WriteLine("- 표시되는 [공격력](%)을 입력해주세요");
            SetAdditionalAttack(commander_at, sr);
            Console.WriteLine("- 표시되는 [방어력](%)을 입력해주세요");
            SetAdditionalDefence(commander_at, sr);
            Console.WriteLine("- 표시되는 [생명력](%)을 입력해주세요");
            SetAdditionalHealth(commander_at, sr);
            Console.WriteLine("- 표시되는 [모든피해증가](%)을 입력해주세요");
            SetAdditionalDamageIncrease(commander_at, sr);
            Console.WriteLine("- 표시되는 [일반피해증가](%)을 입력해주세요");
            SetAdditionalNormalDamageIncrease(commander_at, sr);
            Console.WriteLine("- 표시되는 [반격피해증가](%)을 입력해주세요");
            SetAdditionalCounterDamageIncrease(commander_at, sr);
            Console.WriteLine("- 표시되는 [스킬피해증가](%)을 입력해주세요");
            SetAdditionalSkillDamageIncrease(commander_at, sr);
            Console.WriteLine("- 표시되는 [모든피해감소](%)을 입력해주세요");
            SetAdditionalDamageDecrease(commander_at, sr);
            Console.WriteLine("- 표시되는 [일반피해감소](%)을 입력해주세요");
            SetAdditionalNormalDamageDecrease(commander_at, sr);
            Console.WriteLine("- 표시되는 [반격피해감소](%)을 입력해주세요");
            SetAdditionalCounterDamageDecrease(commander_at, sr);
            Console.WriteLine("- 표시되는 [스킬피해감소](%)을 입력해주세요");
            SetAdditionalSkillDamageDecrease(commander_at, sr);
            Console.WriteLine("- 표시되는 [치료효과증가](%)을 입력해주세요");
            SetAdditionalHealingEffect(commander_at, sr);
            Console.WriteLine("- 세 종류의 특성을 선택해주세요. ex) 1,6,11");
            SetCharacter(commander_at, sr);
            Console.WriteLine("- 각 특성 별 상세특성 정보를 입력해주세요. 단, 일부 특성은 버프에 이미 반영되어 있습니다.");
            SetSubCharacter(commander_at, true, sr);
            Console.WriteLine("- 착용한 악세서리를 두 개 선택해주세요. 단, 일부 악세서리는 버프에 이미 반영되어 있습니다. ex) 1,2");
            SetEquipment(commander_at, true, sr);

            Console.WriteLine("▶ 수비측 정보 입력.");
            Console.WriteLine("- 전투 타입 번호 혹은 이름을 선택하세요.");
            SetIsField(commander_df, sr);
            Console.WriteLine("- 주사령관 번호 혹은 이름을 입력하세요");
            SetCommander(commander_df, true, false, sr);
            Console.WriteLine("- 부사령관 번호 혹은 이름을 입력하세요");
            SetCommander(commander_df, false, false, sr);
            Console.WriteLine("- 병종 번호 혹은 이름을 선택해 주세요");
            SetTroopType(commander_df, false, sr);
            Console.WriteLine("- 부대수를 입력해 주세요");
            SetTroopAmount(commander_df, sr);
            Console.WriteLine("- 추가 스탯 입력. [부대창설-상세]에 표시되는 부대버프를 입력해주세요.");
            Console.WriteLine("- 표시되는 [공격력](%)을 입력해주세요");
            SetAdditionalAttack(commander_df, sr);
            Console.WriteLine("- 표시되는 [방어력](%)을 입력해주세요");
            SetAdditionalDefence(commander_df, sr);
            Console.WriteLine("- 표시되는 [생명력](%)을 입력해주세요");
            SetAdditionalHealth(commander_df, sr);
            Console.WriteLine("- 표시되는 [모든피해증가](%)을 입력해주세요");
            SetAdditionalDamageIncrease(commander_df, sr);
            Console.WriteLine("- 표시되는 [일반피해증가](%)을 입력해주세요");
            SetAdditionalNormalDamageIncrease(commander_df, sr);
            Console.WriteLine("- 표시되는 [반격피해증가](%)을 입력해주세요");
            SetAdditionalCounterDamageIncrease(commander_df, sr);
            Console.WriteLine("- 표시되는 [스킬피해증가](%)을 입력해주세요");
            SetAdditionalSkillDamageIncrease(commander_df, sr);
            Console.WriteLine("- 표시되는 [모든피해감소](%)을 입력해주세요");
            SetAdditionalDamageDecrease(commander_df, sr);
            Console.WriteLine("- 표시되는 [일반피해감소](%)을 입력해주세요");
            SetAdditionalNormalDamageDecrease(commander_df, sr);
            Console.WriteLine("- 표시되는 [반격피해감소](%)을 입력해주세요");
            SetAdditionalCounterDamageDecrease(commander_df, sr);
            Console.WriteLine("- 표시되는 [스킬피해감소](%)을 입력해주세요");
            SetAdditionalSkillDamageDecrease(commander_df, sr);
            Console.WriteLine("- 표시되는 [치료효과증가](%)을 입력해주세요");
            SetAdditionalHealingEffect(commander_df, sr);
            Console.WriteLine("- 세 종류의 특성을 선택해주세요. ex) 1,6,11");
            SetCharacter(commander_df, sr);
            Console.WriteLine("- 각 특성 별 상세특성 정보를 입력해주세요. 단, 일부 특성은 버프에 이미 반영되어 있습니다.");
            SetSubCharacter(commander_df, false, sr);
            Console.WriteLine("- 착용한 악세서리를 두 개 선택해주세요. 단, 일부 악세서리는 버프에 이미 반영되어 있습니다. ex) 1,2");
            SetEquipment(commander_df, false, sr);

            ViewBuff.ViewAdditionalBuff(commander_at, commander_df);

            Console.WriteLine("- 반복횟수를 입력해주세요(Max 100000). 1 입력 시 전투로그 확인 가능.");
            SetRunType(commander_at, commander_df, sr);

            Console.WriteLine("아무 키나 눌러 종료하세요.");
            string st = Console.ReadLine();

        }

        public static void IndirectSetting()
        {
            StreamReader sr = null;

            CommanderBase commander_at = new CommanderBase();
            CommanderBase commander_df = new CommanderBase();

            Console.WriteLine("▶ 공격측 정보 입력.");
            Console.WriteLine("- 전투 타입 번호 혹은 이름을 선택하세요.");
            SetIsField(commander_at, sr);
            Console.WriteLine("- 주사령관 번호 혹은 이름을 입력하세요");
            SetCommander(commander_at, true, true, sr);
            Console.WriteLine("- 부사령관 번호 혹은 이름을 입력하세요");
            SetCommander(commander_at, false, true, sr);
            Console.WriteLine("- 병종을 선택해 주세요");
            SetTroopType(commander_at, true, sr);
            Console.WriteLine("- 부대수를 입력해 주세요");
            SetTroopAmount(commander_at, sr);
            Console.WriteLine("- 누적할 샘플데이터 파일명을 입력하세요. 그만하려면 0 입력.");
            SetSampleData(commander_at, true, sr);
            Console.WriteLine("- 착용한 악세서리를 두 개 선택해주세요. 단, 일부 악세서리는 버프에 이미 반영되어 있습니다. ex) 1,2");
            SetEquipment(commander_at, true, sr);

            Console.WriteLine("▶ 수비측 정보 입력.");
            Console.WriteLine("- 전투 타입 번호 혹은 이름을 선택하세요.");
            SetIsField(commander_df, sr);
            Console.WriteLine("- 주사령관 번호 혹은 이름을 입력하세요");
            SetCommander(commander_df, true, false, sr);
            Console.WriteLine("- 부사령관 번호 혹은 이름을 입력하세요");
            SetCommander(commander_df, false, false, sr);
            Console.WriteLine("- 병종 번호 혹은 이름을 선택해 주세요");
            SetTroopType(commander_df, false, sr);
            Console.WriteLine("- 부대수를 입력해 주세요");
            SetTroopAmount(commander_df, sr);
            Console.WriteLine("- 누적할 샘플데이터 파일명을 입력하세요. 그만하려면 0 입력.");
            SetSampleData(commander_df, false, sr);
            Console.WriteLine("- 착용한 악세서리를 두 개 선택해주세요. 단, 일부 악세서리는 버프에 이미 반영되어 있습니다. ex) 1,2");
            SetEquipment(commander_df, false, sr);

            ViewBuff.ViewAdditionalBuff(commander_at, commander_df);

            Console.WriteLine("- 반복횟수를 입력해주세요(Max 100000). 1 입력 시 전투로그 확인 가능.");
            SetRunType(commander_at, commander_df, sr);

            Console.WriteLine("아무 키나 눌러 종료하세요.");
            string st = Console.ReadLine();
        }

        public static void SetSampleData(CommanderBase commander, bool isAttacker, StreamReader sr)
        {
            string fName = String.Empty;
            while ((fName = (sr == null ? Console.ReadLine() : sr.ReadLine())) != "0")
            {
                string path = Directory.GetFiles(@"C:\Users\jcm\Desktop\git\RiseOfKingdoms\RiseOfKingdoms\SampleData", fName, SearchOption.AllDirectories).FirstOrDefault();
                StreamReader sr2 = new StreamReader(path);
                SetAdditionalAttack(commander, sr2);
                SetAdditionalDefence(commander, sr2);
                SetAdditionalHealth(commander, sr2);
                SetAdditionalDamageIncrease(commander, sr2);
                SetAdditionalNormalDamageIncrease(commander, sr2);
                SetAdditionalCounterDamageIncrease(commander, sr2);
                SetAdditionalSkillDamageIncrease(commander, sr2);
                SetAdditionalDamageDecrease(commander, sr2);
                SetAdditionalNormalDamageDecrease(commander, sr2);
                SetAdditionalCounterDamageDecrease(commander, sr2);
                SetAdditionalSkillDamageDecrease(commander, sr2);
                SetAdditionalHealingEffect(commander, sr2);
                SetCharacter(commander, sr2);
                SetSubCharacter(commander, isAttacker, sr2);
            }
        }
    }
}
