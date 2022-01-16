using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class DebugManager : ITickable
    {

        BonusSpawner m_Spawner;

        [Inject(Id = Players.Player1)]
        private Player m_LeftPlayer;

        [Inject(Id = Players.Player2)]
        private Player m_RightPlayer;

        DebugManager(BonusSpawner spawner)
        {
            m_Spawner = spawner;
        }

        public void Tick()
        {
           

            if (Input.GetKeyDown(KeyCode.F1))
            {
                m_LeftPlayer.Shot();
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                m_LeftPlayer.Jump();
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                m_RightPlayer.Shot();
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                m_RightPlayer.Jump();
            }

            if (Input.GetKeyDown(KeyCode.F5))
            {
                m_Spawner.SpawnBomb();

            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                m_Spawner.SpawnFirstAidKit();

            }

            if (Input.GetKeyDown(KeyCode.F7))
            {
                m_Spawner.SpawnShieldBuster();

            }

            if (Input.GetKeyDown(KeyCode.F8))
            {
                m_Spawner.SpawnRoketBulletsBonus();

            }
            if (Input.GetKeyDown(KeyCode.F9))
            {
                m_Spawner.SpawnHeadShieldBuster();

            }

        }

    }

}
