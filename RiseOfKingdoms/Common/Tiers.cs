using RiseOfKingdoms.Tier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Common
{
    internal class Tiers
    {
        public enum TierList { 보병 = 1, 기마병, 궁병, 삼병종,
            한국궁병, 로마보병, 스페인기마병, 아라비아기마병, 브리튼궁병, 오스만궁병, 일본보병, 독일기병, 프랑스보병, 중국궁병, 비잔티움기마병, 바이킹보병
        };

        public static Dictionary<TierList, TierBase> keyValuePairs = new Dictionary<TierList, TierBase> {
            { TierList.보병, new Base_Infantry() },
            { TierList.기마병, new Base_Cavalry() },
            { TierList.궁병, new Base_Archer() },
            { TierList.삼병종, new Base_Mixed() },
            { TierList.한국궁병, new Korea() },
            { TierList.로마보병, new Rome() },
            { TierList.스페인기마병, new Spain() },
            { TierList.아라비아기마병, new Arabia() },
            { TierList.브리튼궁병, new Britain() },
            { TierList.오스만궁병, new Ottoman() },
            { TierList.일본보병, new Japan() },
            { TierList.독일기병, new Germany() },
            { TierList.프랑스보병, new France() },
            { TierList.중국궁병, new China() },
            { TierList.비잔티움기마병, new Byzantium() },
            { TierList.바이킹보병, new Viking() }
        };
    }
}
