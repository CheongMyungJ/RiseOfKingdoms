// See https://aka.ms/new-console-template for more information

using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using static RiseOfKingdoms.Common.Commanders;
using static RiseOfKingdoms.Common.Tiers;

Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■     라오킹 계산기    ■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■  Made by OneV 버스커 ■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■  version : 1.220304  ■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

CommanderBase commander_at = new CommanderBase();
CommanderBase commander_df = new CommanderBase();

Console.WriteLine("▶ 공격측 정보 입력.");
Console.WriteLine("- 필드/집결 여부를 선택하세요.");
SelectInfo.SetIsField(commander_at);
Console.WriteLine("- 주사령관 번호를 입력하세요");
SelectInfo.SetCommander(commander_at, true);
Console.WriteLine("- 부사령관 번호를 입력하세요");
SelectInfo.SetCommander(commander_at, false);
Console.WriteLine("- 병종을 선택해 주세요");
SelectInfo.SetTroopType(commander_at);
Console.WriteLine("- 부대수를 입력해 주세요");
SelectInfo.SetTroopAmount(commander_at);
Console.WriteLine("- 추가 스탯 입력. [부대창설-상세]에 표시되는 부대버프를 입력해주세요.");
Console.WriteLine("- 표시되는 [공격력](%)을 입력해주세요");
SelectInfo.SetAdditionalAttack(commander_at);
Console.WriteLine("- 표시되는 [방어력](%)을 입력해주세요");
SelectInfo.SetAdditionalDefence(commander_at);
Console.WriteLine("- 표시되는 [생명력](%)을 입력해주세요");
SelectInfo.SetAdditionalHealth(commander_at);
Console.WriteLine("- 표시되는 [모든피해증가](%)을 입력해주세요");
SelectInfo.SetAdditionalDamageIncrease(commander_at);
Console.WriteLine("- 표시되는 [일반피해증가](%)을 입력해주세요");
SelectInfo.SetAdditionalNormalDamageIncrease(commander_at);
Console.WriteLine("- 표시되는 [반격피해증가](%)을 입력해주세요");
SelectInfo.SetAdditionalCounterDamageIncrease(commander_at);
Console.WriteLine("- 표시되는 [스킬피해증가](%)을 입력해주세요");
SelectInfo.SetAdditionalSkillDamageIncrease(commander_at);
Console.WriteLine("- 표시되는 [모든피해감소](%)을 입력해주세요");
SelectInfo.SetAdditionalDamageDecrease(commander_at);
Console.WriteLine("- 표시되는 [일반피해감소](%)을 입력해주세요");
SelectInfo.SetAdditionalNormalDamageDecrease(commander_at);
Console.WriteLine("- 표시되는 [반격피해감소](%)을 입력해주세요");
SelectInfo.SetAdditionalCounterDamageDecrease(commander_at);
Console.WriteLine("- 표시되는 [스킬피해감소](%)을 입력해주세요");
SelectInfo.SetAdditionalSkillDamageDecrease(commander_at);
Console.WriteLine("- 세 종류의 특성을 선택해주세요. ex) 1,6,11");
SelectInfo.SetCharacter(commander_at);
Console.WriteLine("- 각 특성 별 상세특성 정보를 입력해주세요. 단, 일부 특성은 버프에 이미 반영되어 있습니다.");
SelectInfo.SetSubCharacter(commander_at);
Console.WriteLine("- 착용한 악세서리를 두 개 선택해주세요. 단, 일부 악세서리는 버프에 이미 반영되어 있습니다. ex) 1,2");
SelectInfo.SetEquipment(commander_at);


Console.WriteLine("▶ 수비측 정보 입력.");
Console.WriteLine("- 필드/집결 여부를 선택하세요.");
SelectInfo.SetIsField(commander_df);
Console.WriteLine("- 주사령관 번호를 입력하세요");
SelectInfo.SetCommander(commander_df, true);
Console.WriteLine("- 부사령관 번호를 입력하세요");
SelectInfo.SetCommander(commander_df, false);
Console.WriteLine("- 병종을 선택해 주세요");
SelectInfo.SetTroopType(commander_df);
Console.WriteLine("- 부대수를 입력해 주세요");
SelectInfo.SetTroopAmount(commander_df);
Console.WriteLine("- 추가 스탯 입력. [부대창설-상세]에 표시되는 부대버프를 입력해주세요.");
Console.WriteLine("- 표시되는 [공격력](%)을 입력해주세요");
SelectInfo.SetAdditionalAttack(commander_df);
Console.WriteLine("- 표시되는 [방어력](%)을 입력해주세요");
SelectInfo.SetAdditionalDefence(commander_df);
Console.WriteLine("- 표시되는 [생명력](%)을 입력해주세요");
SelectInfo.SetAdditionalHealth(commander_df);
Console.WriteLine("- 표시되는 [모든피해증가](%)을 입력해주세요");
SelectInfo.SetAdditionalDamageIncrease(commander_df);
Console.WriteLine("- 표시되는 [일반피해증가](%)을 입력해주세요");
SelectInfo.SetAdditionalNormalDamageIncrease(commander_df);
Console.WriteLine("- 표시되는 [반격피해증가](%)을 입력해주세요");
SelectInfo.SetAdditionalCounterDamageIncrease(commander_df);
Console.WriteLine("- 표시되는 [스킬피해증가](%)을 입력해주세요");
SelectInfo.SetAdditionalSkillDamageIncrease(commander_df);
Console.WriteLine("- 표시되는 [모든피해감소](%)을 입력해주세요");
SelectInfo.SetAdditionalDamageDecrease(commander_df);
Console.WriteLine("- 표시되는 [일반피해감소](%)을 입력해주세요");
SelectInfo.SetAdditionalNormalDamageDecrease(commander_df);
Console.WriteLine("- 표시되는 [반격피해감소](%)을 입력해주세요");
SelectInfo.SetAdditionalCounterDamageDecrease(commander_df);
Console.WriteLine("- 표시되는 [스킬피해감소](%)을 입력해주세요");
SelectInfo.SetAdditionalSkillDamageDecrease(commander_df);
Console.WriteLine("- 세 종류의 특성을 선택해주세요. ex) 1,6,11");
SelectInfo.SetCharacter(commander_df);
Console.WriteLine("- 각 특성 별 상세특성 정보를 입력해주세요. 단, 일부 특성은 버프에 이미 반영되어 있습니다.");
SelectInfo.SetSubCharacter(commander_df);
Console.WriteLine("- 착용한 악세서리를 두 개 선택해주세요. 단, 일부 악세서리는 버프에 이미 반영되어 있습니다. ex) 1,2");
SelectInfo.SetEquipment(commander_df);

ViewBuff.ViewAdditionalBuff(commander_at, commander_df);

Console.WriteLine("- 반복횟수를 입력해주세요(Max 1000). 1 입력 시 전투로그 확인 가능.");
SelectInfo.SetRunType(commander_at, commander_df);

Console.WriteLine("아무 키나 눌러 종료하세요.");
string st = Console.ReadLine();