using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;

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
        private Button m_RestartButton;
        [SerializeField]
        private Button m_MainMenuButton;
        
        [SerializeField]
        CanvasGroup m_EndGameUI;

        [Inject(Id = Players.Player1)]
        Player m_Player1;
        [Inject(Id = Players.Player2)]
        Player m_Player2;


        public bool LeftButtonClicked = false;
        public bool RightButtonClicked = false;

        WinDetector m_WinDetector;
        GameEndSettings m_Settings;
        [Inject]
        void Construct(WinDetector winDetector, GameEndSettings settings)
        {
            m_WinDetector = winDetector;
            m_Settings = settings;
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
            ShowEndGameUI();
            m_Text.text = m_Settings.RightPlayerWinnerText;
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
            ShowEndGameUI();
          
            m_Text.text = m_Settings.LeftPlayerWinnerText;
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


        public void ShowEndGameUI()
        {
            m_EndGameUI.DOFade(1, m_Settings.FadeUITime).SetDelay(m_Settings.ShowUIDelay).OnComplete(() => {
                m_EndGameUI.interactable = true;
            });
           
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
