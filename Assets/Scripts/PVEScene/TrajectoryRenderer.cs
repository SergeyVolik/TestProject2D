using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.PVE
{
    public class TrajectoryRenderer : MonoBehaviour
    {
        private LineRenderer m_LineRenderer;

        // Start is called before the first frame update
        private void Start()
        {
            m_LineRenderer = GetComponent<LineRenderer>();
        }

        public void ShowTrajectory(Vector3 origin, Vector3 speed)
        {
            Vector3[] points = new Vector3[100];

            for (int i = 0; i < points.Length; i++)
            {
                float time = i * 0.1f;

                points[i] = origin + speed * time + Physics.gravity * time * time / 2f;

                if (points[i].y > 0)
                {
                    m_LineRenderer.positionCount = i + 1;
                }
            }

            m_LineRenderer.SetPositions(points);
        }
    }

}

