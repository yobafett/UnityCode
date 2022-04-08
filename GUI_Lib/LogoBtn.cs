using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LogoBtn : MonoBehaviour
{
    [SerializeField] private bool playOnStart = true;
    [SerializeField] private Vector3 rotation = new Vector3(0f, 0f, 10f);
    [SerializeField] private float duration = 1f;
    [SerializeField] private LoopType loopType = LoopType.Yoyo;
    
    private RectTransform _rectTransform;
    private Tween _tween;
    private bool _isActive;

    private void Awake()
    {
        _rectTransform = gameObject.GetComponent<RectTransform>();
        _tween = _rectTransform.DORotate(rotation, duration).SetLoops(-1,loopType);
        
        if(!playOnStart) 
            _tween.Pause();
        
        gameObject.GetComponent<Button>().onClick.AddListener((() =>
        {
            SetActive(false);
            _rectTransform.DORotate(new Vector3(0f, 0f, 359f), 0.5f, RotateMode.FastBeyond360).OnComplete((() =>
            {
                _rectTransform.DOScale(Vector3.zero, 0.5f);
            }));
        }));
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
