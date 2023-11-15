using UnityEngine;

namespace KID
{
    public class UpgradeAxeInterval : MonoBehaviour, IUpgradeSkill
    {
        public void ResetToLv1()
        {
            throw new System.NotImplementedException();
        }

        public void UpgradeSkill()
        {
            print("升級斧頭生成間隔");
        }
    }
}
