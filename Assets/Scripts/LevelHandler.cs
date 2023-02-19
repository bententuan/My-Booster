using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelHandler : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(1);
        } else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(2);
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(3);
        } else if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        } else if(Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(4);
        }
    }
}
