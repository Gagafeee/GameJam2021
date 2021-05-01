using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particule ;


    void Start()
    {
        createHoleParticle();
    }

    void createHoleParticle()
	{
        particule.Play();
    }
}
