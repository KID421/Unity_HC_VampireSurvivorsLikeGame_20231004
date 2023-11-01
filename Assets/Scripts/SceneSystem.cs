using UnityEngine;
using UnityEngine.SceneManagement;

namespace KID
{
    /// <summary>
    /// 場景系統：場景切換與退出遊戲
    /// </summary>
    public class SceneSystem : MonoBehaviour
    {
        /// <summary>
        /// 切換場景
        /// </summary>
        /// <param name="nameToChange">要切換的場景名稱</param>
        protected void ChangeScene(string nameToChange)
        {
            SceneManager.LoadScene(nameToChange);
        }

        /// <summary>
        /// 退出遊戲
        /// </summary>
        protected void Quit()
        {
            Application.Quit();
        }
    }
}
