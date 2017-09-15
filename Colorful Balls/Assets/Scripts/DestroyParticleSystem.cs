using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour {

    ParticleSystem partSys;

    private void Start()
    {
        partSys = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!partSys.isPlaying) Destroy(gameObject);
    }
}
