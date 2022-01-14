using UnityEngine;
using Zenject;

namespace TestProject
{
    public abstract class BodyPart : MonoBehaviour
    {
        HealthHandler m_Health;
        public void TakeDamge(int damage, Collision2D collsion, bool FromLeftSide)
        {
            m_Health.TakeDamge(damage, collsion, FromLeftSide);
        }

        [Inject]
        void Construct(HealthHandler health)
        {
            m_Health = health;
    
        }
    }
}
