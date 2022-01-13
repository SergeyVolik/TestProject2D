using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Bullet : MonoBehaviour
    {
        Rigidbody2D m_Rg;
        public Rigidbody2D Rigidbody2D => m_Rg;

        BloodEffect.Factory m_BloodFactory;


        SpriteRenderer m_SpriteRenderer;

        public SpriteRenderer SpriteRenderer => m_SpriteRenderer;


        [Inject]
        void Construct(BloodEffect.Factory factory)
        {
            m_BloodFactory = factory;


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

                    head.TakeDamge(3);

                    CreateEffect(collision);
                    break;
                case ILeg leg:

                    leg.TakeDamge(1);
                    CreateEffect(collision);
                    break;
                case IChess chess:
                    chess.TakeDamge(2);
                    CreateEffect(collision);
                    break;

            }

            Destroy(gameObject);

        }

        void CreateEffect(Collision2D collision)
        {
            var effect = m_BloodFactory.Create();
            effect.transform.SetParent(collision.collider.transform);
            effect.transform.position = collision.contacts[0].point;

            float YRot = SpriteRenderer.flipX ? 90 : -90;
            Debug.Log(m_Rg.velocity);
            effect.transform.rotation = Quaternion.Euler(effect.transform.eulerAngles.x, YRot, effect.transform.eulerAngles.z);
            effect.Play();
        }

        public class Factory : PlaceholderFactory<Bullet>
        {

        }
    }

}
