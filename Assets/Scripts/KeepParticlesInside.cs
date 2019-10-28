using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepParticlesInside : MonoBehaviour {

    public GameObject element;

    private ParticleSystem pSystem;
    private Collider[] colliders;

    // Use this for initialization
    void Start () {
        pSystem = this.GetComponent<ParticleSystem>();
        colliders = element.GetComponents<Collider>();
    }
	
	// Update is called once per frame
	void Update () {

        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[pSystem.particleCount];
        int size = pSystem.GetParticles(particles);

        List<ParticleSystem.Particle> newParticles = new List<ParticleSystem.Particle>();

        for (int i = 0; i < size; i++)
        {
            foreach (Collider collider in colliders)
            {
                if(collider.bounds.Contains(particles[i].position))
                    newParticles.Add(particles[i]);
            }

            /*
                bool upRightCornerIn = false;
            bool downLeftCornerIn = false;
            Vector3 upRightCorner = particles[i].position;
            upRightCorner.x += particles[i].startSize / 2;
            upRightCorner.y += particles[i].startSize / 2;
            Vector3 downLeftCorner = particles[i].position;
            downLeftCorner.x -= particles[i].startSize / 2;
            downLeftCorner.y -= particles[i].startSize / 2;

            foreach (Collider collider in colliders)
            {
                if (collider.bounds.Contains(upRightCorner))
                {
                    upRightCornerIn = true;
                }
                if (collider.bounds.Contains(downLeftCorner))
                {
                    downLeftCornerIn = true;
                }
            }
            if (upRightCornerIn && downLeftCornerIn)
            {
                newParticles.Add(particles[i]);
            }*/
        }

        pSystem.SetParticles(newParticles.ToArray(), newParticles.Count);
    }    
}
