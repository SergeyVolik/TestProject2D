using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Button m_Button;

    public bool LeftButtonClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Button.onClick.AddListener(() => {
            LeftButtonClicked = true;
            Debug.Log("Click");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
