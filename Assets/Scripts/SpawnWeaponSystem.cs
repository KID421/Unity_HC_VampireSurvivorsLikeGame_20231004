using UnityEngine;

namespace KID.TopDwon
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
        [SerializeField, Header("生成間隔"), Range(0, 10)]
        private float interval = 3;

        private void Awake()
        {
            InvokeRepeating("SpawnWeapon", 0, interval);
        }

        /// <summary>
        /// 生成武器
        /// </summary>
        private void SpawnWeapon()
        {
            GameObject tempWeapon = Instantiate(prefabWeapon, transform.position, Quaternion.identity);
            tempWeapon.GetComponent<Rigidbody2D>().AddForce(transform.root.right * firePower.x + transform.root.up * firePower.y);
        }
    }
}
