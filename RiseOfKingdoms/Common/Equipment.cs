using RiseOfKingdoms.Equip;
using RiseOfKingdoms.Equip.Epic;
using RiseOfKingdoms.Equip.Legendary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Common
{
    internal class Equipment
    {
        public enum EquipmentList
        {
            심판의반지 = 1, 심판의반지특, 샤이트의외침, 샤이트의외침특, 클라크의전투북, 클라크의전투북특, 모라의거미줄, 모라의거미줄특, 
            스콜라스의행운코인, 스콜라스의행운코인특, 분노의뿔, 분노의뿔특, 날카로운비수, 날카로운비수특, 
            고요한심판, 고요한심판특, None
        }
        public static Dictionary<EquipmentList, EquipmentBase> atkeyValuePairs = new Dictionary<EquipmentList, EquipmentBase>
        {
            { EquipmentList.심판의반지, new Ring_of_Doom() },
            { EquipmentList.심판의반지특, new Ring_of_Doom() },
            { EquipmentList.샤이트의외침, new Seths_Call() },
            { EquipmentList.샤이트의외침특, new Seths_Call() },
            { EquipmentList.클라크의전투북, new Karuaks_War_Drums() },
            { EquipmentList.클라크의전투북특, new Karuaks_War_Drums() },
            { EquipmentList.모라의거미줄, new Moras_Web() },
            { EquipmentList.모라의거미줄특, new Moras_Web() },
            { EquipmentList.스콜라스의행운코인, new Scolas_Lucky_Coin() },
            { EquipmentList.스콜라스의행운코인특, new Scolas_Lucky_Coin() },
            { EquipmentList.분노의뿔, new Horn_of_Fury() },
            { EquipmentList.분노의뿔특, new Horn_of_Fury() },
            { EquipmentList.날카로운비수, new Concealed_Dagger() },
            { EquipmentList.날카로운비수특, new Concealed_Dagger() },
            { EquipmentList.고요한심판, new Silent_Trial() },
            { EquipmentList.고요한심판특, new Silent_Trial() },
            { EquipmentList.None, new EquipmentBase() }
        };
        public static Dictionary<EquipmentList, EquipmentBase> dfkeyValuePairs = new Dictionary<EquipmentList, EquipmentBase>
        {
            { EquipmentList.심판의반지, new Ring_of_Doom() },
            { EquipmentList.심판의반지특, new Ring_of_Doom() },
            { EquipmentList.샤이트의외침, new Seths_Call() },
            { EquipmentList.샤이트의외침특, new Seths_Call() },
            { EquipmentList.클라크의전투북, new Karuaks_War_Drums() },
            { EquipmentList.클라크의전투북특, new Karuaks_War_Drums() },
            { EquipmentList.모라의거미줄, new Moras_Web() },
            { EquipmentList.모라의거미줄특, new Moras_Web() },
            { EquipmentList.스콜라스의행운코인, new Scolas_Lucky_Coin() },
            { EquipmentList.스콜라스의행운코인특, new Scolas_Lucky_Coin() },
            { EquipmentList.분노의뿔, new Horn_of_Fury() },
            { EquipmentList.분노의뿔특, new Horn_of_Fury() },
            { EquipmentList.날카로운비수, new Concealed_Dagger() },
            { EquipmentList.날카로운비수특, new Concealed_Dagger() },
            { EquipmentList.고요한심판, new Silent_Trial() },
            { EquipmentList.고요한심판특, new Silent_Trial() },
            { EquipmentList.None, new EquipmentBase() }
        };
    }
}
