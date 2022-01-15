using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public interface IBullet : IDamageable
    { 

    }

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Bullet : MonoBehaviour, IBullet
    {
        private Rigidbody2D m_Rg;
        private SpriteRenderer m_SpriteRenderer;
        private ShootingSettigs m_ShootingSettigs;
        public Player Owner;

        public SpriteRenderer SpriteRenderer => m_SpriteRenderer;
        public Rigidbody2D Rigidbody2D => m_Rg;

        public event Action<Vector2> OnBulletCollision;
        public bool IsExplodable;

        [Inject]
        void Construct(
            ShootingSettigs settings
            )
        {
            m_ShootingSettigs = settings;
        }

        private void Awake()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_Rg = GetComponent<Rigidbody2D>();
        }



        private void OnCollisionEnter2D(Collision2D collision)
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


                    bullet.TakeDamge(9999, collision, fromLeft);

                    break;

                default:
                    if (IDamageable != null)
                        IDamageable.TakeDamge(1, collision, fromLeft);
                    break;

            }

            Destroy(gameObject);

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (!collision.CompareTag(Owner.tag))
            {
                TakeDamageInternal();
            }

          
        }

        private void TakeDamageInternal()
        {

                OnBulletCollision?.Invoke(transform.position);


            StartCoroutine(WainAndDestory());
        }


        public void TakeDamge(int damage, Collision2D collision, bool fromLeft)
        {
            if(collision.contacts.Length > 0)
                OnBulletCollision?.Invoke(collision.contacts[0].point);
            

            StartCoroutine(WainAndDestory());
        }

        IEnumerator WainAndDestory()
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
