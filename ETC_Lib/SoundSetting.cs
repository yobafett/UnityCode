using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    private enum SettingType
    {
        Sound, Music, All
    }
    
    [SerializeField] private Slider slider;
    [SerializeField] private Button button;
    [SerializeField] private SettingType type = SettingType.All;

    private Image _btnImg;
    
    private void Awake()
    {
        _btnImg = button.GetComponent<Image>();
        
        slider.onValueChanged.AddListener((arg0 =>
        {
            switch (type)
            {
                case SettingType.Sound:
                    AudioManager.Instance.SetSoundsVolume(arg0);
                    break;
                case SettingType.Music:
                    AudioManager.Instance.SetMusicVolume(arg0);
                    break;
                case SettingType.All:
                    AudioManager.Instance.SetSoundsVolume(arg0);
                    AudioManager.Instance.SetMusicVolume(arg0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            } 
        }));
        button.onClick.AddListener((() =>
        {
            bool isOn;
            switch (type)
            {
                case SettingType.Sound:
                    isOn = AudioManager.Instance.SwitchSounds();
                    break;
                case SettingType.Music:
                    isOn = AudioManager.Instance.SwitchMusic();
                    break;
                case SettingType.All:
                    AudioManager.Instance.SwitchSounds();
                    isOn = AudioManager.Instance.SwitchMusic();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _btnImg.DOFade(isOn ? 1f : 0.75f, 0.1f);
            slider.value = isOn ? 1f : 0f;
        }));
    }
}
