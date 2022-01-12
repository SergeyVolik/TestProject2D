using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class GameManager : MonoBehaviour
    {

        TapManager m_TapManager;

        [SerializeField]
        private Player m_LeftPlayer;

        [Inject]
        void Construct(TapManager tap)
        {
            m_TapManager = tap;
        }
    

        // Update is called once per frame
        void Update()
        {
            if (m_TapManager.LeftScreenTap)
            {
                m_LeftPlayer.Jump();
                print("LeftScreenTap");   
            }
            if (m_TapManager.RightScreenTap)
            {
                print("RightScreenTap");
            }
        }
    }

}
