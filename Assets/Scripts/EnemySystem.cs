using UnityEngine;
using System.Collections;

namespace KID
{
    /// <summary>
    /// 敵人系統：追蹤玩家、攻擊並造成傷害
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("角色資料")]
        private DataEnemy data;
        [SerializeField, Header("攻擊範圍位移")]
        private Vector3 attackRangeOffset;

        private Transform pointPlayer;
        private string namePlayer = "女學生";
        private Animator ani;
        private string parAttack = "觸發攻擊";
        private string parIdle = "開關等待";
        private bool canAttack = true;
        #endregion

        #region 事件
        private void Awake()
        {
            pointPlayer = GameObject.Find(namePlayer).transform;
            ani = GetComponent<Animator>();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.3f, 0.3f, 0.8f, 0.5f);
            Gizmos.DrawSphere(transform.position + attackRangeOffset, data.attackRange);
        }

        private void Update()
        {
            if (Vector2.Distance(transform.position + attackRangeOffset, pointPlayer.position) < data.attackRange)
            {
                Attack();
            }
            else
            {
                Move();
            }

            Flip();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 攻擊
        /// </summary>
        private void Attack()
        {
            if (canAttack)
            {
                StartCoroutine(AttackBehaviour());  
            }
        }

        private IEnumerator AttackBehaviour()
        {
            canAttack = false;
            ani.SetTrigger(parAttack);
            ani.SetBool(parIdle, true);
            yield return new WaitForSeconds(data.attackSendTime);
            print("造成玩家傷害");
            yield return new WaitForSeconds(data.attackEndWaitTime);
            canAttack = true;
        }

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position, pointPlayer.position, data.speed * Time.deltaTime);
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
        #endregion
    }
}
