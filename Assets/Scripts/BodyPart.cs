using UnityEngine;
using Zenject;

namespace TestProject
{
    public abstract class BodyPart : MonoBehaviour
    {
        HealthHandler m_Health;
        public void TakeDamge(int damage)
        {
            m_Health.TakeDamage(damage);
        }

        [Inject]
        void Construct(HealthHandler health)
        {
            m_Health = health;
    
        }
    }
}
