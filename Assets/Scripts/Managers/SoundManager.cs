using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private FMOD.Studio.EventInstance _mainMusicInstance;

    private void Start()
    {
        _mainMusicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Main_theme");
        GameManager.Instance.OnLoadChanged += InstanceOnOnLoadChanged;
    }

    private void InstanceOnOnLoadChanged(int load)
    {
        _mainMusicInstance.setParameterByName("Load", load);
    }

    public void PlayMainMusic(int parameter)
    {
        _mainMusicInstance.setParameterByName("Load", parameter);
        _mainMusicInstance.start();
    }
}