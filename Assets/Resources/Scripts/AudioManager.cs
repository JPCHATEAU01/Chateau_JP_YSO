using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager>
{
    private Volume volume;
    private SaveLoadDataIntoJson<Volume> volumeData;
    private AudioClip intro;
    private AudioClip credit;
    private AudioClip game;
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
        if (musicPlaying != intro.name)
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

    public void PlayGames()
    {
        if (musicPlaying != game.name)
        {
            musicPlaying = game.name;
            if (currentPlaying.isPlaying == true)
            {
                currentPlaying.Stop();
            }
            if (isPlay)
            {
                currentPlaying.clip = game;
                currentPlaying.Play();
                //intro.Stop();
                //credit.Play();
            }
        }
    }

    private void SetVolume(AudioSource aS)
    {
        aS.volume = volume.GetVolume();
    }

    public float GetVolume()
    {
        return volume.GetVolume();
    }

    public void ChangeVolume(float newVolume)
    {
        volume.SetVolume(newVolume);
        SetVolume(currentPlaying);
        volumeData.SaveIntoJson(new Volume(newVolume));
    }

    private void AddMusic(AudioSource aS)
    {
        SetVolume(aS);
    }

    private void LoadVolume()
    {
        volumeData = new SaveLoadDataIntoJson<Volume>("Volume.json");
        try
        {
            volume = volumeData.LoadObject();
        }
        catch (Exception)
        {
            volume = new Volume();
            volumeData.SaveIntoJson(volume);
        }
    }

    private void LoadAudioSources()
    {
        intro = (AudioClip)Resources.Load("Musics/MusicIntro");
        credit = (AudioClip)Resources.Load("Musics/MusicCredit");
        game = (AudioClip)Resources.Load("Musics/MusicGame");
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