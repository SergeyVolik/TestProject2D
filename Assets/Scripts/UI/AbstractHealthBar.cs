using UnityEngine;
using Zenject;

namespace TestProject
{

    public abstract class AbstractHealthBar : MonoBehaviour
    {
        protected HealthHandler m_Health;

        [Inject]
        void Construct(HealthHandler health)
        {
            m_Health = health;       
        }

        private void OnEnable()
        {
            m_Health.OnUpdated += UpdateHealthBar;
        }

        private void OnDisable()
        {
            m_Health.OnUpdated -= UpdateHealthBar;
        }

        protected abstract void UpdateHealthBar();

    }
}
