using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;
using System;

namespace TestProject
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField]
        private TextMesh m_TimerText;
        private BonusSettings m_Settings;

        public event Action<Vector2> OnExploded;

        [Inject]
        void Construct(BonusSettings settings)
        {
            m_Settings = settings;
        }

        private void Awake()
        {
            StartCoroutine(Timer());
        }

        IEnumerator Timer()
        {
            var time = m_Settings.Bomb.timeToExplosion;

            while (time > 0)
            {
                m_TimerText.text = time.ToString();
                time--;
                yield return new WaitForSeconds(1f);

            }

            Debug.Log("Boom!");
            OnExploded?.Invoke(transform.position);
            Destroy(gameObject);


        }

        public class Factory : PlaceholderFactory<Bomb> { }

    }

}
