using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class FirstAidKit : MonoBehaviour
    {
        HealthHandler m_Health;
        BonusSettings.FirstAidKitSettings m_Settings;
        [Inject]
        void Construct(HealthHandler health, BonusSettings settings)
        {
            m_Health = health;
            m_Health.Health = settings.AidKit.MaxHealth;
            m_Health.MaxHealth = settings.AidKit.MaxHealth;
            m_Settings = settings.AidKit;
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
            if (m_Health.Health <= 0)
            {
                if (collision.otherCollider.TryGetComponent<Bullet>(out var bullet))
                {
                    Debug.Log("Heal");
                    bullet.Owner.Heal(m_Settings.HealthStrength);
                }
                Destroy(gameObject);
            }

        }

    }

}
