using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestProject
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField]
        private Button m_ShotLeftButton;
        [SerializeField]
        private Button m_ShotRightButton;

        public bool LeftButtonClicked = false;
        public bool RightButtonClicked = false;


        [Inject(Id = Players.Player1)]
        Player m_Player1;
        [Inject(Id = Players.Player2)]
        Player m_Player2;

        // Start is called before the first frame update
        void Start()
        {
            m_ShotLeftButton.onClick.AddListener(Player1Shot);
            m_ShotRightButton.onClick.AddListener(Player2Shot);
        }


        void Player1Shot()
        {
            LeftButtonClicked = true;
            Debug.Log("Player1Shot button");
            m_Player1.Shot();
        }

        void Player2Shot()
        {
            RightButtonClicked = true;
            Debug.Log("Player2Shot button");
            m_Player2.Shot();
        }


    }

}
