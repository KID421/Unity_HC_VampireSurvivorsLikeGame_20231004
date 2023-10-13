using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人系統：追蹤玩家、攻擊並造成傷害
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Range(0, 10)]
        private float moveSpeed = 2.5f;

        private Transform pointPlayer;
        private string namePlayer = "女學生";
    }
}
