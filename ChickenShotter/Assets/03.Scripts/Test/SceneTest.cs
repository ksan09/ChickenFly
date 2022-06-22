using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTest : MonoBehaviour
{
    private StageManager stM;
    // Start is called before the first frame update
    void Start()
    {
        stM = GameObject.Find("StageManager").GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SceneChange();
    }
    private void SceneChange()
    {
        if (Input.GetKeyUp(KeyCode.R))
            SceneManager.LoadScene("Play");
        if (Input.GetKeyUp(KeyCode.E))
            stM.CrtTime = stM.ClearTime;
        if (Input.GetKeyUp(KeyCode.T))
            SceneManager.LoadScene("Start");
            
    }
}
