using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;
using System;

namespace TestProject
{

    
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bomb : MonoBehaviour, IBulletVisitor, IRoketVisitor, IExplosionEvent
    {
        private BonusSettings.BombSettings m_Settings;
        private LifetimeHandler m_LifetimeHandler;
        public event Action<Vector2> OnExploded;

        [Inject]
        void Construct(BonusSettings settings, LifetimeHandler lfHandler)
        {
            m_Settings = settings.Bomb;
            m_LifetimeHandler = lfHandler;
            m_LifetimeHandler.lifeTime = m_Settings.timeToExplosion;

        }

        private void Awake()
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.mass = m_Settings.bombMass;
            transform.localScale = new Vector3(m_Settings.bombSize, m_Settings.bombSize, m_Settings.bombSize);
        }

        void OnEnable()
        {
            m_LifetimeHandler.Died += Explode;
        }

        void OnDisable()
        {
            m_LifetimeHandler.Died -= Explode;
        }
       

        private void OnCollisionEnter2D(Collision2D collision)
        {
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
                if (colliders[i].TryGetComponent<IBombVisitor>(out var explVisitor))
                {
                    explVisitor.Visit(this);
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


        public void Visit(Bullet bullet, Collision2D Collision2D)
        {
            bullet.MetalCollision();
        }

        public void Visit(RoketBullet roket, Collision2D col)
        {
            roket.Explode();
        }

        public class Factory : PlaceholderFactory<Bomb> { }

    }

}
