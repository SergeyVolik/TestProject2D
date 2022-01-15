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
        LifetimeHandler m_slfHandler;
        [Inject]
        void Construct(HealthHandler health, BonusSettings settings, LifetimeHandler lfHandler)
        {
            m_Health = health;
            m_Health.Health = settings.AidKit.MaxHealth;
            m_Health.MaxHealth = settings.AidKit.MaxHealth;
            m_Settings = settings.AidKit;
            m_slfHandler = lfHandler;
            lfHandler.lifeTime = m_Settings.lifetime;
        }


        private void OnEnable()
        {
            m_Health.OnDamageTaken += TakeDamge;
            m_slfHandler.Died += M_slfHandler_Died;
        }

        private void M_slfHandler_Died()
        {
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            m_slfHandler.Died -= M_slfHandler_Died;
            m_Health.OnDamageTaken -= TakeDamge;
        }

        public void TakeDamge(int damage, Collision2D collision, bool fromLeft)
        {
            if (m_Health.Health <= 0)
            {
                if (collision != null && collision.otherCollider.TryGetComponent<Bullet>(out var bullet))
                {
                    Debug.Log("Heal");
                    bullet.Owner.Heal(m_Settings.HealthStrength);
                }
                Destroy(gameObject);
            }

        }

        public class Factory : PlaceholderFactory<FirstAidKit> { }

    }

}
