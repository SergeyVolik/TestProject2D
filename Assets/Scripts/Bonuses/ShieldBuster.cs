using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class ShieldBuster : MonoBehaviour
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
            
            if (collision.otherCollider.TryGetComponent<Bullet>(out var bullet))
            {
                Debug.Log("Heal");
                bullet.Owner.ActivateShield();
            }

            Destroy(gameObject);
            

        }

        public class Factory : PlaceholderFactory<ShieldBuster> { }

    }

}
