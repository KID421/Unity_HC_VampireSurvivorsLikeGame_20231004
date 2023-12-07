using UnityEngine;

namespace KID
{
    public class UpgradeEatRange : MonoBehaviour, IUpgradeSkill
    {
        [SerializeField, Header("技能吃道具範圍")]
        private DataSkill dataSkill;
        [SerializeField, Header("玩家吃道具碰撞")]
        private CircleCollider2D playerEatCollider;

        public void ResetToLv1()
        {
            dataSkill.lv = 1;
        }

        public void UpgradeSkill()
        {
            int lv = dataSkill.lv;
            playerEatCollider.radius = dataSkill.skillValues[lv - 1];
        }
    }
}
