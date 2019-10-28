using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticlesAlongPipe : MonoBehaviour {

    ParticleSystem pSystem;
    public GameObject Pipe;
    public Collider Turn;

	// Use this for initialization
	void Start () {
        pSystem = this.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[pSystem.particleCount];
        int size = pSystem.GetParticles(particles);

        for (int i = 0; i < size; i++)
        {
            if (Turn.bounds.Contains(particles[i].position))
            {
                float angle = 0.08f * particles[i].velocity.magnitude;
                Vector3 newVelocity = Quaternion.Euler(0, 0, -angle) * particles[i].velocity;
                angle = Vector3.SignedAngle(newVelocity, Vector3.right, Vector3.forward);

                if (angle > 0)
                {
                    newVelocity = Quaternion.Euler(0, 0, angle) * newVelocity;
                }
                particles[i].velocity = newVelocity;
            }
            else
            {
                particles[i] = Straighten(particles[i]);
            }
        }

        ParticleSystem.Particle[] newParticles = KeepParticlesInside(particles, size);
        pSystem.SetParticles(newParticles, newParticles.Length);

	}

    private ParticleSystem.Particle Straighten(ParticleSystem.Particle particle)
    {
        float magnitude = particle.velocity.magnitude;
        if (particle.velocity.x > particle.velocity.y)
        {
            particle.velocity = new Vector3(magnitude, 0, 0);
        }
        else
        {
            particle.velocity = new Vector3(0, magnitude, 0);
        }
        return particle;
    }

    private ParticleSystem.Particle[] KeepParticlesInside(ParticleSystem.Particle[] particles, int size)
    {
        
        List<ParticleSystem.Particle> newParticles = new List<ParticleSystem.Particle>();
        Collider[] colliders = Pipe.GetComponentsInChildren<Collider>();

        for (int i = 0; i < size; i++)
        {
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
            }
        }

        return newParticles.ToArray();
    }
}
