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
            InvokeRepeating("SpawnEnemy", 0, interval);
        }

        /// <summary>
        /// 生成敵人
        /// </summary>
        private void SpawnEnemy()
        {
            Instantiate(prefabEnemy, transform.position, Quaternion.identity);
        }
    }
}
