using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditHandler : MonoBehaviour
{
   public void reloadGame()
    {
        StartCoroutine(reloadMainMenu());
    }

    IEnumerator reloadMainMenu()
    {        
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
