using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(RectMask2D))]
public class MaskedGraphByW : MonoBehaviour
{
    [SerializeField] private UnityEvent onCompleteEvent;
    [SerializeField] private TextMeshProUGUI progressPercent;
    
    private RectMask2D _rectMask2D;
    private Vector4 _defaultPadding;
    private float _startValue;
    private float _currentValue;
    
    private void Awake()
    {
        _rectMask2D = GetComponent<RectMask2D>();
        _defaultPadding = _rectMask2D.padding;
        _currentValue = _startValue = _defaultPadding.w;
    }

    public void StartAnim()
    {
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        while (_currentValue > 0)
        {
            _currentValue--;
            _rectMask2D.padding = new Vector4(_defaultPadding.x,_defaultPadding.y,_defaultPadding.z,_currentValue);
            progressPercent.text = (int) (Mathf.InverseLerp(_startValue, 0f, _currentValue) * 100) + "%";
            yield return null;
        }
        
        onCompleteEvent?.Invoke();
    }
}
