using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人受傷
    /// </summary>
    public class DamageEnemy : DamageSystem
    {
        private string playerWeaponName = "武器";

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains(playerWeaponName))
            {
                Damage(50);
            }
        }
    }
}
