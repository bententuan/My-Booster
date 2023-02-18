using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    
    [SerializeField] float thrustForce = 1000f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] AudioSource mainEngineAudioSource;
    [SerializeField] AudioClip mainEngineAudioClip;
    [SerializeField] AudioSource rotateEngineAudioSource;
    [SerializeField] AudioClip rotateEngineAudioClip;
    [SerializeField] ParticleSystem leftSidePE;
    [SerializeField] ParticleSystem rightSidePE;
    [SerializeField] ParticleSystem centerPE;
    
    Rigidbody body;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        StartThrusting();   
        StartRotating();
    }

    private void StartThrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PlayAudio(mainEngineAudioSource, mainEngineAudioClip);
            PlayParticleEffect(centerPE);
            body.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        } 
        else
        {
            StopPlayingParticle(centerPE);
            StopPlayingAudio(mainEngineAudioSource);
        }

    }

    private void StartRotating()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayAudio(rotateEngineAudioSource, rotateEngineAudioClip);
            PlayParticleEffect(rightSidePE);
            StopPlayingParticle(leftSidePE);
            RotateObject(false);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {            
            PlayParticleEffect(leftSidePE);
            StopPlayingParticle(rightSidePE);
            PlayAudio(rotateEngineAudioSource, rotateEngineAudioClip);
            RotateObject(true);
        }
        else
        {
            StopPlayingParticle(rightSidePE);
            StopPlayingParticle(leftSidePE);
            StopPlayingAudio(rotateEngineAudioSource);
        }
        
    }

    private void RotateObject(bool isLeftDirection)
    {
        body.freezeRotation= true;
        transform.Rotate(Vector3.forward * rotationSpeed * (isLeftDirection ? -1 : 1) * Time.deltaTime);
        body.freezeRotation = false;
    }

    private void PlayAudio(AudioSource source, AudioClip audioClip)
    {
        if (!source.isPlaying)
        {
            source.PlayOneShot(audioClip);
        }
    }

    private void PlayParticleEffect(ParticleSystem inputParticle)
    {
        if (!inputParticle.isPlaying)
        {
            inputParticle.Play();
        }
    }

    private void StopPlayingParticle(ParticleSystem inputParticle)
    {
        inputParticle.Stop();
    }

    private void StopPlayingAudio(AudioSource source)
    {
        source.Stop();
    }

    public void StopAllSound()
    {
        StopPlayingAudio(mainEngineAudioSource);
        StopPlayingAudio(rotateEngineAudioSource);
    }

    public void StopAllParticle()
    {
        StopPlayingParticle(centerPE);
        StopPlayingParticle(leftSidePE);
        StopPlayingParticle(rightSidePE);
    }
}
