using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTrainView : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Text _currentBoxCount;

    public void SetSliderValue(float value)
    {
        _healthSlider.value = value;
    }

    public void SetCountOfBox(int boxCount)
    {
        _currentBoxCount.text = boxCount + " единиц груза";
    }
}
