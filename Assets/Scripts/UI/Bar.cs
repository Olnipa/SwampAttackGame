using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider _slider;
    
    protected void OnValueChanged(int currentValue, int maxValue)
    {
        _slider.value = (float)currentValue / maxValue;
    }
}