using UnityEngine;

namespace KID
{
    public class UpgragePlayerHp : MonoBehaviour, IUpgradeSkill
    {
        [SerializeField, Header("技能玩家血量資料")]
        private DataSkill dataSkill;
        [SerializeField, Header("玩家資料")]
        private DataBasic dataPlayer;
        [SerializeField, Header("玩家受傷系統")]
        private DamagePlayer damagePlayer;

        public void ResetToLv1()
        {
            throw new System.NotImplementedException();
        }

        public void UpgradeSkill()
        {
            print("升級玩家血量");
            int lv = dataSkill.lv;
            dataPlayer.hp = dataSkill.skillValues[lv - 1];
            damagePlayer.UpgradeAndRecoverHp();
        }
    }
}
