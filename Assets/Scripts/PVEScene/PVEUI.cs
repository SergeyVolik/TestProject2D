using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestProject.PVE
{
    public class PVEUI : MonoBehaviour
    {

        [SerializeField]
        private TMPro.TMP_Text m_text;
        [SerializeField]
        private Button m_ActivateShieldButton;
        int points = 0;

        private SignalBus m_signalBus;
        [Inject]
        void Construct(SignalBus signalBus)
        {          
            m_signalBus = signalBus;
        }

        private void Start()
        {
            m_text.text = "0";
        }
        private void OnEnable()
        {

            m_signalBus.Subscribe<EnemyKillSignal>(EnemyKilled);

            m_ActivateShieldButton.onClick.AddListener(ActivateShield);
        }

        void ActivateShield()
        {
            m_signalBus.Fire(new ActivateShieldSignal());
            m_signalBus.Fire(new UIActivatedSignal());
        }
        private void EnemyKilled()
        {
            points++;
            m_text.text = points.ToString();
        }

        private void OnDisable()
        {
            m_signalBus.Unsubscribe<EnemyKillSignal>(EnemyKilled);
            m_ActivateShieldButton.onClick.RemoveListener(ActivateShield);
        }
    }

}
