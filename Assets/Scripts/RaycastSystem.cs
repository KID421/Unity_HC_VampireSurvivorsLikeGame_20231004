using UnityEngine;

namespace KID
{
    /// <summary>
    /// 射線系統
    /// </summary>
    public class RaycastSystem : MonoBehaviour
    {
        [SerializeField, Header("圖層")]
        private LayerMask layerTarget;

        private RaycastHit hit;

        private void Update()
        {
            CheckRaycast();
        }

        /// <summary>
        /// 檢查射線碰撞
        /// </summary>
        private void CheckRaycast()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 pos = Camera.main.transform.position;
                Vector3 forward = Camera.main.transform.forward;

                if (Physics.Raycast(pos, forward, out hit, 100, layerTarget))
                {
                    print($"<color=#f69>射線打到的物件：{hit.collider.gameObject.name}</color>");
                }
            }
        }
    }
}
