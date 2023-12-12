using TMPro;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// 基本受傷
    /// </summary>
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField, Header("角色資料")]
        protected DataBasic data;
        [SerializeField, Header("傷害值預製物")]
        private GameObject prefabDamage;
        [SerializeField, Header("傷害值位移")]
        private Vector3 damageOffset;
        [SerializeField, Header("音效受傷")]
        private AudioClip soundDamage;
        [SerializeField, Header("音效死亡")]
        private AudioClip soundDead;

        protected float hp;
        protected float hpMax;

        protected virtual void Awake()
        {
            hp = data.hp;
            hpMax = hp;
        }

        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">受到的傷害值</param>
        public virtual void Damage(float damage)
        {
            hp -= damage;
            GameObject tempDamage = Instantiate(prefabDamage, transform.position + damageOffset, Quaternion.identity);
            Destroy(tempDamage, 1);
            tempDamage.transform.GetChild(0).GetComponent<TextMeshPro>().text = damage.ToString();
            SoundManager.instance.PlaySound(soundDamage, 0.8f, 1.9f);

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// 死亡
        /// </summary>
        protected virtual void Dead()
        {
            SoundManager.instance.PlaySound(soundDead, 1.5f, 2f);
        }
    }
}
