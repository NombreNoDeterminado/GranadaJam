using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimation : MonoBehaviour
{
    public Animation animation;
    public AnimationClip clip;
    
    // Start is called before the first frame update
    void Start()
    {
        animation.clip = clip;
        animation.Play();
    }
    
}
