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
                // print($"<color=#f69>波數：{ i + 1 }</color>");
                ChangeSpawnData(dataSpawnEnemys[i]);
                float duration = dataSpawnEnemys[i].spawnDuration;
                yield return new WaitForSeconds(duration);
            }

            yield return null;
            StopSpwan();
        }

        /// <summary>
        /// 變更要生成的資料
        /// </summary>
        /// <param name="dataSpawnEnemy">該波數的資料</param>
        private void ChangeSpawnData(DataSpawnEnemy dataSpawnEnemy)
        {
            // 如果是 BOSS 波
            if (dataSpawnEnemy.isBoss)
            {
                // 隨機取一個生成點
                int randomIndex = Random.Range(0, spawnEnemySystems.Length);
                // 呼叫該生成點的重新生成
                spawnEnemySystems[randomIndex].RestartSpawn(
                    dataSpawnEnemy.interval, dataSpawnEnemy.prefabEnemy);
                return;
            }

            for (int i = 0; i < spawnEnemySystems.Length; i++)
            {
                spawnEnemySystems[i].RestartSpawn(
                    dataSpawnEnemy.interval, dataSpawnEnemy.prefabEnemy);
            }
        }

        /// <summary>
        /// 停止生成
        /// </summary>
        private void StopSpwan()
        {
            for (int i = 0; i < spawnEnemySystems.Length; i++)
            {
                spawnEnemySystems[i].StopSpawn();
            }
        }
    }
}
