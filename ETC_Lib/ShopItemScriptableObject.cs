using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ShopItem", menuName = "ShopItem ScriptableObject", order = 51)]
public class ShopItemScriptableObject : ScriptableObject
{
    [SerializeField] private Sprite previewSprite;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private int price;
    [SerializeField] private bool isAvailable;

    public Sprite GetPreviewSprite() => previewSprite;
    
    public Sprite[] GetSprites() => sprites;
    
    public int GetPrice() => price;
   
    public bool IsAvailable() => isAvailable;
    
    public void SetAvailable() => isAvailable = true;
}
