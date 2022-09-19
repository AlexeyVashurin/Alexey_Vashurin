using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrainSignalView: MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Button _signalButton;
    [SerializeField] private AudioSource _signalSource;

    private void Start()
    {
        _signalButton = gameObject.GetComponent<Button>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       _signalSource.Stop();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _signalSource.Play();
    }
}