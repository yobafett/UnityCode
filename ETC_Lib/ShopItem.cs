using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private ShopItemScriptableObject itemData;
    [SerializeField] private Image spritePreview;
    [SerializeField] private Button useBtn;
    [SerializeField] private TextMeshProUGUI useBtnText;
    [SerializeField] private GameObject itemBlocker;
    [SerializeField] private GameObject pricePanel;
    [SerializeField] private TextMeshProUGUI priceText;

    private void Awake()
    {
        spritePreview.sprite = itemData.GetPreviewSprite();
        
        if (itemData.IsAvailable())
        {
            useBtnText.text = "Use";
            pricePanel.SetActive(false);
            itemBlocker.SetActive(false);
        }
        else
        {
            useBtnText.text = "Buy";
            priceText.text = itemData.GetPrice().ToString();
        }
        
        useBtn.onClick.AddListener((() =>
        {
            AudioManager.Instance.PlayClickSound();
            
            if (itemData.IsAvailable())
            {
                SlotManager.Instance.ResetSlotItems(itemData.GetSprites());
            }
            else
            {
                if (GameManager.Instance.ReduceScore(itemData.GetPrice()))
                {
                    itemData.SetAvailable();
                    
                    useBtnText.DOFade(0f, 0.15f).OnComplete((() =>
                    {
                        useBtnText.text = "Use";
                        useBtnText.DOFade(1f, 0.15f);
                    }));
                    pricePanel.GetComponent<Image>().DOFade(0f, 0.25f).OnComplete((() =>
                    {
                        pricePanel.SetActive(false);
                    }));
                    itemBlocker.GetComponent<Image>().DOFade(0f, 0.25f).OnComplete((() =>
                    {
                        itemBlocker.SetActive(false);
                    }));
                }
            }
        }));
    }
}
