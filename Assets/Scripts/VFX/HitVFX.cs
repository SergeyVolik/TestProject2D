using UnityEngine;
using Zenject;

namespace TestProject
{
    public class HitVFX : MonoBehaviour
    {
        VFXManager m_VFXManager;
        HealthHandler m_Bullet;
        [Inject]
        void Construct(VFXManager vFXManager, HealthHandler bullet)
        {
            m_VFXManager = vFXManager;
            m_Bullet = bullet;
        }

        private void OnEnable()
        {
            m_Bullet.OnDamageTaken += OnDamageTaken;
        }

        private void OnDisable()
        {
            m_Bullet.OnDamageTaken -= OnDamageTaken;
        }

        void OnDamageTaken(int damge, Collision2D col, bool fromLeft)
        {

            if(col != null)
                m_VFXManager.PlayBloodEffect(fromLeft, col.collider.transform, col.contacts[0].point);
        }
    }

}
