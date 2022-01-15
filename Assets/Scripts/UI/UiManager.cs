using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        [SerializeField]
        private TMPro.TMP_Text m_Text;
        [SerializeField]
        private RectTransform Panel;
        public bool LeftButtonClicked = false;
        public bool RightButtonClicked = false;

        [SerializeField]
        private Button m_RestartButton;
        [SerializeField]
        private Button m_MainMenuButton;

        [Inject(Id = Players.Player1)]
        Player m_Player1;
        [Inject(Id = Players.Player2)]
        Player m_Player2;

      
        WinDetector m_WinDetector;

        [Inject]
        void Construct(WinDetector winDetector)
        {
            m_WinDetector = winDetector;
        }

        private void OnEnable()
        {
            m_WinDetector.OnLeftPlayerWinner += LeftPlayerWinner;
            m_WinDetector.OnRightPlayerWinner += RightPlayerWinner;

            m_ShotLeftButton.onClick.AddListener(Player1Shot);
            m_ShotRightButton.onClick.AddListener(Player2Shot);

            m_RestartButton.onClick.AddListener(RestartScene);
            m_MainMenuButton.onClick.AddListener(LoadMainMenuScene);
        }

        private void RightPlayerWinner()
        {
            Panel.gameObject.SetActive(true);
            m_Text.text = "Right player is the winner!";
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(1);
        }
        private void LoadMainMenuScene()
        {
            SceneManager.LoadScene(0);
        }
        private void LeftPlayerWinner()
        {
            Panel.gameObject.SetActive(true);
            m_Text.text = "Left player is the winner!";
        }

        private void OnDisable()
        {
            m_ShotLeftButton.onClick.RemoveListener(Player1Shot);
            m_ShotRightButton.onClick.RemoveListener(Player2Shot);

            m_WinDetector.OnLeftPlayerWinner -= LeftPlayerWinner;
            m_WinDetector.OnRightPlayerWinner -= RightPlayerWinner;

            m_RestartButton.onClick.RemoveListener(RestartScene);
            m_MainMenuButton.onClick.RemoveListener(LoadMainMenuScene);
        }



        private void LateUpdate()
        {
            LeftButtonClicked = false;
            RightButtonClicked = false;
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
