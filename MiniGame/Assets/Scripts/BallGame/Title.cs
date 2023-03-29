using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _exitButton;

    public void OnClickedStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickedExitButton()
    {
        Application.Quit();
    }
}
