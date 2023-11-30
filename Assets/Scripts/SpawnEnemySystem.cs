using UnityEngine;

namespace KID
{
    /// <summary>
    /// 生成敵人系統
    /// </summary>
    public class SpawnEnemySystem : MonoBehaviour
    {
        [SerializeField, Header("敵人預製物")]
        private GameObject prefabEnemy;
        [SerializeField, Header("生成敵人間隔"), Range(0, 10)]
        private float interval = 3;

        private void Awake()
        {
            // InvokeRepeating("SpawnEnemy", 0, interval);
        }

        /// <summary>
        /// 生成敵人
        /// </summary>
        private void SpawnEnemy()
        {
            Instantiate(prefabEnemy, transform.position, Quaternion.identity);
        }

        /// <summary>
        /// 重新開始生成：有改過生成物件與間隔後要重新開始
        /// </summary>
        /// <param name="_interval">要變更的生成間隔時間</param>
        /// <param name="_prefabEnemy">要變更的生成預製物</param>
        public void RestartSpawn(float _interval, GameObject _prefabEnemy)
        {
            interval = _interval;
            prefabEnemy = _prefabEnemy;
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", 0, interval);
        }

        /// <summary>
        /// 停止生成
        /// </summary>
        public void StopSpawn()
        {
            CancelInvoke("SpawnEnemy");
        }
    }
}
