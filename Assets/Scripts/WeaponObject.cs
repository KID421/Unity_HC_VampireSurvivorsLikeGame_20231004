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

        private void Awake()
        {
            Destroy(gameObject, 5);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Destroy(gameObject);
        }
    }
}
