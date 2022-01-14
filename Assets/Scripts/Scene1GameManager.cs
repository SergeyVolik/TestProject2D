using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class Scene1GameManager : ITickable
    {
        [Inject]
        TapManager m_TapManager;

        [Inject(Id = Players.Player1)]
        private Player m_LeftPlayer;

        [Inject(Id = Players.Player2)]
        private Player m_RightPlayer;

        public void Tick()
        {
            if (m_TapManager.LeftScreenTap)
            {
                m_LeftPlayer.Jump();
            }
            if (m_TapManager.RightScreenTap)
            {
                m_RightPlayer.Jump();
            }
        }


    }

}
