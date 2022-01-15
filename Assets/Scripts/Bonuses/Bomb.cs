using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;
using System;

namespace TestProject
{
    [RequireComponent(typeof(Rigidbody2D))]
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
            var rb = GetComponent<Rigidbody2D>();
            rb.mass = m_Settings.bombMass;
            transform.localScale = new Vector3(m_Settings.bombSize, m_Settings.bombSize, m_Settings.bombSize);
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
            Debug.Log(collision.collider.gameObject.name);
            if (collision.collider.TryGetComponent<Player>(out _))
            {
               
                Explode();
            }
        }

        private void Explode()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, m_Settings.explosionRadius);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].TryGetComponent<IDamageable>(out var damageable))
                {
                    damageable?.TakeDamge(m_Settings.explosionDamage, null, false);
                }
            }

            colliders = Physics2D.OverlapCircleAll(transform.position, m_Settings.explosionRadius);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].TryGetComponent<Rigidbody2D>(out var rb))
                {               
                    var vector = (rb.transform.position - transform.position).normalized;
                    rb.AddForce(vector * m_Settings.explosionForce);
                }
            }

            OnExploded?.Invoke(transform.position);

            Destroy(gameObject);
        }



        public class Factory : PlaceholderFactory<Bomb> { }

    }

}
