using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject.PVE
{
    public class TrajectoryRenderer : MonoBehaviour
    {
        private LineRenderer m_LineRenderer;
        private AimTouchInput m_Input;
        bool m_StartDraw;

        [Inject]
        void Construct(AimTouchInput input)
        {
            m_Input = input;
        }


        private void OnEnable()
        {
            m_Input.OnAimStarted += M_Input_OnAimStarted;
            m_Input.OnAimEnded += M_Input_OnAimEnded;
        }

        private void OnDisable()
        {
            m_Input.OnAimStarted -= M_Input_OnAimStarted;
            m_Input.OnAimEnded -= M_Input_OnAimEnded;
        }

        private void M_Input_OnAimEnded()
        {
            m_StartDraw = false;
            Hide();
        }

        private void M_Input_OnAimStarted(Vector2 obj)
        {
            m_StartDraw = true;
        }
        // Start is called before the first frame update
        private void Start()
        {
            m_LineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            if (m_StartDraw)
            {
                DrawLine(m_Input.StartPos, m_Input.EndPos);
            }
        }

        //public void ShowTrajectory(Vector3 origin, Vector3 speed)
        //{
        //    Vector3[] points = new Vector3[100];

        //    for (int i = 0; i < points.Length; i++)
        //    {
        //        float time = i * 0.1f;

        //        points[i] = origin + speed * time + Physics.gravity * time * time / 2f;

        //        if (points[i].y > 0)
        //        {
        //            m_LineRenderer.positionCount = i + 1;
        //        }
        //    }

        //    m_LineRenderer.SetPositions(points);
        //}

        public void DrawLine(Vector2 pos1, Vector2 pos2)
        {
            m_LineRenderer.positionCount = 2;
            m_LineRenderer.SetPosition(0, pos1);
            m_LineRenderer.SetPosition(1, pos2);
        }

        private void Hide()
        {
            m_LineRenderer.positionCount = 0;
        }



    }

}

