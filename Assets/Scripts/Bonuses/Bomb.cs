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
        private BonusSettings.BombSettings m_Settings;

        public event Action<Vector2> OnExploded;

        [Inject]
        void Construct(BonusSettings settings)
        {
            m_Settings = settings.Bomb;
        }

        private void Awake()
        {
            StartCoroutine(Timer());
        }

        IEnumerator Timer()
        {
            var time = m_Settings.timeToExplosion;

            while (time > 0)
            {
                m_TimerText.text = time.ToString();
                time--;
                yield return new WaitForSeconds(1f);

            }

            Debug.Log("Boom!");


            Explode();

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.collider.TryGetComponent<Player>(out var player))
            {
               
                Explode();
            }
        }

        private void Explode()
        {
            Physics2D.OverlapCircleAll(transform.position, 2);

            OnExploded?.Invoke(transform.position);

            Destroy(gameObject);
        }



        public class Factory : PlaceholderFactory<Bomb> { }

    }

}
