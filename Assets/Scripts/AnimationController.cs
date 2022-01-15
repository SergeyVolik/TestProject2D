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
        private static readonly int IsLookLeftAnimParam;
        static AnimationController()
        {
            JumpAnimParam = Animator.StringToHash("Jump");
            IsGroundedAnimParam = Animator.StringToHash("IsGrounded");
            IsLookLeftAnimParam = Animator.StringToHash("LookLeft");
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
            m_Animator.SetBool(IsLookLeftAnimParam, m_Player.LookLeft);
        }

        void Jump()
        {
            m_Animator.SetTrigger(JumpAnimParam);
        }

    }
}


