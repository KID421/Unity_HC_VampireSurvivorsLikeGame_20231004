using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 開始畫面場景
    /// </summary>
    public class SceneStart : SceneSystem
    {
        [SerializeField, Header("按鈕開始遊戲")]
        private Button btnStart;
        [SerializeField, Header("按鈕離開遊戲")]
        private Button btnQuit;

        private void Awake()
        {
            btnStart.onClick.AddListener(() => ChangeScene("遊戲場景"));
            btnQuit.onClick.AddListener(Quit);
        }
    }
}
