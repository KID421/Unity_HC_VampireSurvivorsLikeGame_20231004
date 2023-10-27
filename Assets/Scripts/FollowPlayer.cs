using UnityEngine;

namespace KID
{
    /// <summary>
    /// 跟隨玩家
    /// </summary>
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField, Header("位移")]
        private Vector3 offset;

        private string namePlayer = "女學生";
        private Transform pointPlayer;

        private void Awake()
        {
            pointPlayer = GameObject.Find(namePlayer).transform;
        }

        private void Update()
        {
            transform.position = pointPlayer.position + offset;
        }
    }
}
