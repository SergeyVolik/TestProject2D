using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject.PVE
{
    public class PlayerAimBody : MonoBehaviour
    {
        AimTouchInput m_AimInput;

        [SerializeField]
        Transform m_Spine;
        [SerializeField]
        float m_RotSpeed = 1;

        [SerializeField]
        Vector2 MinMaxXAngles = new Vector2(-30, 30);
        [Inject]
        void Construct(AimTouchInput aimInput)
        {
            m_AimInput = aimInput;
        }

        bool AimStarted;
        Quaternion m_InitRot;
        private void Start()
        {
            m_InitRot = m_Spine.rotation;


        }
        private void OnEnable()
        {
            m_AimInput.OnAimStarted += M_AimInput_OnAimStarted;
            m_AimInput.OnAimEnded += M_AimInput_OnAimEnded;
        }

        private void M_AimInput_OnAimEnded()
        {
            AimStarted = false;
        }

        private void M_AimInput_OnAimStarted(Vector2 obj)
        {
            AimStarted = true;
        }

        private void OnDisable()
        {
            m_AimInput.OnAimStarted -= M_AimInput_OnAimStarted;
            m_AimInput.OnAimEnded -= M_AimInput_OnAimEnded;
        }

        private void Update()
        {
          
            if (AimStarted)
            {

              

               
                float singleStep = Time.deltaTime * m_AimInput.AimVector.sqrMagnitude;
                Vector3 newDirection = Vector3.RotateTowards(m_Spine.forward, m_AimInput.AimVector, singleStep, 0.0f);
                m_Spine.rotation = Quaternion.LookRotation(newDirection);

               
            }
            else 
            {

                m_Spine.rotation = Quaternion.RotateTowards(m_Spine.rotation, m_InitRot, Time.deltaTime * m_RotSpeed);
            }
        }
    }

}
