using UnityEngine;

[System.Serializable]
public class Volume
{
    [SerializeField] private float volume;

    public Volume(float newVolume)
    {
        newVolume = CheckVolume(newVolume);
        this.volume = newVolume;
    }

    public Volume()
    {
        this.volume = 0.5f;
    }

    public float GetVolume()
    {
        return volume;
    }

    public void SetVolume(float newVolume)
    {
        newVolume = CheckVolume(newVolume);
        this.volume = newVolume;
    }

    public override string ToString()
    {
        string toString = "[ " + this.GetType() + " ]" + " volume = " + volume;
        return toString;
    }

    private float CheckVolume(float volume)
    {
        if(volume < 0)
        {
            volume = 0;
        }
        else if (volume > 1)
        {
            volume = 1;
        }
        return volume;
    }

}