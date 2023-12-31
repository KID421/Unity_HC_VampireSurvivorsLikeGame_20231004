using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 玩家受傷
    /// </summary>
    public class DamagePlayer : DamageSystem
    {
        [SerializeField, Header("血條")]
        private Image imgHp;
        [SerializeField, Header("血量文字")]
        private TextMeshProUGUI textHp;

        private string parDead = "觸發死亡";
        private Animator ani;
        private PlayerController playerController;
        private SpawnWeaponSystem spawnWeaponSystem;
        private string nameEnemyFarObject = "遠距";

        protected override void Awake()
        {
            base.Awake();
            ani = GetComponent<Animator>();
            playerController = GetComponent<PlayerController>();
            spawnWeaponSystem = transform.Find("武器斧頭生成系統").GetComponent<SpawnWeaponSystem>();
            textHp.text = hp.ToString();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // 如果 碰撞物件名稱包含＂遠距＂
            if (collision.gameObject.name.Contains(nameEnemyFarObject))
            {
                // 獲得遠距物件的攻擊力
                float attack = collision.gameObject.GetComponent<WeaponObject>().attack;
                Damage(attack);
            }
        }

        public override void Damage(float damage)
        {
            if (hp <= 0) return;
            base.Damage(damage);

            imgHp.fillAmount = hp / hpMax;
            textHp.text = hp.ToString();
        }

        /// <summary>
        /// 升級並且恢復血量
        /// </summary>
        public void UpgradeAndRecoverHp()
        {
            hp = data.hp;
            hpMax = data.hp;
            imgHp.fillAmount = hp / hpMax;
            textHp.text = hp.ToString();
        }

        protected override void Dead()
        {
            base.Dead();
            GameManager.instance.StartShowFinal("挑戰失敗");
            ani.SetTrigger(parDead);
            playerController.enabled = false;
            spawnWeaponSystem.enabled = false;
        }
    }
}
