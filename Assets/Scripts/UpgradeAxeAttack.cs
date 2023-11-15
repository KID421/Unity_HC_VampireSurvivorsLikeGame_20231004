using UnityEngine;

namespace KID
{
    public class UpgradeAxeAttack : MonoBehaviour, IUpgradeSkill
    {
        public void ResetToLv1()
        {
            throw new System.NotImplementedException();
        }

        public void UpgradeSkill()
        {
            print("升級斧頭攻擊");
        }
    }
}
