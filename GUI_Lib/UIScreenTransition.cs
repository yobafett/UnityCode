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

    private void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener((() =>
        {
            AudioManager.Instance.PlayClickSound();
            fromScreen.Hide().OnComplete((() =>
            {
                fromScreen.enabled = false;
                toScreen.enabled = true;
                toScreen.Show();
            }));
        }));
    }
}
