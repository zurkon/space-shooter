using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Animation Properties")]
    public Animator anim;
    public string animationName;

    [Header("Audio Source")]
    public AudioSource audioSource;
    public AudioClip explosionSound;
    [Range(0, 1)]
    public float explosionSoundVolume = 0.5f;

    // Start is called before the first frame update
    void OnEnable()
    {
        anim.Play($"Base Layer.{animationName}");
        audioSource.PlayOneShot(explosionSound, explosionSoundVolume);
    }

    public void DisableFX()
    {
        gameObject.SetActive(false);
    }
}
