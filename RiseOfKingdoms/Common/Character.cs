using RiseOfKingdoms.Characteristic;
using RiseOfKingdoms.Tier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Common
{
    internal class Character
    {
        public enum CharacterList
        { 
            보병 = 1, 기마병, 궁병, 리더십, 종합, 
            스킬, 지원, 공격, 기동, 방어, 
            공성, 유동성, 야만, 주둔, 채집
        };
        #region top
        public enum InfantryCharacter
        {
            무리의부름 = 1, 영원한분노, 강철의창, 현상유지, 가시의덫, 정예부대, None
        }
        public enum CavalryCharacter
        {
            미늘창 = 1, 영원한분노, 무장해제, 사기진작, None
        }
        public enum ArcherCharacter
        {
            발사직전 = 1, 아대, 예리한화살촉, 봉황선, 명적, None
        }
        public enum LeadershipCharacter
        {
            와신상담 = 1, 전원착검, 전원방패, 밀집진형, 절묘한전략, 왕의이름, None
        }
        public enum IntegrationCharacter
        {
            무리의부름, 전속돌격, 가득한화살통, 전원방패, 전원착검, None
        }
        #endregion
        #region right
        public enum SkillCharacter
        {
            분노의일격 = 1, 잠재력, 일심동체, 명료, 인내, 치명적인자연, None
        }
        public enum SupportCharacter
        {
            분노의일격 = 1, 반격, 긴급방어, 인내, 가시우리, None
        }
        public enum AttackCharacter
        {
             열혈 = 1, 전쟁의왕, 여유, 배수진, None
        }
        public enum DefenceCharacter
        {
            열혈, 병기공장인, 약초준비, 귀갑진형, 필사의애가, None
        }
        public enum MobilityCharacter
        {
            소용돌이 = 1, 가벼운걸음, 깨달음, 시간관리, None
        }
        #endregion
        #region left
        public enum ConqueringCharacter
        {
            승기 = 1, 유성우, 축복의눈물, None
        }
        public enum GarrisonCharacter
        {
            난공불락 = 1, 공성계, 철옹성, 사면초가, 왕궁호위대, 신의은혜, None
        }
        public enum VersatilityCharacter
        {
            사면초가 = 1, 원형방패, 왕궁호위대, 축복의눈물, 운명의전환, None
        }
        public enum PeacekeepingCharacter
        {
            None = 1
        }
        public enum GatheringCharacter
        {
            None = 1
        }
        #endregion
        public static Dictionary<CharacterList, Enum> CharacterSubCharacterPairs = new Dictionary<CharacterList, Enum> {
            { CharacterList.보병, new InfantryCharacter() },
            { CharacterList.기마병, new CavalryCharacter() },
            { CharacterList.궁병, new ArcherCharacter() },
            { CharacterList.리더십, new LeadershipCharacter() },
            { CharacterList.종합, new IntegrationCharacter() },

            { CharacterList.스킬, new SkillCharacter() },
            { CharacterList.지원, new SupportCharacter() },
            { CharacterList.공격, new AttackCharacter() },
            { CharacterList.기동, new MobilityCharacter() },
            { CharacterList.방어, new DefenceCharacter() },

            { CharacterList.공성, new ConqueringCharacter() },
            { CharacterList.유동성, new VersatilityCharacter() },
            { CharacterList.야만, new PeacekeepingCharacter() },
            { CharacterList.주둔, new GarrisonCharacter() },
            { CharacterList.채집, new GatheringCharacter() }
        };

        public static Dictionary<Enum, CharacterBase> keyValuePairs = new Dictionary<Enum, CharacterBase> {
            #region top
            { InfantryCharacter.무리의부름, new Characteristic.Infantry.Call_of_the_Pack() },
            { InfantryCharacter.영원한분노, new Characteristic.Infantry.Undying_Fury() },
            { InfantryCharacter.강철의창, new Characteristic.Infantry.Iron_Spear() },
            { InfantryCharacter.현상유지, new Characteristic.Infantry.Hold_The_Line() },
            { InfantryCharacter.가시의덫, new Characteristic.Infantry.Snare_of_Thorns() },
            { InfantryCharacter.정예부대, new Characteristic.Infantry.Elite_Soldiers() },
            { InfantryCharacter.None, new CharacterBase() },

            { CavalryCharacter.무장해제, new Characteristic.Cavalry.Halberd() },
            { CavalryCharacter.영원한분노, new Characteristic.Cavalry.Undying_Fury() },
            { CavalryCharacter.미늘창, new Characteristic.Cavalry.Disarm() },
            { CavalryCharacter.사기진작, new Characteristic.Cavalry.Rallying_Cry() },
            { CavalryCharacter.None, new CharacterBase() },

            { ArcherCharacter.발사직전, new Characteristic.Archer.Arrows_Nocked() },
            { ArcherCharacter.아대, new Characteristic.Archer.Thumb_Ring() },
            { ArcherCharacter.예리한화살촉, new Characteristic.Archer.Razor_Sharp() },
            { ArcherCharacter.봉황선, new Characteristic.Archer.Phoenix_Tail_Arrows() },
            { ArcherCharacter.명적, new Characteristic.Archer.Whistling_Arrows() },
            { ArcherCharacter.None, new CharacterBase() },

            { LeadershipCharacter.와신상담, new Characteristic.Leadership.Hidden_Wrath() },
            { LeadershipCharacter.전원착검, new Characteristic.Leadership.Armored_To_The_Teeth() },
            { LeadershipCharacter.전원방패, new Characteristic.Leadership.Armed_To_The_Teeth() },
            { LeadershipCharacter.밀집진형, new Characteristic.Leadership.Close_Formation() },
            { LeadershipCharacter.절묘한전략, new Characteristic.Leadership.Strategic_Prowess() },
            { LeadershipCharacter.왕의이름, new Characteristic.Leadership.Name_Of_The_King() },
            { LeadershipCharacter.None, new CharacterBase() },

            { IntegrationCharacter.무리의부름, new Characteristic.Integration.Call_of_the_Pack() },
            { IntegrationCharacter.전속돌격, new Characteristic.Integration.Charge() },
            { IntegrationCharacter.가득한화살통, new Characteristic.Integration.Full_Quiver() },
            { IntegrationCharacter.전원방패, new Characteristic.Integration.Armored_To_The_Teeth() },
            { IntegrationCharacter.전원착검, new Characteristic.Integration.Armed_To_The_Teeth() },
            { IntegrationCharacter.None, new CharacterBase() },
            #endregion
            #region right
            { SkillCharacter.분노의일격, new Characteristic.Skill.Burning_Blood() },
            { SkillCharacter.잠재력, new Characteristic.Skill.Latent_Power() },
            { SkillCharacter.일심동체, new Characteristic.Skill.All_For_One() },
            { SkillCharacter.명료, new Characteristic.Skill.Clarity() },
            { SkillCharacter.인내, new Characteristic.Skill.Rejuvenate() },
            { SkillCharacter.치명적인자연, new Characteristic.Skill.Feral_Nature() },
            { SkillCharacter.None, new CharacterBase() },

            { SupportCharacter.분노의일격, new Characteristic.Support.Burning_Blood() },
            { SupportCharacter.반격, new Characteristic.Support.Counterattack() },
            { SupportCharacter.긴급방어, new Characteristic.Support.Emergency_Protection() },
            { SupportCharacter.인내, new Characteristic.Support.Rejuvenate() },
            { SupportCharacter.가시우리, new Characteristic.Support.Cage_of_Thorns() },
            { SupportCharacter.None, new CharacterBase() },

            { AttackCharacter.열혈, new Characteristic.Attack.Burning_Blood() },
            { AttackCharacter.전쟁의왕, new Characteristic.Attack.Lord_of_War() },
            { AttackCharacter.여유, new Characteristic.Attack.Effortless() },
            { AttackCharacter.배수진, new Characteristic.Attack.Last_Stand() },
            { AttackCharacter.None, new CharacterBase() },

            { DefenceCharacter.열혈, new Characteristic.Defence.Burning_Blood() },
            { DefenceCharacter.병기공장인, new Characteristic.Defence.Master_Armorer() },
            { DefenceCharacter.약초준비, new Characteristic.Defence.Medicinal_Supplies() },
            { DefenceCharacter.귀갑진형, new Characteristic.Defence.Testudo_Formation() },
            { DefenceCharacter.필사의애가, new Characteristic.Defence.Desperate_Elegy() },
            { DefenceCharacter.None, new CharacterBase() },

            { MobilityCharacter.소용돌이, new Characteristic.Mobility.Vortex() },
            { MobilityCharacter.가벼운걸음, new Characteristic.Mobility.Swiftness() },
            { MobilityCharacter.깨달음, new Characteristic.Mobility.Alacrity() },
            { MobilityCharacter.시간관리, new Characteristic.Mobility.Time_Management() },
            { MobilityCharacter.None, new CharacterBase() },
            #endregion
            #region left
            { ConqueringCharacter.승기, new Characteristic.Conquering.Moment_Of_Triumph() },
            { ConqueringCharacter.유성우, new Characteristic.Conquering.Entrenched() },
            { ConqueringCharacter.축복의눈물, new Characteristic.Conquering.Meteor_Shower() },
            { ConqueringCharacter.None, new CharacterBase() },

            { GarrisonCharacter.난공불락, new Characteristic.Garrison.Impregnable() },
            { GarrisonCharacter.공성계, new Characteristic.Garrison.Empty_Fortress_Strategem() },
            { GarrisonCharacter.철옹성, new Characteristic.Garrison.Impenetrable_Fortifications() },
            { GarrisonCharacter.사면초가, new Characteristic.Garrison.Nowhere_To_Turn() },
            { GarrisonCharacter.왕궁호위대, new Characteristic.Garrison.Kings_Guard() },
            { GarrisonCharacter.신의은혜, new Characteristic.Garrison.Divine_Favor() },
            { GarrisonCharacter.None, new CharacterBase() },

            { VersatilityCharacter.사면초가, new Characteristic.Versatility.Nowhere_To_Turn() },
            { VersatilityCharacter.원형방패, new Characteristic.Versatility.Buckler_Shield() },
            { VersatilityCharacter.왕궁호위대, new Characteristic.Versatility.Kings_Guard() },
            { VersatilityCharacter.축복의눈물, new Characteristic.Versatility.Meteor_Shower() },
            { VersatilityCharacter.운명의전환, new Characteristic.Versatility.Turn_Of_Fate() },
            { VersatilityCharacter.None, new CharacterBase() },

            { PeacekeepingCharacter.None, new CharacterBase() },

            { GatheringCharacter.None, new CharacterBase() }
            #endregion
        };
    }
}
