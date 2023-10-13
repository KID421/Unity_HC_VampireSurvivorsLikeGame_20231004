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

        private void Awake()
        {
            pointPlayer = GameObject.Find(namePlayer).transform;
        }

        private void Update()
        {
            Move();
            Flip();
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position, pointPlayer.position, moveSpeed);
        }

        /// <summary>
        /// 翻面：根據與玩家的 X 做比較
        /// X > 玩家的 X，角度：0，0，0
        /// X < 玩家的 X，角度：0，180，0
        /// </summary>
        private void Flip()
        {
            if (transform.position.x > pointPlayer.position.x) transform.eulerAngles = Vector3.zero;
            else if (transform.position.x < pointPlayer.position.x) transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
