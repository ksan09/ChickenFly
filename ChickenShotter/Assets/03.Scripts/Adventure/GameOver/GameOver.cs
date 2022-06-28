using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private int revive;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Revive()
    {
        revive = PlayerPrefs.GetInt("Revive", 0);
        PlayerManager.Instance.PlayerCurrentHealth = PlayerManager.Instance.PlayerMaxHealth;
        revive++;
        PlayerPrefs.SetInt("Revive", revive);
        SceneManager.LoadScene("Play");
    }
    public void ReStart()
    {
        PlayerPrefs.SetInt("Revive", 0);
        PlayerManager.Instance.ResetPlayer();
        SceneManager.LoadScene("Start");
    }
}
