using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneChange();
    }
    private void SceneChange()
    {
        if (Input.GetKeyUp(KeyCode.X))
            SceneManager.LoadScene("Play");
    }
}
