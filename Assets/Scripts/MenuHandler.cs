using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuHandler : MonoBehaviour
{
    [SerializeField] AudioSource startGame;
    [SerializeField] AudioSource endGame;    
    public void StartGame()
    {
        startGame.Play();
        Invoke("OpenGame", 2);

    }

    private void OpenGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    private void CloseGame() => Application.Quit();

    public void QuitGame()
    {
        endGame.Play();
        Invoke("CloseGame", 2);
    }
}
