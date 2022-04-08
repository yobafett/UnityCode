using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShowHideUIByMove : ShowHideByTween
{
    [SerializeField] private Ease displayEase = Ease.OutBack;
    [SerializeField] private float displayDuration = 0.5f;
    [SerializeField] private Vector2 hidePosition;
    [SerializeField] private Ease hideEase = Ease.InBack;
    [SerializeField] private float hideDuration = 0.5f;
    [SerializeField] private bool hideOnStart;
    
    private Vector2 _displayPosition;
    private RectTransform _rectTransform;
    private bool _onDisplay;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _displayPosition = _rectTransform.anchoredPosition;
        _onDisplay = true;
        
        if (!hideOnStart) 
            return;
        _rectTransform.anchoredPosition = hidePosition;
        _onDisplay = false;
    }

    public override Tween Show(float delay = 0) => 
        _rectTransform.DOAnchorPos(_displayPosition, displayDuration)
            .SetEase(displayEase)
            .SetDelay(delay).OnComplete((() =>
            {
                _onDisplay = true;
            }));
    
    public override Tween Hide(float delay = 0) => 
        _rectTransform.DOAnchorPos(hidePosition, hideDuration)
            .SetEase(hideEase)
            .SetDelay(delay).OnComplete((() =>
            {
                _onDisplay = false;
            }));

    public override bool OnDisplay() => _onDisplay;
}
