using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuSceneManager : MonoBehaviour
{

    public GameObject creditPanel;
    public GameObject instructionPanel;

    // Start is called before the first frame update
    void Start()
    {
        creditPanel.SetActive(false);
        instructionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void HideInstruction()
    {
        instructionPanel.SetActive(false);
    }
    public void ShowInstruction()
    {
        instructionPanel.SetActive(true);
    }

    public void ShowCredit()
    {
        creditPanel.SetActive(true);
    }
    public void HideCredit()
    {
        creditPanel.SetActive(false);
    }
}
