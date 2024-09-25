using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class DanoBoss : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    [SerializeField] CountdownEvent CollPlay;
    public float Range = 1.1f;
    public float Mira;
    public Rigidbody2D BossRb;
    [SerializeField] private bool BossPos;


    private void Start()
    {
        part = GetComponentInChildren<ParticleSystem>();
        Rigidbody2D BossMira = part.GetComponent<Rigidbody2D>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

   //private void FixedUpdate()
   //{
   //    RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
   //    if (hit.collider != null)
   //    {
   //        float distance = Mathf.Abs(hit.point.y - transform.position.y);
   //    }
   //}

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        int i = 0;
        PlayerMovement2 vida = other.GetComponent<PlayerMovement2>();
        if (vida != null)
        {
            vida.badObjects++;
            vida.TookDamage();
        }
    
        /*while (i < numCollisionEvents)
        {
            if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 normal = collisionEvents[i].normal;
            }
            if (other.CompareTag("Player"))
            {
                Debug.Log("detectouplayer");
                return;
            
            }
            i++;
             //PlayerMovement2 dano = other.GetComponent<PlayerMovement2>();
             //int p = 0;
            
              //Debug.Log(other.gameObject.name);
              //hile (p < numCollisionEvents)
              //
              //   if (dano)
              //   {
              //       dano.badObjects++;
              //       dano.TookDamage();
              //   }
              //   i++;
              //
            
        }*/
    }


    //rivate void OnParticleTrigger()
    //
    //   ParticleSystem ps = GetComponent<ParticleSystem>();
    //
    //   // particles
    //   List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    //   List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();
    //
    //   // get
    //   int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    //   int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    //
    //   // iterate
    //   for (int i = 0; i < numEnter; i++)
    //   {
    //       ParticleSystem.Particle p = enter[i];
    //       p.startColor = new Color32(255, 0, 0, 255);
    //       enter[i] = p;
    //   }
    //   for (int i = 0; i < numExit; i++)
    //   {
    //       ParticleSystem.Particle p = exit[i];
    //       p.startColor = new Color32(0, 255, 0, 255);
    //       exit[i] = p;
    //   }
    //
    //   // set
    //   ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    //   ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    //
}

       /* private bool IsPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null)
        {
            CompareTag("Player");
            return true;           
        }
        else
        {
            return false;
        }
    }*/

   


    /*{
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    
    }*/

