using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LoopedMove : MonoBehaviour
{
    [SerializeField] private bool playOnStart = true;
    [SerializeField] private Vector2 pos = new Vector2(50f, 0f);
    [SerializeField] private float duration = 5f;
    [SerializeField] private LoopType loopType = LoopType.Yoyo;
    
    private RectTransform _rectTransform;
    private Tween _tween;
    private bool _isActive;

    private void Awake()
    {
        _rectTransform = gameObject.GetComponent<RectTransform>();
        _rectTransform.localScale *= 1.1f;
        _tween = _rectTransform.DOAnchorPos(pos, duration).SetLoops(-1,loopType);
        
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
