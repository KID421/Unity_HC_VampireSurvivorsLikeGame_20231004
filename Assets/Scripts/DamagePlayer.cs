using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

        public override void Damage(float damage)
        {
            base.Damage(damage);

            imgHp.fillAmount = hp / hpMax;
        }

        protected override void Dead()
        {
            base.Dead();
            StartCoroutine(ShowFinal());
        }

        private IEnumerator ShowFinal()
        {
            for (int i = 0; i < 10; i++)
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}
