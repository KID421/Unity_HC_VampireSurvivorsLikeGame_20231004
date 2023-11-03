using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 等級管理
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager instance;

        private Image imgExp;
        private TextMeshProUGUI textExp;
        private TextMeshProUGUI textLv;

        private int lv = 1;
        private float expCurrent;
        private float expNeed = 100;
        private int lvMax = 100;

        [SerializeField, Header("經驗值需求表")]
        private float[] expNeeds;

        private void Awake()
        {
            instance = this;

            imgExp = GameObject.Find("經驗值圖片").GetComponent<Image>();
            textExp = GameObject.Find("經驗值文字").GetComponent<TextMeshProUGUI>();
            textLv = GameObject.Find("等級文字").GetComponent<TextMeshProUGUI>();
            textExp.text = $"{expCurrent} / {expNeed}";
        }

        /// <summary>
        /// 添加經驗值
        /// </summary>
        /// <param name="exp">要添加的經驗值</param>
        public void AddExp(float exp)
        {
            expCurrent += exp;
            imgExp.fillAmount = expCurrent / expNeed;
            textExp.text = $"{expCurrent} / {expNeed}";

            if (expCurrent >= expNeed) LevelUp();
        }

        /// <summary>
        /// 升級
        /// </summary>
        private void LevelUp()
        {
            lv++;
            textLv.text = $"Lv {lv}";
            expCurrent -= expNeed;
            expNeed = expNeeds[lv - 1];
            imgExp.fillAmount = expCurrent / expNeed;
            textExp.text = $"{expCurrent} / {expNeed}";
        }

        /// <summary>
        /// 建立經驗值需求表資料
        /// </summary>
        [ContextMenu("建立經驗值需求表資料")]
        private void CreateExpNeeds()
        {
            expNeeds = new float[lvMax];

            for (int i = 0; i < lvMax; i++)
            {
                expNeeds[i] = (i + 1) * 100;
            }
        }
    }
}
