using UnityEditor;
using UnityEngine;


namespace TestProject
{

    [CustomEditor(typeof(AudioSettingsSO), true)]
    public class AudioEventInspector : UnityEditor.Editor
    {
        [SerializeField]
        private AudioSource m_Preview;

        public void OnEnable()
        {
            m_Preview = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
        }

        public void OnDisable()
        {
            DestroyImmediate(m_Preview.gameObject);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
            if (GUILayout.Button("preview"))
            {
               
                ((AudioSettingsSO)target).Play(m_Preview);
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}
