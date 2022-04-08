using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    [SerializeField] private ShowHideByTween[] screenUI;
    private ShowHideByTween _screenTween;

    private void Awake()
    {
        _screenTween = gameObject.GetComponent<ShowHideByTween>();
        if(_screenTween == null)
            throw new Exception("screen tween is null");
    }

    public void Show()
    {
        _screenTween.Show();
        foreach (var item in screenUI)
            item.Show(0.25f);
    }

    public Tween Hide()
    {
        foreach (var item in screenUI)
            item.Hide();
        return _screenTween.Hide(0.25f);
    }
}
