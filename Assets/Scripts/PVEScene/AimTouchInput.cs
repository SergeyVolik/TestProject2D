using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace TestProject.PVE
{
    public class AimTouchInput : MonoBehaviour
    {
        private bool startCalc;
        private Vector3 startPos;
        private Vector3 endPos;

        public event Action<Vector2> OnAimStarted;
        public event Action OnAimEnded;

        SignalBus m_bus;

        [Inject]
        public void Construct(SignalBus bus)
        {
            m_bus = bus;
        }

        private Vector3 m_AimVector;

        public Vector3 AimVector => m_AimVector;
        public Vector3 StartPos => startPos;
        public Vector3 EndPos => endPos;

        public void OnEnable()
        {
            m_bus.Subscribe<UIActivatedSignal>(UiActivated);
        }

        public void OnDisable()
        {
            m_bus.Unsubscribe<UIActivatedSignal>(UiActivated);
        }

        bool activated = false;
        void UiActivated()
        {
            Debug.Log("UiActivated");
            activated = true;
        }
        public void LateUpdate()
        {

#if UNITY_EDITOR


            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Start aim");
                startCalc = true;
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
                OnAimStarted?.Invoke(startPos);
            }

            if (Input.GetMouseButtonUp(0) && startCalc)
            {
                Debug.Log("end aim");
                startCalc = false;
                OnAimEnded?.Invoke();
            }



#elif UNITY_ANDROID || UNITY_IOS

            bool uitouched = false;
            foreach (Touch touch1 in Input.touches)
            {
                int id = touch1.fingerId;
                if (EventSystem.current.IsPointerOverGameObject(id))
                {
                    uitouched = true;
                }
            }
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && !uitouched)
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
