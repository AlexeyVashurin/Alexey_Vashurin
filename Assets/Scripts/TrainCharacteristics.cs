using UnityEngine;

namespace DefaultNamespace
{
    public class TrainCharacteristics : MonoBehaviour
    {
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
        }
        [SerializeField]private int trainHealth;
        [SerializeField]private int boxCount;
        
        public void SetDamage(int damage)
        {
            trainHealth = -damage;
        }
        public void SetBoxCount(int box)
        {
            boxCount = boxCount+box;
        }
    }
}