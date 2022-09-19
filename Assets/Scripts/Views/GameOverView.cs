using System;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private Text _yourResult;
        [SerializeField] private Text _bestResult;
        [SerializeField] private Button _restartButton;

        private void Start()
        {
            _restartButton.onClick.AddListener(()=>SceneManager.LoadScene(0));
        }

        public void SetTextResult(int boxCount)
        {
            _yourResult.text = "Ты собрал " + boxCount + " груз!";

            int lastBestResult = PlayerPrefs.GetInt("bestResult");
            if (lastBestResult > boxCount)
            {
                _bestResult.text = "Лучший результат: " + lastBestResult;
            }
            else
            {
                _bestResult.text = "Лучший результат: " + boxCount;
                PlayerPrefs.SetInt("bestResult", boxCount);
            }
        }
    }
}