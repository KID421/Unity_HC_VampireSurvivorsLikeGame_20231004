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
        [SerializeField, Header("吃掉經驗值距離"), Range(0, 10)]
        private float eatDistance = 1.5f;
        [SerializeField, Header("經驗值"), Range(0, 1000)]
        private float exp = 30;
        [SerializeField, Header("吃經驗音效")]
        private AudioClip soundEatExp;

        private Transform pointPlayer;
        private string namePlayer = "女學生";

        private void Awake()
        {
            pointPlayer = GameObject.Find(namePlayer).transform;
        }

        private void Update()
        {
            Move();
            EatExp();
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

        /// <summary>
        /// 吃掉經驗值
        /// </summary>
        private void EatExp()
        {
            float dis = Vector2.Distance(transform.position, pointPlayer.position + Vector3.up);

            if (dis <= eatDistance)
            {
                LevelManager.instance.AddExp(exp);
                SoundManager.instance.PlaySound(soundEatExp, 1.5f, 2.3f);
                Destroy(gameObject);
            }
        }
    }
}
