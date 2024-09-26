using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D BossRB;
    [SerializeField] private Vector3 BossPos;
    [SerializeField] private float TimeBoss;
    TimerState BossTimer;

    [SerializeField] private Transform[] Target;
    private float StoppingDistance = 4;
    private int currentTarget = 0;
 
    public Vector3 BossMovementRB { get; private set; }

    Time GetTime;
    int speed = 6;
    
    


    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    //oid Update()
    //
    //   BossPos = transform.position;
    //   BossMovementRB = new Vector3(-6.3499999f, -1.13999999f, 0);
    //
    //   if (TimeBoss > 5)
    //   {
    //       BossMovementRB = new Vector3(-0.379999995f, 1.62f, 0);
    //   }
    //   if (TimeBoss < 5)
    //   {
    //       BossPos = BossMovementRB;
    //   }
    //   return;
    //

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Target[currentTarget].position);
        if (distance >= StoppingDistance)
        {          
            Vector3 direction = Target[currentTarget].position - transform.position;
            direction.Normalize();
            BossRB.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }
        else
        {
            currentTarget++;
       
            if (currentTarget >= Target.Length)
            {
                currentTarget = 0;
            }
        }
    }
}
