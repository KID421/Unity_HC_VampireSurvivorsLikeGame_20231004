using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人遠距離攻擊
    /// </summary>
    public class EnemyFarAttack : EnemySystem
    {
        private DataEnemyFar dataEnemyFar;

        protected override void Awake()
        {
            base.Awake();
            dataEnemyFar = (DataEnemyFar)data;
        }

        protected override void AttackPlayerMethod()
        {
            GameObject tempAttackObject = Instantiate(
                dataEnemyFar.prefabFarAttackObject, transform.position, Quaternion.identity);

            tempAttackObject.GetComponent<Rigidbody2D>().AddForce(
                transform.right * -dataEnemyFar.farAttackSpeed.x + transform.up * dataEnemyFar.farAttackSpeed.y);
        }
    }
}
