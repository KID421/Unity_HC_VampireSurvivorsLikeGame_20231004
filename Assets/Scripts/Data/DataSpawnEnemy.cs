using UnityEngine;

namespace KID
{
    /// <summary>
    /// 生成敵人資料：生成時間、敵人預製物與生成間隔
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Spawn Enemy", fileName = "Data Spawn Enemy")]
    public class DataSpawnEnemy : ScriptableObject
    {
        [Header("敵人預製物")]
        public GameObject prefabEnemy;
        [Header("敵人生成間隔"), Range(0, 10)]
        public float interval = 3.5f;
        [Header("敵人持續時間")]
        public float spawnDuration;
        [Header("是否為 Boss")]
        public bool isBoss;
    }
}
