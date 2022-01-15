using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class WinDetector :  IInitializable, IDisposable
    {
        [Inject(Id = Players.Player1)]
        HealthHandler m_Player1;
        [Inject(Id = Players.Player2)]
        HealthHandler m_Player2;

        public event Action OnLeftPlayerWinner;
        public event Action OnRightPlayerWinner;

        public void Dispose()
        {
            if(m_Player1 != null)
                m_Player1.OnDamageTaken -= OnDamageTaken;
            if (m_Player2 != null)
                m_Player2.OnDamageTaken -= OnDamageTaken;
        }
            public void Initialize()
        {
            m_Player1.OnDamageTaken += OnDamageTaken;
            m_Player2.OnDamageTaken += OnDamageTaken;
        }

        private void OnDamageTaken(int arg1, Collision2D arg2, bool arg3)
        {
            if (m_Player1.Health <= 0)
            {
                OnLeftPlayerWinner?.Invoke();
            }

            if (m_Player2.Health <= 0)
            {
                OnRightPlayerWinner?.Invoke();
            }
        }


    }

}
