using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputByButtons : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] contents;
    [SerializeField] private Button plusButton;
    [SerializeField] private Button minusButton;
    [SerializeField] private int startValue;
    [SerializeField] private string postfix;

    private void Awake()
    {
        foreach (TextMeshProUGUI item in contents) 
            item.text = startValue + postfix;

        plusButton.onClick.AddListener((() =>
        {
            startValue++;
            foreach (TextMeshProUGUI item in contents) 
                item.text = startValue + postfix;
        }));
        
        minusButton.onClick.AddListener((() =>
        {
            startValue--;
            foreach (TextMeshProUGUI item in contents) 
                item.text = startValue + postfix;
        }));
    }
}
