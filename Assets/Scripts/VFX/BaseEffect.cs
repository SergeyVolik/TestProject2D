using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestProject
{
    [RequireComponent(typeof(ParticleSystem))]
    public class BaseEffect : MonoBehaviour
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
    }
}
