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
        [SerializeField, Header("丟武器音效")]
        private AudioClip soundThrowWeapon;

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
            SoundManager.instance.PlaySound(soundThrowWeapon, 1.2f, 2.2f);
            GameObject tempWeapon = Instantiate(prefabWeapon, transform.position, Quaternion.identity);
            tempWeapon.GetComponent<RotateObject>().direction = -(int)transform.root.right.x;
            float direction = transform.root.eulerAngles.y == 0 ? 1 : -1;
            Vector3 fire = new Vector2(firePower.x * direction, firePower.y);
            tempWeapon.GetComponent<ConstantForce2D>().force = fire;
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
