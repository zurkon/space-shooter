using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Animator anim;
    public string animationName;

    // Start is called before the first frame update
    void OnEnable()
    {
        anim.Play($"Base Layer.{animationName}");
    }

    public void DisableFX()
    {
        gameObject.SetActive(false);
    }
}
