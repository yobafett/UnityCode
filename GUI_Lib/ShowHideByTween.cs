using System;
using DG.Tweening;
using UnityEngine;

public abstract class ShowHideByTween : MonoBehaviour
{
    public abstract Tween Show(float delay = 0); 
    public abstract Tween Hide(float delay = 0);
    public abstract bool OnDisplay();
}
