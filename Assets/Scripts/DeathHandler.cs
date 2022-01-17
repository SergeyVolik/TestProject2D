using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{

    public class DeathHandler : MonoBehaviour
    {
        private HealthHandler m_Health;

        public event Action OnDeath;
        private bool IsDead;

        [Inject]
        void Construct(HealthHandler health)
        {
            m_Health = health;
        }

        private void OnEnable()
        {
            m_Health.OnDamageTaken += M_Health_OnDamageTaken;
        }

        private void M_Health_OnDamageTaken(int arg1, Collision2D arg2, bool arg3)
        {
            if (m_Health.Health <= 0 && !IsDead)
            {
                OnDeath?.Invoke();
                IsDead = true;
            }
        }

        private void OnDisable()
        {
            m_Health.OnDamageTaken -= M_Health_OnDamageTaken;
        }

      


    }

}