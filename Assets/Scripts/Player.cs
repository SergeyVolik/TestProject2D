using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        BoxCollider2D BodyCollider;
        [SerializeField]
        Rigidbody2D BodyRB;

        [SerializeField]
        float m_JumpForce = 5f;
        [SerializeField]
        int m_AdditionalJump = 1;
        private int m_CurrentJump;




        [SerializeField]
        LayerMask m_GroundMask;

        [SerializeField]
        bool m_IsGrounded = false;

        HealthHandler m_HealthHandler;

        Gun m_Gun;

        [Inject]
        void Construct(HealthHandler healthHandler, Gun gun)
        {
            m_HealthHandler = healthHandler;
            m_Gun = gun;
        }

        public Vector2 LookDiraction => transform.rotation.eulerAngles.y == 180 ? Vector2.left : Vector2.right;
        public bool LookLeft => transform.rotation.eulerAngles.y == 180 ? true : false;
        public bool IsGrounded => m_IsGrounded;

        public event Action OnJumped;
        bool CheckGrounded()
        {
            return Physics2D.Raycast(BodyCollider.bounds.center, Vector2.down, BodyCollider.bounds.extents.y + .1f, m_GroundMask);
        }

        private void Update()
        {

            m_IsGrounded = CheckGrounded();

            if (m_IsGrounded)
                m_CurrentJump = 0;
        }

        public void Jump()
        {
            if (m_CurrentJump < m_AdditionalJump)
            {
                m_CurrentJump++;
                BodyRB.velocity = new Vector2(BodyRB.velocity.x, 0);
                BodyRB.AddForce(Vector2.up * m_JumpForce);
                OnJumped.Invoke();
            }
        }

        public void Shot()
        {
            m_Gun.Shot();
        }
    }

}
