using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{

    [SerializeField] Slider volume_sound;
    [SerializeField] Slider volume_music;
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume_sound"))
        {
            PlayerPrefs.SetFloat("volime_sound", 1);
            Load();
        }
        if (!PlayerPrefs.HasKey("volume_music"))
        {
            PlayerPrefs.SetFloat("volume_music", 1);
            Load();
        }
    }

    // Update is called once per frame
    private void ChangeVolume()
    {

        AudioListener.volume = volume_music.value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume_Music", volume_music.value);
    }
    
    private void Load()
    {
        volume_music.value = PlayerPrefs.GetFloat("volume_music");
    }
}
