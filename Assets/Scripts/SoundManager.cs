using UnityEngine;

namespace KID
{
    /// <summary>
    /// 音效管理器，播放無距離感的音效
    /// </summary>
    // Require Component 要求元件：第一次套用腳本會添加 () 內的元件
    [RequireComponent(typeof(AudioSource))]
    [DefaultExecutionOrder(0)]
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            instance = this;
        }

        /// <summary>
        /// 播放音效，固定 1 音量
        /// </summary>
        /// <param name="sound">要播放的音效</param>
        public void PlaySound(AudioClip sound)
        {
            audioSource.PlayOneShot(sound);
        }

        /// <summary>
        /// 播放音效，隨機音量
        /// </summary>
        /// <param name="sound">要播放的音效</param>
        /// <param name="minVolume">最小音量</param>
        /// <param name="maxVolume">最大音量</param>
        public void PlaySound(AudioClip sound, float minVolume, float maxVolume)
        {
            float randomVolume = Random.Range(minVolume, maxVolume);
            audioSource.PlayOneShot(sound, randomVolume);
        }
    }
}
