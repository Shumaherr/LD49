using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private FMOD.Studio.EventInstance _mainMusicInstance;
    private FMOD.Studio.EventInstance _mainAmbienceInstance;
    private Dictionary<Transform, FMOD.Studio.EventInstance> _rodInstances;

    private void Awake()
    {
        _mainMusicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Main_theme");
        _mainAmbienceInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Ambience/Ambience");
    }

    private void Start()
    {
       
        GameManager.Instance.OnLoadChanged += InstanceOnOnLoadChanged;
        _rodInstances = new Dictionary<Transform, EventInstance>();
    }

    public void InstanceOnOnLoadChanged(int load)
    {
        _mainMusicInstance.setParameterByName("Load", load);
    }

    public void PlayMainMusic(int parameter)
    {
        _mainMusicInstance.setParameterByName("Load", parameter);
        _mainMusicInstance.start();
        _mainAmbienceInstance.start();
    }
    
    public void PlayMusicWin()
    {
        _mainMusicInstance.stop(STOP_MODE.ALLOWFADEOUT);
        _mainAmbienceInstance.stop(STOP_MODE.IMMEDIATE);
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/End_game/Gameover_win");
    }
    
    public void PlayMusicBoom()
    {
        _mainMusicInstance.stop(STOP_MODE.ALLOWFADEOUT);
        _mainAmbienceInstance.stop(STOP_MODE.IMMEDIATE);
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/End_game/Gameover_boom");
    }
    
    public void PlayMusicLowEnergy()
    {
        _mainMusicInstance.stop(STOP_MODE.ALLOWFADEOUT);
        _mainAmbienceInstance.stop(STOP_MODE.IMMEDIATE);
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/End_game/Gameover_low_energy");
    }

    public void PlayLeverSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Lever");
    }

    public void StartRodSFX(Transform transform)
    {
        if(!FmodExtensions.IsPlaying(_rodInstances[transform]))
            _rodInstances[transform].start();

    }
    
    public void StopRodSFX(Transform transform)
    {
        if(FmodExtensions.IsPlaying(_rodInstances[transform])) 
            _rodInstances[transform].stop(STOP_MODE.ALLOWFADEOUT);

    }

    public void CreateInstancesForRods(List<Transform> rods)
    {
        FMOD.Studio.EventInstance instance = new EventInstance();
        foreach (var rod in rods)
        {
            //instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(rod.gameObject));
            _rodInstances.Add(rod,_mainMusicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Rod_move"));
        }
    }

    public void PlayAbsorbSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Proton_absorb");
    }
    
    public void PlayCollisionSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Atom_collision");
    }
    
    public void PlayFissionSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Atom_fission");
    }
    
}

public class FmodExtensions
{
    public static bool IsPlaying(FMOD.Studio.EventInstance instance)
    {
        FMOD.Studio.PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        return state != FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }
}