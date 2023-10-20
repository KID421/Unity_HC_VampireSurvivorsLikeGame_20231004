using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人受傷
    /// </summary>
    public class DamageEnemy : DamageSystem
    {
        private string playerWeaponName = "武器";
        private DataEnemy dataEnemy => (DataEnemy)data;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains(playerWeaponName))
            {
                Damage(50);
            }
        }

        protected override void Dead()
        {
            base.Dead();

            if (Random.value <= dataEnemy.expProbability)
            {
                Instantiate(dataEnemy.expPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
