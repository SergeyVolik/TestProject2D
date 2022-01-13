using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class HealthBar : MonoBehaviour
    {
        HealthHandler m_Health;

        [SerializeField]
        private List<GameObject> m_Hearts;

        [Inject]
        void Construct(HealthHandler health)
        {
            m_Health = health;
            UpdateHealthBar();
        }

        private void OnEnable()
        {
            m_Health.OnDamageTaken += UpdateHealthBar;
        }

        private void OnDisable()
        {
            m_Health.OnDamageTaken -= UpdateHealthBar;
        }

        void UpdateHealthBar()
        {
            var health = m_Health.Health;

            for (int i = 0; i < m_Hearts.Count; i++)
            {

                if (i >= health)
                    m_Hearts[i].SetActive(false);
                else m_Hearts[i].SetActive(true);
            }
        }

    }

}
