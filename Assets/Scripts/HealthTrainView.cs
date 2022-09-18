using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTrainView : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;

    public void SetSliderValue(float value)
    {
        _healthSlider.value = value;
    }
}
