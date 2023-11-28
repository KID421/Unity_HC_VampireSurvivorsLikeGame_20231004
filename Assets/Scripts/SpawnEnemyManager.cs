using UnityEngine;
using System.Collections;

namespace KID
{
    /// <summary>
    /// 生成敵人管理器：管理波數
    /// </summary>
    public class SpawnEnemyManager : MonoBehaviour
    {
        [SerializeField, Header("生成敵人系統物件")]
        private SpawnEnemySystem[] spawnEnemySystems;
        [SerializeField, Header("生成敵人波數資料")]
        private DataSpawnEnemy[] dataSpawnEnemys;

        private void Awake()
        {
            StartCoroutine(SpawnManager());
        }

        /// <summary>
        /// 生成管理器
        /// </summary>
        private IEnumerator SpawnManager()
        {
            for (int i = 0; i < dataSpawnEnemys.Length; i++)
            {
                print($"<color=#f69>波數：{ i + 1 }</color>");
                float duration = dataSpawnEnemys[i].spawnDuration;
                yield return new WaitForSeconds(duration);
            }
        }
    }
}
