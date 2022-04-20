using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Common
{
    internal class Commanders
    {
        public enum CommanderList { 
            명사수 = 1, 아마니토레, 아르테미시아, 길가메시,
            혼다타다카츠, 이순신, 측천무후, 테오도라,
            제노비아, 아에티우스, 스키피오,
            용기병, 항우, 알렉산드르넵스키, 윌리엄1세, 미나모토요시쓰네, 찬드라굽타, 베르트랑뒤게틀랭, 야드비가,
            None,
        };
        public static Dictionary<CommanderList, SkillBase> atkeyValuePairs = new Dictionary<CommanderList, SkillBase> { 
            { CommanderList.명사수, new Markswoman() },
            { CommanderList.용기병, new Dragon_Lancer() },
            { CommanderList.항우, new Xiang_Yu() },
            { CommanderList.알렉산드르넵스키, new Alexander_Nevsky()},
            { CommanderList.윌리엄1세, new William()},
            { CommanderList.혼다타다카츠, new Honda_Tadakatsu()},
            { CommanderList.미나모토요시쓰네, new Minamoto_no_Yoshitsune()},
            { CommanderList.찬드라굽타, new Chandragupta_Maurya()},
            { CommanderList.베르트랑뒤게틀랭, new Bertrand_du_Guesclin()},
            { CommanderList.이순신, new Yi_Sun_Sin()},
            { CommanderList.야드비가, new Jadwiga()},
            { CommanderList.제노비아, new Zenobia()},
            { CommanderList.아에티우스, new Aetius()},
            { CommanderList.스키피오, new Scipio()},
            { CommanderList.측천무후, new Wu_Zetian()},
            { CommanderList.아마니토레, new Amanitore()},
            { CommanderList.아르테미시아, new Artemisia()},
            { CommanderList.테오도라, new Theodora()},
            { CommanderList.길가메시, new Gilgamesh()},
            { CommanderList.None, new SkillBase() }
        };
        public static Dictionary<CommanderList, SkillBase> dfkeyValuePairs = new Dictionary<CommanderList, SkillBase> {
            { CommanderList.명사수, new Markswoman() },
            { CommanderList.용기병, new Dragon_Lancer() },
            { CommanderList.항우, new Xiang_Yu() },
            { CommanderList.알렉산드르넵스키, new Alexander_Nevsky()},
            { CommanderList.윌리엄1세, new William()},
            { CommanderList.혼다타다카츠, new Honda_Tadakatsu()},
            { CommanderList.미나모토요시쓰네, new Minamoto_no_Yoshitsune()},
            { CommanderList.찬드라굽타, new Chandragupta_Maurya()},
            { CommanderList.베르트랑뒤게틀랭, new Bertrand_du_Guesclin()},
            { CommanderList.이순신, new Yi_Sun_Sin()},
            { CommanderList.야드비가, new Jadwiga()},
            { CommanderList.제노비아, new Zenobia()},
            { CommanderList.아에티우스, new Aetius()},
            { CommanderList.스키피오, new Scipio()},
            { CommanderList.측천무후, new Wu_Zetian()},
            { CommanderList.아마니토레, new Amanitore()},
            { CommanderList.아르테미시아, new Artemisia()},
            { CommanderList.테오도라, new Theodora()},
            { CommanderList.길가메시, new Gilgamesh()},
            { CommanderList.None, new SkillBase() }
        };


    }
}

