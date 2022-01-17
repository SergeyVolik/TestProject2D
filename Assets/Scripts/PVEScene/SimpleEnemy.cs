using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject.PVE
{
    public class SimpleEnemy : MonoBehaviour
    {
        DeathHandler m_Death;
        RagdollModel m_rdModel;
        Animator m_anim;
        public DeathHandler Death => m_Death;
        [Inject]
        void Construct(DeathHandler death, HealthHandler health, RagdollModel rdModel, Animator anim)
        {
            m_Death = death;
            m_rdModel = rdModel;
            m_anim = anim;
            health.MaxHealth = 5;
            health.Health = 5;
            health.OneHitAtFrame = true;
        }

        private void OnEnable()
        {
            m_Death.OnDeath += M_Death_OnDeath;
        }

        private void M_Death_OnDeath()
        {
            Debug.Log("Death");
            m_anim.enabled = false;
            m_rdModel.Activate();
        }

        private void OnDisable()
        {
            m_Death.OnDeath -= M_Death_OnDeath;
        }

        public class Factory : PlaceholderFactory<SimpleEnemy> { }
    }

}
