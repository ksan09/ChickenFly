using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTest : MonoBehaviour
{
    private StageManager stM;
    [SerializeField] private GameObject exitPanel;
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        stM = GameObject.Find("StageManager").GetComponent<StageManager>();
        exitPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SceneChange();
    }
    private void SceneChange()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene("Play");
            if (Input.GetKeyDown(KeyCode.E))
                stM.CrtTime = stM.ClearTime;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && isActive == false)
        {
            exitPanel.SetActive(true);
            Time.timeScale = 0;
            isActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isActive == true)
        {
            exitPanel.SetActive(false);
            Time.timeScale = 1;
            isActive = false;
        }



    }
    public void Retry()
    {
        PlayerPrefs.SetInt("Revive", 0);
        PlayerManager.Instance.ResetPlayer();
        Time.timeScale = 1;
        exitPanel.SetActive(false);
        SceneManager.LoadScene("Start");
    }
    public void Exit()
    {
        PlayerPrefs.SetInt("Revive", 0);
        Application.Quit();
    }
    public void Return()
    {
        Time.timeScale = 1;
        exitPanel.SetActive(false);
    }
}
