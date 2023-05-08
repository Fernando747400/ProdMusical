using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class FAudioMixer : MonoBehaviour
{
    [Range (0f, 1f)]
    [SerializeField] private float _masterVolume = 1f;
    [Range (0f, 1f)]
    [SerializeField] private float _musicVolume = 1f;
    [Range (0f, 1f)]
    [SerializeField] private float _sfxVolume = 1f;
    [Range (0f, 1f)]
    [SerializeField] private float _ambienceVolume = 1f;
    [Range (0f, 1f)]
    [SerializeField] private float _engineVolume = 1f;

    private Bus _mainBus;
    private Bus _musicBus;
    private Bus _sfxBus;
    private Bus _ambienceBus;
    private Bus _engineBus;

    private void Awake()
    {
        _mainBus = FMODUnity.RuntimeManager.GetBus("bus:/Main");
        _musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Main/MusicBus");
        _sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/Main/SFXBus");
        //_ambienceBus = FMODUnity.RuntimeManager.GetBus("bus:/Master/AmbienceBus");
        _engineBus = FMODUnity.RuntimeManager.GetBus("bus:/Main/EngineBus");
    }

    private void Start()
    {
        UpdateVolumes();
    }

    private void OnValidate()
    {
        UpdateVolumes();
    }

    private void UpdateVolumes()
    {
        _mainBus.setVolume(_masterVolume);
        _musicBus.setVolume(_musicVolume);
        _sfxBus.setVolume(_sfxVolume);
        //_ambienceBus.setVolume(_ambienceVolume);
        _engineBus.setVolume(_engineVolume);
    }
}
