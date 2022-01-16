using UnityEngine;

namespace TestProject.PVE
{
    public class Trajectoryinput : MonoBehaviour
    {
        [SerializeField]
        TrajectoryRenderer m_Renderer;


        bool startCalc;

        Vector3 startPos;
        Vector3 endPos;

        [SerializeField]
        float m_Strength = 10;
        void Update()
        {

#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                startCalc = true;
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;

                print($"startPos: {startPos}");
            }

            if (Input.GetMouseButtonUp(0))
            {
                startCalc = false;
            }




#elif UNITY_ANDROID || UNITY_IOS
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startCalc = true;
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;

                print($"startPos: {startPos}");
            }

            if (touch.phase == TouchPhase.Ended)
            {
                startCalc = false;
            }
#endif

            if (startCalc)
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
                var vector = endPos - startPos;
                var mag = vector.magnitude;
                vector = vector.normalized * m_Strength * mag;//Vector3.Distance(startPos, endPos);
                m_Renderer.ShowTrajectory(startPos, vector);
            }


        }
    }

}
