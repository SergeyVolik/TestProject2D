using UnityEngine;

namespace TestProject
{
    public abstract class Projectile2D : MonoBehaviour
    {
        protected Rigidbody2D m_Rg;
        protected SpriteRenderer m_SpriteRenderer;

        protected virtual void Awake()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_Rg = GetComponent<Rigidbody2D>();
        }

        protected abstract void OnTriggerEnter2D(Collider2D collision);
        protected abstract void OnCollisionEnter2D(Collision2D collision);
    }
}
