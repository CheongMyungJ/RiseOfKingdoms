// See https://aka.ms/new-console-template for more information

using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using static RiseOfKingdoms.Common.Commanders;
using static RiseOfKingdoms.Common.Tiers;

Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■     라오킹 계산기    ■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■  Made by OneV 버스커 ■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■  version : 1.220311  ■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

#if DEBUG
SelectInfo.DirectSetting("항넵vs아르테아마니.txt");
//SelectInfo.IndirectSetting();
#else
SelectInfo.DirectSetting(string.Empty);
#endif
