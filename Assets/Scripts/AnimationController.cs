using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Player))]
    public class AnimationController : MonoBehaviour
    {
        Animator m_Animator;
        Player m_Player;

        private static readonly int JumpAnimParam;
        private static readonly int IsGroundedAnimParam;
        static AnimationController()
        {
            JumpAnimParam = Animator.StringToHash("Jump");
            IsGroundedAnimParam = Animator.StringToHash("IsGrounded");
        }
        void Awake()
        {
            m_Animator = GetComponent<Animator>();
            m_Player = GetComponent<Player>();
        }


        private void OnEnable()
        {
            m_Player.OnJumped += Jump;
        }

        private void OnDisable()
        {
            m_Player.OnJumped -= Jump;
        }

        private void Update()
        {
            m_Animator.SetBool(IsGroundedAnimParam, m_Player.IsGrounded);
        }

        void Jump()
        {
            m_Animator.SetTrigger(JumpAnimParam);
        }

    }
}


