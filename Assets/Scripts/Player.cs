using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        BoxCollider2D Leg;
        private int m_Health = 5;


        [SerializeField]
        LayerMask m_GroundMask;
        bool m_IsGrounded = false;
        bool IsGrounded()
        {
            return Physics2D.Raycast(Leg.bounds.center, Vector2.down, Leg.bounds.extents.y + .01f, m_GroundMask);
        }

        private void Update()
        {

            m_IsGrounded = IsGrounded();
            //if (Tap.LeftScreenTap)
            //{
            //    print(Jump);
            //}

            //print(IsGrounded());
        }

        public void Jump()
        {
            if (m_IsGrounded)
            {
                print("Jump");
            }
        }
    }

}
