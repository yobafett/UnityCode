using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchVisual : MonoBehaviour
{
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Image[] targetImages;
    [SerializeField] private Button[] targetButtons;
    [SerializeField] private TextMeshProUGUI[] targetTexts;
    [SerializeField] private Color onTextColor;
    [SerializeField] private Color offTextColor;

    public void On()
    {
        if(targetImages.Length > 0)
            foreach (Image item in targetImages)
                item.sprite = onSprite;
        if(targetButtons.Length > 0)
            foreach (Button item in targetButtons)
                item.interactable = true;
        if(targetTexts.Length > 0)
            foreach (TextMeshProUGUI item in targetTexts)
                item.color = onTextColor;         
    }

    public void Off()
    {
        if(targetImages.Length > 0)
            foreach (Image item in targetImages)
                item.sprite = offSprite;
        if(targetButtons.Length > 0)
            foreach (Button item in targetButtons)
                item.interactable = false;
        if(targetTexts.Length > 0)
            foreach (TextMeshProUGUI item in targetTexts)
                item.color = offTextColor;       
    }
}