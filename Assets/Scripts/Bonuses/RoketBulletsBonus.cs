using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class RoketBulletsBonus : MonoBehaviour, IBulletVisitor
    {
        HealthHandler m_Health;

        [Inject]
        void Construct(HealthHandler health)
        {
            m_Health = health;
            m_Health.Health = 1;
            m_Health.MaxHealth = 1;

        }


        private void OnEnable()
        {
            m_Health.OnDamageTaken += TakeDamge;
        }

        private void OnDisable()
        {
            m_Health.OnDamageTaken -= TakeDamge;
        }

        public void TakeDamge(int damage, Collision2D collision, bool fromLeft)
        {
            
            if (collision != null && collision.otherCollider.TryGetComponent<Projectile2D>(out var bullet))
            {
                bullet.Owner.ActivateRoketBullets();
            }

            Destroy(gameObject);
            

        }

        public void Visit(Bullet bullet, Collision2D Collision2D)
        {
            m_Health.TakeDamge(1, Collision2D, bullet.FromLeft);
        }

        public class Factory : PlaceholderFactory<RoketBulletsBonus> { }

    }

}
