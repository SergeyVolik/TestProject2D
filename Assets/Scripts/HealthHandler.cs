using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class HealthHandler : MonoBehaviour
    {
        private int m_Health = 5;
        PlayerSettings m_Settings;

        public int Health => m_Health;
        public event Action OnDamageTaken;       

        [Inject]
        void Construct(PlayerSettings settings)
        {
            m_Settings = settings;
            m_Health = m_Settings.MaxHealth;
        }


        public void TakeDamage(int damage)
        {
            m_Health -= damage;
            OnDamageTaken.Invoke();
        }
    }
}
