using UnityEngine;

namespace KID
{
    public class UpgradeAxeAttack : MonoBehaviour, IUpgradeSkill
    {
        [SerializeField, Header("技能斧頭攻擊")]
        private DataSkill dataSkill;
        [SerializeField, Header("斧頭武器物件")]
        private WeaponObject weaponAxe;

        public void ResetToLv1()
        {
            dataSkill.lv = 1;
            weaponAxe.attack = dataSkill.skillValues[0];
        }

        public void UpgradeSkill()
        {
            int lv = dataSkill.lv;
            weaponAxe.attack = dataSkill.skillValues[lv - 1];
        }
    }
}
