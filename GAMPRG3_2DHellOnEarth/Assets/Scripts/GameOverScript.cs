using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public void Setup()
    {
        //Score Setup
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
