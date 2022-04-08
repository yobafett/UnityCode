using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LoopedScale : MonoBehaviour
{
    [SerializeField] private bool playOnStart = true;
    [SerializeField] private Vector3 targetScale = new Vector3(1.25f, 1.25f, 1.25f);
    [SerializeField] private float duration = 5f;
    
    private RectTransform _rectTransform;
    private Tween _tween;
    private bool _isActive;

    private void Awake()
    {
        _rectTransform = gameObject.GetComponent<RectTransform>();
        _tween = _rectTransform.DOScale(targetScale, duration).SetLoops(-1, LoopType.Yoyo);

        if(!playOnStart) 
            _tween.Pause();
    }

    public void SetActive(bool value)
    {
        if(_isActive == value) 
            return;
        
        if (value)
            _tween.Play();
        else
            _tween.Pause();

        _isActive = value;
    }
}
