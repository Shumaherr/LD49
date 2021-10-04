using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private FMOD.Studio.Bus Master;
    private float masterVolume = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        Master = FMODUnity.RuntimeManager.GetBus("bus:/");
    }

    // Update is called once per frame
    void Update()
    {
        Master.setVolume(masterVolume);
    }

    public void MasterVolumeLevel(float newMasterLevel)
    {
        masterVolume = newMasterLevel;
    }
}
