using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace TestProject
{
    public class TapManager : MonoBehaviour
    {
        private bool m_LeftScreenTap;
        private bool m_RightScreenTap;

        public bool LeftScreenTap => m_LeftScreenTap;
        public bool RightScreenTap => m_RightScreenTap;

        public void LateUpdate()
        {
            m_LeftScreenTap = false;
            m_RightScreenTap = false;

            if (Input.GetMouseButtonUp(0) && EventSystem.current.currentSelectedGameObject == null)
            {
                if (CheckLeftBound())
                {
                    m_LeftScreenTap = true;
                    return;
                }

                m_RightScreenTap = true;
            }
        }


        bool CheckLeftBound()
        {
            var pos = Input.mousePosition;

            if (pos.x < Screen.width / 2)
            {
                return true;
            }

            return false;
        }

    }

}
