using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

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
        [SerializeField, Header("升級技能按鈕")]
        private Button[] btnSkillUpgrade;

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

            ButtonClickAndUpgradeSkill();
        }

        /// <summary>
        /// 還原全部技能為等級 1
        /// </summary>
        private void ResetAllSkillToLv1()
        {
            GameObject[] objectSkills = GameObject.FindGameObjectsWithTag("升級技能物件");

            for (int i = 0; i < objectSkills.Length; i++)
            {
                objectSkills[i].GetComponent<IUpgradeSkill>().ResetToLv1();
            }
        }

        /// <summary>
        /// 按鈕點擊升級技能
        /// </summary>
        private void ButtonClickAndUpgradeSkill()
        {
            for (int i = 0; i < btnSkillUpgrade.Length; i++)
            {
                int index = i;
                btnSkillUpgrade[i].onClick.AddListener(() =>
                {
                    randomSkills[index].Upgrade();
                    StartCoroutine(UpgradeSkillFlow());
                });
            }
        }

        /// <summary>
        /// 升級技能流程
        /// </summary>
        /// <returns></returns>
        private IEnumerator UpgradeSkillFlow()
        {
            groupSkill.interactable = false;
            yield return new WaitForSecondsRealtime(0.3f);
            UpdateSkillUI();
            yield return new WaitForSecondsRealtime(0.5f);
            StartCoroutine(FadeGroupSkill(false));
            Time.timeScale = 1;
        }

        /// <summary>
        /// 開始淡入技能介面
        /// </summary>
        public void StartFadeInGroupSkill()
        {
            Time.timeScale = 0;
            RandomSkill();
            StartCoroutine(FadeGroupSkill());
        }

        /// <summary>
        /// 淡入淡出技能介面
        /// </summary>
        private IEnumerator FadeGroupSkill(bool fadeIn = true)
        {
            float increase = fadeIn ? +0.1f : -0.1f;

            for (int i = 0; i < 10; i++)
            {
                groupSkill.alpha += increase;
                yield return new WaitForSecondsRealtime(0.05f);
            }

            groupSkill.interactable = fadeIn;
            groupSkill.blocksRaycasts = fadeIn;
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
