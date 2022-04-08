using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Button exitBtn;
    [SerializeField] private TextMeshProUGUI[] scores;
    
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Landscape;

        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        exitBtn.onClick.AddListener((() =>
        {
            AudioManager.Instance.PlayClickSound();
            GameManager.Instance.Exit();
        }));
    }

    public void UpdateScore(int value)
    {
        foreach (var score in scores)
        {
            score.text = value.ToString();
        }
    } 
    
    public void DisableControls() => eventSystem.enabled = false;
    
    public void EnableControls() => eventSystem.enabled = true;
}