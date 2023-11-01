using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using KID.TopDwon;

namespace KID
{
    /// <summary>
    /// 玩家受傷
    /// </summary>
    public class DamagePlayer : DamageSystem
    {
        [SerializeField, Header("血條")]
        private Image imgHp;
        [SerializeField, Header("結束畫面")]
        private CanvasGroup groupFinal;

        private string parDead = "觸發死亡";
        private Animator ani;
        private PlayerController playerController;
        private SpawnWeaponSystem spawnWeaponSystem;

        protected override void Awake()
        {
            base.Awake();
            ani = GetComponent<Animator>();
            playerController = GetComponent<PlayerController>();
            spawnWeaponSystem = transform.Find("武器斧頭生成系統").GetComponent<SpawnWeaponSystem>();
        }

        public override void Damage(float damage)
        {
            if (hp <= 0) return;
            base.Damage(damage);

            imgHp.fillAmount = hp / hpMax;
        }

        protected override void Dead()
        {
            base.Dead();
            StartCoroutine(ShowFinal());
            ani.SetTrigger(parDead);
            playerController.enabled = false;
            spawnWeaponSystem.enabled = false;
        }

        private IEnumerator ShowFinal()
        {
            yield return new WaitForSeconds(1.2f);

            for (int i = 0; i < 10; i++)
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.03f);
            }

            groupFinal.interactable = true;
            groupFinal.blocksRaycasts = true;
        }
    }
}
