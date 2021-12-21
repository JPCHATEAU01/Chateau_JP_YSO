using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Account
{
    [SerializeField] private List<int> dif;
    [SerializeField] private List<string> level;

    public Account(List<int> dif , List<string> level)
    {
        if(dif == null)
        {
            this.dif = new List<int>() { 0, 0 };
        }
        else 
        {
            this.dif = dif;
        }
        if(level == null)
        {
            this.level = new List<string> { "level1", "level2" };
        }
        else
        {
            this.level = level;
        }
    }

    public List<int> GetDif()
    {
        return dif;
    }

    public List<string> GetLevel()
    {
        return level;
    }

}
