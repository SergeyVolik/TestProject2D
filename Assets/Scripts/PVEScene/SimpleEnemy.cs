using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;

namespace TestProject.PVE
{
    public class SimpleEnemy : MonoBehaviour
    {
        DeathHandler m_Death;
        RagdollModel m_rdModel;
        Animator m_anim;
        public DeathHandler Death => m_Death;

        [SerializeField]
        Transform Shield;
        float shieldSize;
        bool shieldActivated = false;
        SignalBus m_SignalBus;
       [Inject]
        void Construct(
           DeathHandler death,
           HealthHandler health,
           RagdollModel rdModel,
           Animator anim,
           SignalBus sBus)
        {
            m_Death = death;
            m_rdModel = rdModel;
            m_anim = anim;
            health.MaxHealth = 5;
            health.Health = 5;
            health.OneHitAtFrame = true;
            m_SignalBus = sBus;
        }

        private void Start()
        {
            shieldSize = Shield.transform.localScale.x;
            Shield.transform.localScale = Vector3.zero;
        }
        private void OnEnable()
        {
            m_Death.OnDeath += M_Death_OnDeath;
            m_SignalBus.Subscribe<ActivateShieldSignal>(M_ui_ActivateShieldInput);
        }
        private void OnDisable()
        {
            m_Death.OnDeath -= M_Death_OnDeath;
            m_SignalBus.Unsubscribe<ActivateShieldSignal>(M_ui_ActivateShieldInput);
        }
        private void M_ui_ActivateShieldInput()
        {
            if (!shieldActivated)
            {
                shieldActivated = true;
                Sequence mySequence = DOTween.Sequence();
                mySequence.Append(Shield.transform.DOScale(shieldSize, 1))              
                  .Append(Shield.transform.DOScale(0, 1).SetDelay(4f));

                mySequence.OnComplete(() => {
                    shieldActivated = false;
                });
            }
        }

        private void M_Death_OnDeath()
        {
            Debug.Log("Death");
            m_anim.enabled = false;
            m_rdModel.Activate();
        }

       

        public class Factory : PlaceholderFactory<SimpleEnemy> { }
    }

}
