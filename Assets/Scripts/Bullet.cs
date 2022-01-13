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
        private SoundManager m_SoundsManager;
        private VFXManager m_VFXManager;
        public SpriteRenderer SpriteRenderer => m_SpriteRenderer;
        public Rigidbody2D Rigidbody2D => m_Rg;
        [Inject]
        void Construct(
            ShootingSettigs settings,
            SoundManager soundsManager,
            VFXManager vfxManager
            )
        {
            m_ShootingSettigs = settings;
            m_SoundsManager = soundsManager;
            m_VFXManager = vfxManager;
        }

        private void Awake()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_Rg = GetComponent<Rigidbody2D>();
        }



        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("OnCollisionEnter bullet");
            var IDamageable = collision.gameObject.GetComponent<IDamageable>();

            switch (IDamageable)
            {
                case IHead head:

                    head.TakeDamge(m_ShootingSettigs.HeadDamage);

                    CreateBloodEffect(collision);
                    break;
                case ILeg leg:

                    leg.TakeDamge(m_ShootingSettigs.LegDamage);
                    CreateBloodEffect(collision);
                    break;
                case IChess chess:
                    chess.TakeDamge(m_ShootingSettigs.ChessDamage);
                    CreateBloodEffect(collision);
                    break;
                case IBullet chess:

                    m_VFXManager.PlayBulletCollision(collision.contacts[0].point);

                    chess.TakeDamge(9999);
                  
                    break;

            }

            Destroy(gameObject);

        }

        void CreateBloodEffect(Collision2D collision)
        {
            float YRot = SpriteRenderer.flipX ? 90 : -90;
            m_VFXManager.PlayBloodEffect(YRot, collision.collider.transform, collision.contacts[0].point);

        }

        public void TakeDamge(int damage)
        {
            m_SoundsManager.PlayBulletCollistion();
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<Bullet>
        {

        }
    }

}
