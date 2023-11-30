using UnityEngine;

namespace KID
{
    /// <summary>
    /// 遠距離敵人資料
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Enemy Far", fileName = "Data Enemy Far")]
    public class DataEnemyFar : DataEnemy
    {
        [Header("遠距離的攻擊預製物")]
        public GameObject prefabFarAttackObject;
        [Header("遠距離的攻擊速度")]
        public Vector2 farAttackSpeed;
    }
}
