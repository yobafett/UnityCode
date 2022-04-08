using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SwitchVisual))]
[RequireComponent(typeof(Button))]
public class Switchable : MonoBehaviour
{
    public bool IsActive { get; private set; }
    private SwitchVisual _visual;
    private SwitchOthers _switchOthers;
    private bool _others;

    private void Awake()
    {
        _visual = GetComponent<SwitchVisual>();
        _others = TryGetComponent(out _switchOthers);
        
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (IsActive)
                Off();
            else
                On();
        });
    }

    public void Off()
    {
        _visual.Off();
        IsActive = false;
    }

    public void On()
    {
        _visual.On();
        IsActive = true;
        if(_others)
            _switchOthers.Switch(false);
    }
    
    public void On(TMP_InputField textMesh)
    {
        if(textMesh.text.Length > 0)
            On();
        else
            Off();
    }
}
