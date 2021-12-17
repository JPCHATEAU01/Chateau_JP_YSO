using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Volume
{
    [SerializeField] private float volume;

    public Volume(float volume)
    {
        this.volume = volume;
    }

    public float GetVolume()
    {
        return volume;
    }

    public void SetVolume(float volume)
    {
        this.volume = volume;
    }

    public override string ToString()
    {
        string toString = "[ " + this.GetType() + " ]" + " volume = " + volume;
        return toString;
    }

}