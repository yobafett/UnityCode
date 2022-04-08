using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class OnClickScale : MonoBehaviour
{
    [SerializeField] private float scaleDelta = 0.75f;
    [SerializeField] private float duration = 0.25f;
    
    private void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener((() =>
        {
            var rt = gameObject.GetComponent<RectTransform>();
            var defScale = rt.localScale;
            rt.DOScale(defScale * scaleDelta, duration / 2f).OnComplete((() =>
            {
                rt.DOScale(defScale, duration / 2f);
            }));
        }));
    }
}
