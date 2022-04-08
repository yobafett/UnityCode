using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShowHideUIByScale : ShowHideByTween
{
    [SerializeField] private Vector3 displayScale = Vector3.one;
    [SerializeField] private Ease displayEase = Ease.OutBack;
    [SerializeField] private float displayDuration = 0.5f;
    [SerializeField] private Vector3 hideScale = Vector3.zero;
    [SerializeField] private Ease hideEase = Ease.OutCirc;
    [SerializeField] private float hideDuration = 0.5f;
    [SerializeField] private bool hideOnStart;
    
    private RectTransform _rectTransform;
    private bool _onDisplay;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _onDisplay = true;

        if (hideOnStart)
        {
            _rectTransform.localScale = hideScale;
            _onDisplay = false;
        }
    }

    public override Tween Show(float delay = 0) => 
        _rectTransform.DOScale(displayScale, displayDuration)
            .SetEase(displayEase)
            .SetDelay(delay).OnComplete((() =>
            {
                _onDisplay = true;
            }));
    
    public override Tween Hide(float delay = 0) => 
        _rectTransform.DOScale(hideScale, hideDuration)
            .SetEase(hideEase)
            .SetDelay(delay).OnComplete((() =>
            {
                _onDisplay = false;
            }));
    
    public override bool OnDisplay() => _onDisplay;
}
