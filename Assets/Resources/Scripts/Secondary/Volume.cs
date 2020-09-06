using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Sprite[] volumeIconOffOn;
    public AudioMixer audiomixer;
    private Image image;
    private bool isVolume;

    private void Awake()
    {
        image = GetComponent<Image>();
        if (PlayerPrefs.HasKey("Volume"))
        {
            int num = PlayerPrefs.GetInt("Volume");
            audiomixer.SetFloat("MasterVolume", num * 80 - 80);
            image.sprite = volumeIconOffOn[num];
        }
        else {
            PlayerPrefs.SetInt("Volume", 1);
        }
    }

    public void ChangeVolume() {
        if (PlayerPrefs.GetInt("Volume") == 1) {
            audiomixer.SetFloat("MasterVolume", -80);
            image.sprite = volumeIconOffOn[0];
            PlayerPrefs.SetInt("Volume", 0);
        }
        else{
            audiomixer.SetFloat("MasterVolume", 0);
            image.sprite = volumeIconOffOn[1];
            PlayerPrefs.SetInt("Volume", 1);
        }
    }




}
