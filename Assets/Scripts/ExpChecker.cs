using UnityEngine;

namespace KID
{
    /// <summary>
    /// 經驗值檢查器：檢查範圍內有沒有經驗值物件
    /// </summary>
    public class ExpChecker : MonoBehaviour
    {
        private string nameExp = "經驗值";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name.Contains(nameExp)) OpenExpObjectComponent(collision.gameObject);
        }

        /// <summary>
        /// 開啟經驗值物件元件
        /// </summary>
        /// <param name="expObject"></param>
        private void OpenExpObjectComponent(GameObject expObject)
        {
            expObject.GetComponent<ExpObject>().enabled = true;
        }
    }
}
