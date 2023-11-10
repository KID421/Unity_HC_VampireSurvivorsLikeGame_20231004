using UnityEngine;
using System.Collections;

namespace KID
{
    /// <summary>
    /// 技能管理器
    /// </summary>
    public class SkillManager : MonoBehaviour
    {
        public static SkillManager instance;

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
    }
}
