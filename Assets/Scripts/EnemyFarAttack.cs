using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人遠距離攻擊
    /// </summary>
    public class EnemyFarAttack : EnemySystem
    {
        [SerializeField, Header("生成遠距物件位置")]
        private Transform pointFarObject;

        private DataEnemyFar dataEnemyFar;

        protected override void Awake()
        {
            base.Awake();
            dataEnemyFar = (DataEnemyFar)data;
        }

        protected override void AttackPlayerMethod()
        {
            GameObject tempAttackObject = Instantiate(
                dataEnemyFar.prefabFarAttackObject, pointFarObject.position, Quaternion.identity);

            // 生成的攻擊物件.取得武器物件腳本.攻擊力 = 遠距敵人資料.攻擊力
            tempAttackObject.GetComponent<WeaponObject>().attack = dataEnemyFar.attack;

            tempAttackObject.GetComponent<Rigidbody2D>().AddForce(
                transform.right * -dataEnemyFar.farAttackSpeed.x + transform.up * dataEnemyFar.farAttackSpeed.y);
        }
    }
}
