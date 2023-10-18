using UnityEngine;

namespace KID
{
    /// <summary>
    /// 基本受傷
    /// </summary>
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField, Header("角色資料")]
        private DataBasic data;
        [SerializeField, Header("傷害值預製物")]
        private GameObject prefabDamage;

        private float hp;

        private void Awake()
        {
            hp = data.hp;
        }

        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">受到的傷害值</param>
        protected void Damage(float damage)
        {
            hp -= damage;
            GameObject tempDamage = Instantiate(prefabDamage, transform.position, Quaternion.identity);
            Destroy(tempDamage, 1);

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// 死亡
        /// </summary>
        private void Dead()
        {

        }
    }
}
