using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestProject
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField]
        private Button m_LoadScene1Button;
        [SerializeField]
        private Button m_LoadScene2Button;

        private void OnEnable()
        {
            m_LoadScene1Button.onClick.AddListener(LoadScene1);
            m_LoadScene2Button.onClick.AddListener(LoadScene2);
        }

        private void OnDisable()
        {
            m_LoadScene1Button.onClick.RemoveListener(LoadScene1);
            m_LoadScene2Button.onClick.RemoveListener(LoadScene2);
        }

        void LoadScene1()
        {
            SceneManager.LoadScene(1);
        }

        void LoadScene2()
        {
            SceneManager.LoadScene(2);
        }
    }

}
