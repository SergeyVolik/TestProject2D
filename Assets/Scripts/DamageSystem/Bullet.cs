using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace TestProject
{


    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Bullet : Projectile2D, IBullet, IBulletCollision
    {
        private const int MaxDamage = 9999;
        private ShootingSettigs m_ShootingSettigs;
        public Player Owner;

        public SpriteRenderer SpriteRenderer => m_SpriteRenderer;
        public Rigidbody2D Rigidbody2D => m_Rg;

        public event Action<Vector2> OnCollision;

        public bool IsExplodable;

        [Inject]
        void Construct(ShootingSettigs settings)
        {
            m_ShootingSettigs = settings;
        }



        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            var IDamageable = collision.gameObject.GetComponent<IDamageable>();

            bool fromLeft = SpriteRenderer.flipX ? true : false;

            switch (IDamageable)
            {
                case IHead head:

                    head.TakeDamge(m_ShootingSettigs.HeadDamage, collision, fromLeft);
                    break;
                case ILeg leg:

                    leg.TakeDamge(m_ShootingSettigs.LegDamage, collision, fromLeft);

                    break;
                case IChest chess:
                    chess.TakeDamge(m_ShootingSettigs.ChessDamage, collision, fromLeft);
                    break;
                case IBullet bullet:
                    bullet.TakeDamge(MaxDamage, collision, fromLeft);
                    break;
                case Bomb bomb:
                    TakeDamageInternal();
                    break;

                default:
                    if (IDamageable != null)
                        IDamageable.TakeDamge(1, collision, fromLeft);
                    break;

            }

            Destroy(gameObject);

        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {

            if (!collision.CompareTag(Owner.tag))
            {
                TakeDamageInternal();
            }

          
        }

        private void TakeDamageInternal()
        {

            OnCollision?.Invoke(transform.position);


            StartCoroutine(WaitAndDestory());
        }


        public void TakeDamge(int damage, Collision2D collision, bool fromLeft)
        {
            if(collision != null && collision.contacts.Length > 0)
                OnCollision?.Invoke(collision.contacts[0].point);
            

            StartCoroutine(WaitAndDestory());
        }

        IEnumerator WaitAndDestory()
        {
            yield return null;
            yield return null;
            if(gameObject != null)
            Destroy(gameObject);
        }
        public class Factory : PlaceholderFactory<Bullet>
        {

        }
    }

}
