using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class TrainCharacteristics : MonoBehaviour
    {
        
        
        [SerializeField]private int _trainHealth;
        [SerializeField]private int _boxCount;
        [SerializeField] private int _breakdownLevel;
        private MovingController movingController;
        private ViewsHolder viewsHolder;
        public static TrainCharacteristics instance { get; private set; }

        private void Awake()
        {
            if (!instance)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
                Destroy(gameObject);

            movingController = GetComponent<MovingController>();
            viewsHolder = ViewsHolder.instance;
        }

        public void SetDamage()
        {
            if (movingController.GetCurrentSpeed() > 0)
            {
                StartCoroutine(DamageCoroutine());  
            }
        }

        public void StopDamage()
        {
            StopCoroutine(DamageCoroutine());
        }

        private IEnumerator DamageCoroutine()
        {
            while (_trainHealth > 0)
            {
                _trainHealth -= Random.Range(0,10);
                yield return new WaitForSeconds(3f);
            }

            _breakdownLevel = Random.Range(1, 5);
            viewsHolder.FixTrainView.gameObject.SetActive(true);
            movingController.SetCurrentSpeed(0);
            viewsHolder.TrainControllerView.gameObject.SetActive(false);
        }

        public void TrainRecovery()
        {
            if (_trainHealth <=0)
            {
                StartCoroutine(RecoveryCoroutine());
            }
        }

        private IEnumerator RecoveryCoroutine()
        {
            while (_trainHealth <100)
            {
                    _trainHealth += 20/_breakdownLevel;
                    yield return new WaitForSeconds(1f);
            }
            viewsHolder.FixTrainView.gameObject.SetActive(false);
            viewsHolder.TrainControllerView.gameObject.SetActive(true);
            viewsHolder.TrainControllerView.SetScrollbarNull();
            StopAllCoroutines();
        }

        public void SetBoxCount(int box)
        {
            _boxCount = _boxCount+box;
        }
    }
}