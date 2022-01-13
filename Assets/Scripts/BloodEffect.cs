using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    [RequireComponent(typeof(ParticleSystem))]
    public class BloodEffect : MonoBehaviour
    {
        ParticleSystem m_Effect;
        private void Awake()
        {
            m_Effect = GetComponent<ParticleSystem>();
        }

        public void Play()
        {
            m_Effect.Play();

            StartCoroutine(WaitEnd());
        }

        IEnumerator WaitEnd()
        {
            yield return new WaitWhile(() => m_Effect.isPlaying);
            Destroy(gameObject);
        }
        public class Factory : PlaceholderFactory<BloodEffect>
        {
            
        }
    }

}
