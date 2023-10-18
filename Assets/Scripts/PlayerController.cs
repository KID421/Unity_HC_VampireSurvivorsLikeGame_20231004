using UnityEngine;

namespace KID.TopDwon
{
    /// <summary>
    /// Top Down 類型 2D 角色控制器：移動與動畫
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("角色資料")]
        private DataBasic data;

        private string parRun = "開關跑步";
        private Animator ani;
        private Rigidbody2D rig;

        private float inputHorizontal => Input.GetAxis("Horizontal");
        private float inputVertical => Input.GetAxis("Vertical");
        #endregion

        #region 事件
        private void Awake()
        {
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
            Flip();
            UpdateAnimator();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            rig.velocity = new Vector2(inputHorizontal, inputVertical) * data.speed;
        }

        /// <summary>
        /// 翻面
        /// </summary>
        private void Flip()
        {
            if (inputHorizontal > 0) transform.eulerAngles = Vector3.zero;
            else if (inputHorizontal < 0) transform.eulerAngles = new Vector3(0, 180, 0);
        }

        /// <summary>
        /// 更新跑步與待機動畫
        /// </summary>
        private void UpdateAnimator()
        {
            ani.SetBool(parRun, inputHorizontal != 0 || inputVertical != 0);
        } 
        #endregion
    }
}
