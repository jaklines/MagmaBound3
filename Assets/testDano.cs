using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testDano : MonoBehaviour
{
    public int life = 20;
    public bool BossDead;
    public GameObject Boss;
  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            life = life -1;
            if (life <= 0)
            {                
                 SceneManager.LoadScene("VictoryScene");
 
                 Destroy(Boss);
            }
            Debug.Log("life[life - 1]");
        }
    }
}
