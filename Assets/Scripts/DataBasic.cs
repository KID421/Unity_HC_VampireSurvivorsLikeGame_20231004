using UnityEngine;

namespace KID
{
    /// <summary>
    /// 角色基本資料：血量、移動速度
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Basic", fileName = "Data Basic")]
    public class DataBasic : ScriptableObject
    {
        [Header("血量"), Range(0, 10000)]
        public float hp;
        [Header("移動速度"), Range(0, 10)]
        public float speed;
    }
}
