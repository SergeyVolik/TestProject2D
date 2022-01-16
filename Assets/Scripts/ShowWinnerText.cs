using UnityEngine;
using DG.Tweening;
using Zenject;

namespace TestProject
{

    public class ShowWinnerText : MonoBehaviour
    {
        [SerializeField]
        CanvasGroup m_FadeGroup;
        GameEndSettings m_Settings;

        [Inject]
        void Construct(GameEndSettings settings)
        {
            m_Settings = settings;
        }
        public void Show()
        {
            m_FadeGroup.transform.localPosition = Vector3.zero;
            m_FadeGroup.DOFade(1f, m_Settings.FadePlayerTextTime);        
            m_FadeGroup.transform.DOLocalMoveY(150, m_Settings.FadePlayerTextTime);

        }


    }

}
