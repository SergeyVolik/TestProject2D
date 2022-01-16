using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BodyShield : MonoBehaviour, IDamageable, IBulletVisitor, IRoketVisitor
    {
        protected SpriteRenderer m_SR;
        protected BonusSettings.ShieldSettings m_ShieldSettins;

        protected float duration;
        [Inject]
        void Construct(BonusSettings settings)
        {
            m_ShieldSettins = settings.Shield;
            duration = m_ShieldSettins.duration;
        }

        protected virtual void Start()
        {
            m_SR = GetComponent<SpriteRenderer>();
            m_SR.color = m_ShieldSettins.color;
            m_SR.transform.localScale = new Vector3(m_ShieldSettins.size, m_ShieldSettins.size, m_ShieldSettins.size);

            gameObject.SetActive(false);
        }

        public void TakeDamge(int damage, Collision2D collision, bool fromLeft)
        {
            Debug.Log("ShieldBlock");
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            StartCoroutine(WaitTime());
        }
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(duration);
            Deactivate();
        }

        public void Visit(Bullet bullet, Collision2D Collision2D)
        {
            bullet.MetalCollision();
        }

        public void Visit(RoketBullet roket, Collision2D col)
        {
            roket.Explode();
        }
    }

}
