using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundShot : MonoBehaviour
    {
        AudioSource m_Source;

        private void Awake()
        {
            m_Source = GetComponent<AudioSource>();
        }

        public void Play(AudioSettingsSO settings)
        {
            settings.Play(m_Source);
            StartCoroutine(WaitEnd());
        }

        IEnumerator WaitEnd()
        {
            yield return new WaitWhile(() => m_Source.isPlaying);

            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<SoundShot> { }
            
    }

}
