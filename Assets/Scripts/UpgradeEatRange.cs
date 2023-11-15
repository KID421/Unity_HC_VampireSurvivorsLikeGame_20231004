using UnityEngine;

namespace KID
{
    public class UpgradeEatRange : MonoBehaviour, IUpgradeSkill
    {
        public void ResetToLv1()
        {
            throw new System.NotImplementedException();
        }

        public void UpgradeSkill()
        {
            print("升級玩家吃東西範圍");
        }
    }
}
