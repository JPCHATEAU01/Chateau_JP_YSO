using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager>
{
    private Volume volume;
    private SaveLoadDataIntoJson<Volume> volumeData;
    private AudioClip intro;
    private AudioClip credit;
    private AudioSource currentPlaying;
    private string musicPlaying;
    private bool isPlay = true;

    protected override void Awake()
    {
        base.Awake();
        LoadVolume();
        LoadAudioSources();
    }

    public void PlayIntro()
    {
        Debug.Log(musicPlaying);
        Debug.Log(intro.name);

        if(musicPlaying != intro.name)
        {
            musicPlaying = intro.name;
            if (currentPlaying.isPlaying)
            {

                currentPlaying.Stop();
            }
            if (isPlay)
            {
                currentPlaying.clip = intro;
                currentPlaying.Play();
                //credit.Stop();
                //intro.Play();
            }
        }

    }

    public void PlayCredits()
    {
        if (musicPlaying != credit.name)
        {
            musicPlaying = credit.name;
            if (currentPlaying.isPlaying == true)
            {
                currentPlaying.Stop();
            }
            if (isPlay)
            {
                currentPlaying.clip = credit;
                currentPlaying.Play();
                //intro.Stop();
                //credit.Play();
            }
        }
    }

    private void SetVolume(AudioSource aS)
    {
        //Debug.Log(volume.GetVolume());
        aS.volume = volume.GetVolume();
    }

    public void ChangeVolume(float newVolume)
    {
        volume.SetVolume(newVolume);
        //SetVolume(intro);
        //SetVolume(credit);
        SetVolume(currentPlaying);
    }

    private void AddMusic(AudioSource aS)
    {
        SetVolume(aS);
    }

    private void LoadVolume()
    {
        volumeData = new SaveLoadDataIntoJson<Volume>("/Volume.json");
        try
        {
            volume = volumeData.LoadObject();
        }
        catch (Exception)
        {
            //Debug.Log(e);
            volume = new Volume();
            volumeData.SaveIntoJson(volume);
        }
    }

    private void LoadAudioSources()
    {
        intro = (AudioClip)Resources.Load("Musics/MusicIntro");
        credit = (AudioClip)Resources.Load("Musics/MusicCredit");
        currentPlaying = gameObject.AddComponent<AudioSource>();
        currentPlaying.clip = intro;
        currentPlaying.loop = true;
        currentPlaying.playOnAwake = false;
        SetVolume(currentPlaying);
        musicPlaying = "";
        //Debug.Log(currentPlaying.isPlaying);
    }

    public void PlayMusic(bool play)
    {
        isPlay = play;
        if (!isPlay)
        {
            currentPlaying.Stop();
        }
        else
        {
            currentPlaying.Play();
        }
    }

}