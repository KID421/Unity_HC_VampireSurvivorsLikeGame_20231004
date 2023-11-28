using UnityEngine;

namespace KID
{
    /// <summary>
    /// 武器系統：生成武器
    /// </summary>
    public class SpawnWeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("武器預製物")]
        private GameObject prefabWeapon;
        [SerializeField, Header("發射力道")]
        private Vector2 firePower;

        [HideInInspector]
        public float interval = 3;

        private void Awake()
        {
            InvokeRepeating("SpawnWeapon", 0, interval);
        }

        private void OnDisable()
        {
            CancelInvoke("SpawnWeapon");
        }

        /// <summary>
        /// 生成武器
        /// </summary>
        private void SpawnWeapon()
        {
            GameObject tempWeapon = Instantiate(prefabWeapon, transform.position, Quaternion.identity);
            tempWeapon.GetComponent<Rigidbody2D>().AddForce(transform.root.right * firePower.x + transform.root.up * firePower.y);
            tempWeapon.GetComponent<RotateObject>().direction = -(int)transform.root.right.x;
        }

        /// <summary>
        /// 重新啟動生成：為了讓 interval 間隔可以重新設定
        /// </summary>
        public void RestartSpawn()
        {
            CancelInvoke("SpawnWeapon");
            InvokeRepeating("SpawnWeapon", 0, interval);
        }
    }
}
