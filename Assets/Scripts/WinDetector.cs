using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class WinDetector : IInitializable, IDisposable
    {
        [Inject(Id = Players.Player1)]
        DeathHandler m_Player1;
        [Inject(Id = Players.Player2)]
        DeathHandler m_Player2;

        public event Action OnLeftPlayerWinner;
        public event Action OnRightPlayerWinner;

        public void Dispose()
        {
            if (m_Player1 != null)
                m_Player1.OnDeath -= OnDeathPlayer1;
            if (m_Player2 != null)
                m_Player2.OnDeath -= OnDeathPlayer2;
        }
        public void Initialize()
        {
            m_Player1.OnDeath += OnDeathPlayer1;
            m_Player2.OnDeath += OnDeathPlayer2;
        }
        private void OnDeathPlayer1()
        {
            OnRightPlayerWinner?.Invoke();
        }
        private void OnDeathPlayer2()
        {
            OnLeftPlayerWinner?.Invoke();
        }



    }

}
