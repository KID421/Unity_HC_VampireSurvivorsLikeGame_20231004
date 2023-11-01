using UnityEngine;

namespace KID
{
    /// <summary>
    /// 經驗值物件：朝玩家方向移動
    /// </summary>
    public class ExpObject : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Range(0, 10)]
        private float speed = 3.5f;

        private Transform pointPlayer;
        private string namePlayer = "女學生";

        private void Awake()
        {
            pointPlayer = GameObject.Find(namePlayer).transform;
        }

        private void Update()
        {
            Move();
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            transform.position = Vector2.MoveTowards(
                transform.position, 
                pointPlayer.position + Vector3.up, 
                speed * Time.deltaTime);
        }
    }
}
