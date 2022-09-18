using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private Text _timertext;
        [SerializeField] private MovingController _movingController;
        private TrainCharacteristics _trainCharacteristics;
        private ViewsHolder _viewsHolder;
        
        private int minuts = 1;
        private float seconds;
        private bool isActive;

        private void Start()
        {
            _viewsHolder = ViewsHolder.instance;
            _trainCharacteristics = TrainCharacteristics.instance;
            isActive = true;
        }
        void FixedUpdate()
        {
            if (isActive)
            {
                if ((int) seconds == 0)
                {
                    seconds = 59;
                    if (minuts != 0)
                    {
                        minuts--;
                    }
                    else
                    {
                        isActive = false;
                        minuts = 0;
                        seconds = 0;
                        _viewsHolder.GameOverView.gameObject.SetActive(true);
                        _viewsHolder.GameOverView.SetTextResult(_trainCharacteristics.GetBoxCount());
                        _viewsHolder.TrainControllerView.gameObject.SetActive(false);
                        _movingController.SetCurrentSpeed(0);
                    }
                }
                _timertext.text = minuts.ToString("D2") + ":" + seconds.ToString("00.00");
                seconds -= Time.deltaTime;
            }
        }
    }
}