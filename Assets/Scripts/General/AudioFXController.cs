using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFXController : MonoBehaviour
{
    public static AudioFXController Instance;

    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private AudioClip buttonSound;
    [SerializeField]
    private AudioClip collisionSound;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    public void DeathSound()
    {
        var newGameObject = new GameObject();
        var audioSource = newGameObject.AddComponent<AudioSource>();
        audioSource.clip = deathSound;
        audioSource.volume = 1f;
        audioSource.Play();
        Destroy(newGameObject, deathSound.length);
    }
    public void ButtonSound()
    {
        var newGameObject = new GameObject();
        var audioSource = newGameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;
        audioSource.volume = 0.2f;
        audioSource.Play();
        Destroy(newGameObject, buttonSound.length);
    }
    public void CollisionSound()
    {
        var newGameObject = new GameObject();
        var audioSource = newGameObject.AddComponent<AudioSource>();
        audioSource.clip = collisionSound;
        audioSource.volume = 1f;
        audioSource.Play();
        Destroy(newGameObject, collisionSound.length);
    }
}
