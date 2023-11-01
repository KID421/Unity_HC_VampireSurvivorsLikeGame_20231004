using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 遊戲場景
    /// </summary>
    public class SceneGame : SceneSystem
    {
        [SerializeField, Header("按鈕重新遊戲")]
        private Button btnReplay;
        [SerializeField, Header("按鈕離開遊戲")]
        private Button btnQuit;

        private void Awake()
        {
            btnReplay.onClick.AddListener(() => ChangeScene("遊戲場景"));
            btnQuit.onClick.AddListener(Quit);
        }
    }
}
