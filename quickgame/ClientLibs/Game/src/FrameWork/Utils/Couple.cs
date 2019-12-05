using System.Collections.Generic;
using System.Text.RegularExpressions;
using XLua;

//[LuaExport(LuaExportOption.SELECTED)]
[LuaCallCSharp]
public class Couple
{
    //[LuaExport]
    public uint ParameterA;
    //[LuaExport]
    public uint ParameterB;

    //[LuaExport]
    public string RawA;
    //[LuaExport]
    public string RawB;

    public static Couple Make(string rawA, string rawB)
    {
        Couple result = new Couple();

        if (string.IsNullOrEmpty(rawA) == false)
        {
            uint.TryParse(rawA, out result.ParameterA);
        }

        if (string.IsNullOrEmpty(rawB) == false)
        {
            uint.TryParse(rawB, out result.ParameterB);
        }

        return result;
    }

    public static Couple Make(string raw)
    {
        Couple result = new Couple();

        if (string.IsNullOrEmpty(raw))
        {
            return result;
        }

        // 移除头尾的[]
        raw = raw.Remove(0, 1);
        raw = raw.Remove(raw.Length - 1, 1);

        string[] rawResults = raw.Split(',');

        if (rawResults.Length >= 1)
        {
            result.RawA = rawResults[0];
            uint.TryParse(rawResults[0], out result.ParameterA);
        }

        if (rawResults.Length >= 2)
        {
            result.RawB = rawResults[1];
            uint.TryParse(rawResults[1], out result.ParameterB);
        }

        return result;
    }

    
    public static void ParseCoupleMapFromDB(string raw, ref Dictionary<uint, Couple> result)
    {
        if(result == null)
        {
            result = new Dictionary<uint, Couple>();
        }

        Match match = Regex.Match(raw, @"\{(\d+)[\,\s]*(\d+)\}");
        uint index = 0;
        while (match.Success)
        {
            var needNumber = match.Groups[2].Captures;
            var needId = match.Groups[1].Captures;

            Couple couple = Couple.Make(needId[0].Value, needNumber[0].Value);
            result.Add(index, couple);

            match = match.NextMatch();
            ++index;
        }
    }

    public static void ParseCoupleMapFromDB(string raw, ref List<Couple> result)
    {
        if (result == null)
        {
            result = new List<Couple>();
        }

        Match match = Regex.Match(raw, @"\{(\d+)[\,\s]*(\d+)\}");

        while (match.Success)
        {
            var needNumber = match.Groups[2].Captures;
            var needId = match.Groups[1].Captures;

            Couple couple = Couple.Make(needId[0].Value, needNumber[0].Value);
            result.Add(couple);

            match = match.NextMatch();
        }
    }
}

