using System;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace DefaultNamespace
{
    public class FixTrainView : MonoBehaviour
    {
        [SerializeField] private Button FixButton;
        private TrainCharacteristics _trainCharacteristics;

        private void Start()
        {
            _trainCharacteristics = TrainCharacteristics.instance;
            FixButton.onClick.AddListener(() =>
            {
                _trainCharacteristics.TrainRecovery();
            });
        }
    }
}