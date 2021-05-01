using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathWallControl : MonoBehaviour
{


    [SerializeField]
    public ParticleSystem BlackHoleParticle;

    void Start()
    {
        BlackHoleParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
