using System.Collections;
using System.Collections.Generic;
using ETHotfix;
using UnityEngine;

public static class StringExtension 
{
    public static Vector2[] ToArrayV2I(this string formatString)
    {
        string[] ve2s = formatString.Split(';');
        List<Vector2> positionList = new List<Vector2>();
        for (int i = 0; i < ve2s.Length; i++)
        {
            if (!string.IsNullOrEmpty(ve2s[i]) && ve2s[i].Contains(","))
            {
                string[] pos = ve2s[i].Split(',');
                positionList.Add(new Vector2(int.Parse(pos[0]),int.Parse(pos[1])));
            }
        }
        return positionList.ToArray();
    }
    
    public static Vector3[] ToArrayV3I(this string formatString)
    {
        string[] ve2s = formatString.Split(';');
        List<Vector3> positionList = new List<Vector3>();
        for (int i = 0; i < ve2s.Length; i++)
        {
            if (!string.IsNullOrEmpty(ve2s[i]) && ve2s[i].Contains(","))
            {
                string[] pos = ve2s[i].Split(',');
                positionList.Add(new Vector3(int.Parse(pos[0]),int.Parse(pos[1]),int.Parse(pos[2])));
            }
        }
        return positionList.ToArray();
    }
    public static Vector2[] ToArrayV2F(this string formatString)
    {
        string[] ve2s = formatString.Split(';');
        List<Vector2> positionList = new List<Vector2>();
        for (int i = 0; i < ve2s.Length; i++)
        {
            if (!string.IsNullOrEmpty(ve2s[i]) && ve2s[i].Contains(","))
            {
                string[] pos = ve2s[i].Split(',');
                positionList.Add(new Vector2(float.Parse(pos[0]),float.Parse(pos[1])));
            }
        }
        return positionList.ToArray();
    }
    
    public static List<int> ToListI(this string formatString,char split = ',')
    {
        string[] ve2s = formatString.Split(split);
        List<int> positionList = new List<int>();
        for (int i = 0; i < ve2s.Length; i++)
        {
            if (!string.IsNullOrEmpty(ve2s[i]))
            {
                positionList.Add(int.Parse(ve2s[i]));
            }
        }
        return positionList;
    }
    
    public static Dictionary<int,int> ToDictI_I(this string formatString)
    {
        string[] ve2s = formatString.Split(';');
       Dictionary<int,int> positionList = new Dictionary<int,int>();
        for (int i = 0; i < ve2s.Length; i++)
        {
            if (!string.IsNullOrEmpty(ve2s[i]) && ve2s[i].Contains(","))
            {
                string[] pos = ve2s[i].Split(',');
                positionList.Add(int.Parse(pos[0]),int.Parse(pos[1]));
            }
        }

        return positionList;
    }
    
    
    public static Dictionary<int, Dictionary<int[],int>> ToDictI_II(this string formatString)
    {
        if (string.IsNullOrEmpty(formatString))
        {
            return new Dictionary<int, Dictionary<int[],int>>();
        }
        string[] ve2s = formatString.Split('#');
        Dictionary<int, Dictionary<int[],int>> positionList = new Dictionary<int, Dictionary<int[],int>>();
        for (int i = 0; i < ve2s.Length; i++)
        {
            if (!string.IsNullOrEmpty(ve2s[i]) && ve2s[i].Contains("|"))
            {
                string[] pos = ve2s[i].Split('|');
                Dictionary<int[],int> celldict = new Dictionary<int[], int>();
                string[] infos = pos[1].Split(';');
                for (int j = 0; j < infos.Length; j++)
                {
                    if (!string.IsNullOrEmpty(infos[j]) && infos[j].Contains(","))
                    {
                        string[] posinfo = infos[j].Split(',');
                        celldict.Add(new []{int.Parse(posinfo[0]),int.Parse(posinfo[1])},int.Parse(posinfo[2]));
                    }
                }
                positionList.Add(int.Parse(pos[0]),celldict);
            }
        }

        return positionList;
    }
    
    public static Dictionary<int, Dictionary<int[],int>> ToDictI_III(this string formatString)
    {
        string[] ve2s = formatString.Split('|');
        Dictionary<int, Dictionary<int[],int>> positionList = new Dictionary<int, Dictionary<int[],int>>();
        for (int i = 0; i < ve2s.Length; i++)
        {
            if (!string.IsNullOrEmpty(ve2s[i]) && ve2s[i].Contains("#"))
            {
                string[] pos = ve2s[i].Split('#');
                Dictionary<int[],int> celldict = new Dictionary<int[], int>();
                string[] infos = pos[1].Split(';');
                for (int j = 0; j < infos.Length; j++)
                {
                    if (!string.IsNullOrEmpty(infos[j]) && infos[j].Contains(","))
                    {
                        string[] posinfo = infos[j].Split(',');
                        celldict.Add(new []{int.Parse(posinfo[0]),int.Parse(posinfo[1])},int.Parse(posinfo[2]));
                    }
                }
                positionList.Add(int.Parse(pos[0]),celldict);
            }
        }

        return positionList;
    }
    
    public static Dictionary<int[],int> ToDictV2_I(this string formatString)
    {
        string[] ve2s = formatString.Split(';');
        Dictionary<int[],int> positionList = new Dictionary<int[],int>();
        for (int i = 0; i < ve2s.Length; i++)
        {
            if (!string.IsNullOrEmpty(ve2s[i]) && ve2s[i].Contains(","))
            {
                string[] pos = ve2s[i].Split(',');
                positionList.Add(new []{int.Parse(pos[0]),int.Parse(pos[1])}, int.Parse(pos[2]));
            }
        }

        return positionList;
    }
    public static Dictionary<int,Vector2[]> ToDictI_V2(this string formatString)
    {
        string[] specials = formatString.Split('|');
        Dictionary<int,Vector2[]> positionList = new Dictionary<int,Vector2[]>();
        for (int i = 0; i < specials.Length; i++)
        {
            if (!string.IsNullOrEmpty(specials[i]))
            {
                if (specials[i].Contains("#"))
                {
                    string[] specialSingle = specials[i].Split('#');
                    if (!string.IsNullOrEmpty(specialSingle[0]) && !string.IsNullOrEmpty(specialSingle[1]))
                    {
                        Vector2[] specialVe2s = specialSingle[1].ToArrayV2I();
                        if (specialVe2s.Length > 0)
                        {
                            positionList.Add(int.Parse(specialSingle[0]),specialVe2s);
                        }
                    }
                }
            }
        }
        return positionList;
    }

    public static Dictionary<int, Dictionary<int, int>> ToDictI_D(this string formatString)
    {
        Dictionary<int, Dictionary<int, int>> specialInfo = new Dictionary<int, Dictionary<int, int>>();
        if (!string.IsNullOrEmpty(formatString))
        {
            string[] specialValue = formatString.Split(';');
            for (int i = 0; i < specialValue.Length; i++)
            {
                if (!string.IsNullOrEmpty(specialValue[i]))
                {
                    if (specialValue[i].Contains("|"))
                    {
                        string[] specialele = specialValue[i].Split('|');
                        if (!string.IsNullOrEmpty(specialele[1]) && specialele[1].Contains(","))
                        {
                            string[] specialeleInfo = specialele[1].Split(',');
                            if (specialeleInfo.Length > 5)
                            {
                                Dictionary<int,int> eleDict = new Dictionary<int, int>();
                                eleDict.Add(HotFixConst.Shape_Max,int.Parse(specialeleInfo[0]));
                                eleDict.Add(HotFixConst.Shape_Min,int.Parse(specialeleInfo[1]));
                                eleDict.Add(HotFixConst.Shape_JMax,int.Parse(specialeleInfo[2]));
                                eleDict.Add(HotFixConst.Shape_JMin,int.Parse(specialeleInfo[3]));
                                eleDict.Add(HotFixConst.Shape_Zong,int.Parse(specialeleInfo[4]));
                                eleDict.Add(HotFixConst.Shape_Step,int.Parse(specialeleInfo[5]));
                                specialInfo[int.Parse(specialele[0])] = eleDict;
                            }
                        }

                    }
                }
            }
        }

        return specialInfo;
    }
    public static int[] ToArrayI(this string formatString)
    {
        string[] ve2s = formatString.Split(',');
        List<int> positionList = new List<int>();
        for (int i = 0; i < ve2s.Length; i++)
        {
            if (!string.IsNullOrEmpty(ve2s[i]))
            {

                positionList.Add(int.Parse(ve2s[i]));
            }
        }
        return positionList.ToArray();
    }
}
