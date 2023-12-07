using UnityEngine;

namespace KID
{
    /// <summary>
    /// 武器物件
    /// </summary>
    public class WeaponObject : MonoBehaviour
    {
        [HideInInspector]
        public float attack;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}
