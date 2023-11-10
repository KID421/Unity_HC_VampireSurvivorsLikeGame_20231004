using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 技能管理器
    /// </summary>
    public class SkillManager : MonoBehaviour
    {
        public static SkillManager instance;

        [SerializeField, Header("全部技能資料")]
        private DataSkill[] dataSkills;

        private List<DataSkill> randomSkills = new List<DataSkill>();

        /// <summary>
        /// 技能介面
        /// </summary>
        private CanvasGroup groupSkill;
        /// <summary>
        /// 技能 1 ~ 3 變形元件
        /// </summary>
        private Transform[] transformSkills = new Transform[3];

        private void Awake()
        {
            instance = this;
            groupSkill = GameObject.Find("技能介面").GetComponent<CanvasGroup>();

            for (int i = 0; i < 3; i++)
            {
                transformSkills[i] = GameObject.Find($"技能 {(i + 1)}").transform;
            }
        }

        /// <summary>
        /// 開始淡入技能介面
        /// </summary>
        public void StartFadeInGroupSkill()
        {
            Time.timeScale = 0;
            RandomSkill();
            StartCoroutine(FadeInGroupSkill());
        }

        /// <summary>
        /// 淡入技能介面
        /// </summary>
        private IEnumerator FadeInGroupSkill()
        {
            for (int i = 0; i < 10; i++)
            {
                groupSkill.alpha += 0.1f;
                yield return new WaitForSecondsRealtime(0.05f);
            }

            groupSkill.interactable = true;
            groupSkill.blocksRaycasts = true;
        }

        /// <summary>
        /// 隨機技能
        /// </summary>
        private void RandomSkill()
        {
            randomSkills = dataSkills.Where(x => x.lv < 5).ToList();
            randomSkills = randomSkills.OrderBy(x => Random.Range(0, 999)).ToList();

            UpdateSkillUI();
        }

        /// <summary>
        /// 更新技能介面，技能 1 ~ 3
        /// </summary>
        private void UpdateSkillUI()
        {
            for (int i = 0; i < 3; i++)
            {
                DataSkill dataSkill = randomSkills[i];
                transformSkills[i].Find("技能名稱").GetComponent<TextMeshProUGUI>().text = dataSkill.skillName;
                transformSkills[i].Find("技能圖片").GetComponent<Image>().sprite = dataSkill.skillPicture;
                transformSkills[i].Find("技能描述底圖/技能描述").GetComponent<TextMeshProUGUI>().text = dataSkill.skillDescription;

                for (int j = 0; j < dataSkill.lv; j++)
                {
                    transformSkills[i].Find($"等級底圖/星星/星星 {(j + 1)}").GetComponent<Image>().color = Color.white;
                }
            }
        }
    }
}
