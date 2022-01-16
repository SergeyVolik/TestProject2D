using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace TestProject
{


    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class RoketBullet : Projectile2D, IBullet, IBulletVisitor, IExplosionEvent
    {
       

        public event Action<Vector2> OnExploded;

        private BonusSettings.BombSettings m_Settings;

        [Inject]
        void Construct(BonusSettings settings)
        {
            m_Settings = settings.Bomb;
        }

        bool exploed = false;
        protected override void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.TryGetComponent<IRoketVisitor>(out var visitor))
            {
                visitor.Visit(this, collision);
            }

            Explode();

        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {

            if (!collision.CompareTag(Owner.tag))
            {
                Explode();
            }
          
        }

        public void Explode()
        {

            if (!exploed)
            {
                exploed = true;
                var colliders = Physics2D.OverlapCircleAll(transform.position, m_Settings.explosionRadius);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].TryGetComponent<IRoketVisitor>(out var explVisitor))
                    {
                        explVisitor.Visit(this, null);
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

        }


        public void TakeDamge(int damage, Collision2D collision, bool fromLeft)
        {
            if(collision != null && collision.contacts.Length > 0)
                OnExploded?.Invoke(collision.contacts[0].point);
            

            StartCoroutine(WaitAndDestory());
        }

        IEnumerator WaitAndDestory()
        {
            yield return null;
            yield return null;
            if(gameObject != null)
            Destroy(gameObject);
        }

        public void Visit(Bullet bullet, Collision2D Collision2D)
        {
            Explode();
        }

        public class Factory : PlaceholderFactory<RoketBullet>
        {

        }
    }

}
