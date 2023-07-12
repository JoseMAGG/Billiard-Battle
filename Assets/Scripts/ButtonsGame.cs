using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsGame : MonoBehaviour
{
    public GameObject menuPanel;

    private bool _menuPanelActive;
    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchPanel()
    {
        menuPanel.SetActive(!_menuPanelActive);
        _menuPanelActive = !_menuPanelActive;
    }

    public void HomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
