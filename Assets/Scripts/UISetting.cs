using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISetting : MonoBehaviour
{
    public Slider musicSlider;
    public TextMeshProUGUI settingStatus;

    private void Awake()
    {
        LoadData();
    }

    public void MusicSetting()
    {
        if (musicSlider.value == 1)
        {
            ChangeSettingStatus("Music turned ON");
        }
        else
        {
            ChangeSettingStatus("Music turned OFF");
        }

        SaveData();
    }

    public void ChangeSettingStatus(string message)
    {
        settingStatus.text = message;
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("MusicStatus", musicSlider.value);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("MusicStatus"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicStatus", musicSlider.value);
        }
        else
        {
            //Set default value for the variable
            PlayerPrefs.SetFloat("MusicStatus", musicSlider.value);
        }
    }
}