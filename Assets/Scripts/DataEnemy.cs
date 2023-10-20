using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人資料
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Enemy", fileName = "Data Enemy")]
    public class DataEnemy : DataBasic
    {
        [Header("掉落經驗值機率"), Range(0, 1)]
        public float expProbability;
        [Header("經驗值物件")]
        public GameObject expPrefab;
        [Header("攻擊力"), Range(0, 10000)]
        public float attack;
        [Header("攻擊範圍"), Range(0, 100)]
        public float attackRange;
    }
}
