using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DeltaTime
{
    #region Dictionarys
    public Dictionary<string, float> Next { get; set; }
    public Dictionary<string, float> Rates { get; set; }
    #endregion

    public DeltaTime()
    {
        this.Next = new Dictionary<string, float>();
        this.Rates = new Dictionary<string, float>();
    }

    public void Create(string key, float rate)
    {
        this.Next.Add(key, 0);
        this.Rates.Add(key, rate);
    }
    public void UpdateNext(string key)
    {
        this.Next[key] = Time.time + this.Rates[key];
    }
    
    public bool TimeIsOver(string key)
    {
        if (Time.time > this.Next[key])
            return true;

        else { return false; }
    }
}
