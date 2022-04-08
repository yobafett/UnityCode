using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOthers : MonoBehaviour
{
    [SerializeField] private Switchable[] others;

    public void Switch(bool state)
    {
        foreach (Switchable other in others)
        {
            if(state)
                other.On();
            else
                other.Off();
        }
    }
}
