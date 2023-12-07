using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人 BOSS 受傷系統：死亡後遊戲勝利
    /// </summary>
    public class DamageEnemyBoss : DamageEnemy
    {
        protected override void Dead()
        {
            base.Dead();
            GameManager.instance.StartShowFinal("挑戰成功");
            Time.timeScale = 0;
        }
    }
}
