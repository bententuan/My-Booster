using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] int loadSceneDelay = 2;
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;
    AudioSource audioSource;

    private bool isTransition = false;
    private bool isCheating = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(isCheating);
            isCheating = !isCheating;
            GetComponent<BoxCollider>().enabled = isCheating;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isTransition) { return; }
        switch(collision.gameObject.tag)
        {
            case "Obstacle":
                isTransition = true;
                HandleCrashing();
                break;
            case "LandingArea":
                isTransition = true;
                HandleLoadNextLevel();
                break;
            default: break;
        }
    }

    private void HandleCrashing()
    {
        gameObject.GetComponent<MovementHandler>().enabled = false;
        
        PlayAudioClip(crashAudio);
        PlayParticle(crashParticle);
        Invoke("ReloeadScene", loadSceneDelay);
    }

    private void HandleLoadNextLevel()
    {
        gameObject.GetComponent<MovementHandler>().enabled = false;
        PlayAudioClip(successAudio);
        PlayParticle(successParticle);
        Invoke("LoadNextLevel", loadSceneDelay);
    }
    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void ReloeadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    private void PlayParticle(ParticleSystem inputParticle)
    {
        if(!inputParticle.isPlaying)
        {
            inputParticle.Play();
        }
    }
    private void StopParticle(ParticleSystem inputParticle)
    {
        inputParticle.Stop();
    }
}
