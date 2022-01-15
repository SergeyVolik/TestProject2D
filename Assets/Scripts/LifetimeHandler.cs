using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestProject
{
    public class LifetimeHandler : MonoBehaviour
    {
        [HideInInspector]
        public float lifeTime;
        [SerializeField]
        private TMPro.TMP_Text m_Text;

        public event Action Died;

        IEnumerator Start()
        {
            var time = lifeTime;

            while (time > 0)
            {
                m_Text.text = time.ToString();
                time--;
                yield return new WaitForSeconds(1f);

            }

            Debug.Log("Boom!");

            Died?.Invoke();

        }

    }

}
