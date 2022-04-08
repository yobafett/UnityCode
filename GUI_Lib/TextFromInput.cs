using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFromInput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TMP_InputField inputData;
    [SerializeField] private string addString;
    public void UpdateText()
    {
        text.text = $"{inputData.text}{addString}";
    }
}
