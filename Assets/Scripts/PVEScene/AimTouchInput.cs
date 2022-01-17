using System;
using UnityEngine;
using Zenject;

namespace TestProject.PVE
{
    public class AimTouchInput : ITickable
    {
        private bool startCalc;
        private Vector3 startPos;
        private Vector3 endPos;

        public event Action<Vector2> OnAimStarted;
        public event Action OnAimEnded;
     

        private Vector3 m_AimVector;
        [SerializeField]
        float m_Strength = 10;

        public Vector3 AimVector => m_AimVector;
        public Vector3 StartPos => startPos;
        public Vector3 EndPos => endPos;
        public void Tick()
        {

#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                startCalc = true;
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
                OnAimStarted?.Invoke(startPos);
            }

            if (Input.GetMouseButtonUp(0))
            {
                startCalc = false;
                OnAimEnded?.Invoke();
            }




#elif UNITY_ANDROID || UNITY_IOS
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startCalc = true;
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
                OnAimStarted?.Invoke(startPos);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                startCalc = false;
                OnAimEnded?.Invoke();
            }
#endif

            if (startCalc)
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
                m_AimVector = endPos - startPos;
                //var mag = vector.magnitude;
                //vector = vector.normalized * m_Strength * mag;//Vector3.Distance(startPos, endPos);
            }


        }


    }

}
