using UnityEngine;

namespace KID
{
    public class UpgradeAxeInterval : MonoBehaviour, IUpgradeSkill
    {
        [SerializeField, Header("技能斧頭攻擊間隔")]
        private DataSkill dataSkill;
        [SerializeField, Header("武器斧頭生成系統")]
        private SpawnWeaponSystem spawnAxeSystem;

        public void ResetToLv1()
        {
            dataSkill.lv = 1;
            spawnAxeSystem.interval = dataSkill.skillValues[0];
        }

        public void UpgradeSkill()
        {
            int lv = dataSkill.lv;
            spawnAxeSystem.interval = dataSkill.skillValues[lv - 1];
            spawnAxeSystem.RestartSpawn();
        }
    }
}
