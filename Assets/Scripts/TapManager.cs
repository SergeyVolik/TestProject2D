using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace TestProject
{
    [DefaultExecutionOrder(-1)]
    public class TapManager : MonoBehaviour
    {
        private bool m_LeftScreenTap;
        private bool m_RightScreenTap;

        public bool LeftScreenTap => m_LeftScreenTap;
        public bool RightScreenTap => m_RightScreenTap;

        private UiManager m_UI;
        [Inject]
        void Construct(UiManager ui)
        {
            m_UI = ui;
        }

        public void Update()
        {
            m_LeftScreenTap = false;
            m_RightScreenTap = false;

            
#if UNITY_EDITOR
            
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Tap");
                var result = TouchOnTheLeftSide(Input.mousePosition);
                if (result && !m_UI.LeftButtonClicked)
                {
                    m_LeftScreenTap = true;
                    return;
                }
                else if(!result && !m_UI.RightButtonClicked)
                    m_RightScreenTap = true;
            }


#elif UNITY_ANDROID || UNITY_IOS
            for (int i = 0; i < Input.touches.Length; i++)
            {
                var touchPhaseBegan = Input.touches[i].phase == TouchPhase.Ended;
                if (touchPhaseBegan)
                {
                     var result = TouchOnTheLeftSide(Input.touches[i].position);

                    if (result && !m_UI.LeftButtonClicked)
                    {
                        m_LeftScreenTap = true;
                    }
                    else if(!result && !m_UI.RightButtonClicked)
                        m_RightScreenTap = true;
                }

            }
            
#endif
        }



        bool TouchOnTheLeftSide(Vector2 pos)
        {
           

            if (pos.x < Screen.width / 2)
            {
                return true;
            }

            return false;
        }

    }

}
