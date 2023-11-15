using UnityEngine;

namespace KID
{
    public class UpgradePlayerSpeed : MonoBehaviour, IUpgradeSkill
    {
        [SerializeField, Header("技能跑步速度")]
        private DataSkill dataSkill;
        [SerializeField, Header("玩家女學生資料")]
        private DataBasic dataPlayer;

        public void ResetToLv1()
        {
            throw new System.NotImplementedException();
        }

        public void UpgradeSkill()
        {
            print("升級跑步速度");
            int lv = dataSkill.lv;
            dataPlayer.speed = dataSkill.skillValues[lv - 1];
        }
    }
}
