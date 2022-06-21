using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEvent : MonoBehaviour
{
    public void StartButtonClick()
    {
        PlayerPrefs.SetInt("crtStage", 1);
        SceneManager.LoadScene("Play");
    }
}
