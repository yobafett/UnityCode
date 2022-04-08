using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIScreenTransition : MonoBehaviour
{
    [SerializeField] private UIScreen fromScreen;
    [SerializeField] private UIScreen toScreen;
    [SerializeField] private Button trigger;

    private void Awake()
    {
        trigger.onClick.AddListener((() =>
        {
            fromScreen.Hide().OnComplete((() =>
            {
                fromScreen.enabled = false;
                toScreen.enabled = true;
                toScreen.Show();
            }));
        }));
    }
}
