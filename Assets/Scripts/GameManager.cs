using UnityEngine;
using System.Collections;
using TMPro;

namespace KID
{
    /// <summary>
    /// 遊戲管理器
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [SerializeField, Header("結束畫面")]
        private CanvasGroup groupFinal;
        [SerializeField, Header("結束標題")]
        private TextMeshProUGUI textFinalTitle;

        private void Awake()
        {
            instance = this;
        }

        /// <summary>
        /// 開始顯示結束畫面
        /// </summary>
        /// <param name="title">結束畫面標題</param>
        public void StartShowFinal(string title)
        {
            textFinalTitle.text = title;
            StartCoroutine(ShowFinal());
        }

        private IEnumerator ShowFinal()
        {
            yield return new WaitForSecondsRealtime(1.2f);

            for (int i = 0; i < 10; i++)
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSecondsRealtime(0.03f);
            }

            groupFinal.interactable = true;
            groupFinal.blocksRaycasts = true;
        }
    }
}
