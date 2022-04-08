using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(RectMask2D))]
public class MaskedGraphByZ : MonoBehaviour
{
    [SerializeField] private UnityEvent onCompleteEvent;
    
    private RectMask2D _rectMask2D;
    private Vector4 _defaultPadding;
    private float _val;
    
    private void Awake()
    {
        _rectMask2D = GetComponent<RectMask2D>();
        _defaultPadding = _rectMask2D.padding;
        _val = _defaultPadding.z;
    }

    public void StartAnim()
    {
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        while (_val > 0)
        {
            _val--;
            _rectMask2D.padding = new Vector4(_defaultPadding.x,_defaultPadding.y,_val,_defaultPadding.w);
            yield return null;
        }
        
        onCompleteEvent?.Invoke();
    }
}
