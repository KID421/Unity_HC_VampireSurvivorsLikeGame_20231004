using UnityEngine;

namespace KID
{
    /// <summary>
    /// 技能管理器
    /// </summary>
    public class SkillManager : MonoBehaviour
    {
        /// <summary>
        /// 技能介面
        /// </summary>
        private CanvasGroup groupSkill;

        private void Awake()
        {
            groupSkill = GameObject.Find("技能介面").GetComponent<CanvasGroup>();
        }
    }
}
