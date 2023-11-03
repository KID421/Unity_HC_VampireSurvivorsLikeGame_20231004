using UnityEngine;

namespace KID
{
    /// <summary>
    /// 旋轉物件
    /// </summary>
    public class RotateObject : MonoBehaviour
    {
        [SerializeField, Header("旋轉物件"), Range(0, 3000)]
        private float speed = 3.5f;

        [HideInInspector]
        public int direction = -1;

        private void Update()
        {
            Rotate();
        }

        /// <summary>
        /// 旋轉
        /// </summary>
        private void Rotate()
        {
            transform.Rotate(0, 0, speed * Time.deltaTime * direction);
        }
    }
}
