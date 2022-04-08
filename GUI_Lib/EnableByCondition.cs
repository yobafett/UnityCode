using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SwitchVisual))]
public class EnableByCondition : MonoBehaviour
{
    [SerializeField] private Switchable[] conditions;
    [SerializeField] private bool needAll;
    
    public bool IsActive { get; private set; }
    private SwitchVisual _switchable;

    private void Awake()
    {
        _switchable = GetComponent<SwitchVisual>();
    }

    private void Start()
    {
        foreach (Switchable switcher in conditions)
        {
            if (switcher.gameObject.TryGetComponent(out Button btn))
            {
                btn.onClick.AddListener(CheckConditions);
            }
        }
    }

    private void CheckConditions()
    {
        bool condition = false;
        foreach (Switchable switcher in conditions)
        {
            if (needAll)
            {
                if (switcher.IsActive)
                    condition = true;
                else
                {
                    condition = false;
                    break;
                }
            }
            else
            {
                if (!switcher.IsActive) 
                    continue;
                
                condition = true;
                break;
            }
        }
        
        if (condition && !IsActive)
        {
            _switchable.On();
            IsActive = true;
        }

        if (!condition && IsActive)
        {
            _switchable.Off();
            IsActive = false;
        }
    }
}
