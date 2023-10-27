using UnityEngine;

namespace KID
{
    /// <summary>
    /// ���H���a
    /// </summary>
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField, Header("�첾")]
        private Vector3 offset;

        private string namePlayer = "�k�ǥ�";
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
