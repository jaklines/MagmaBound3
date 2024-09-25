using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayerMovement2 : MonoBehaviour
{
   [SerializeField] float moveSpeed = 5f;
   [SerializeField] private GameObject Boss;
   [SerializeField] int goodObjects = 0;
   [SerializeField] public int badObjects = 0;
    
    int maxObjects = 5;

    public Image powerBottle; //garrafinha
    //public Image[] vida;
    public List<Image> vida;

    private void Start()
    {
        powerBottle.fillAmount = 0;
    }
    void Update()
    {
        // Movimentação
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveInput * moveSpeed, 0);
        transform.Translate(movement * Time.deltaTime);

        // Limite da tela
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -7.5f, 11.5f);
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bom"))
        {
            goodObjects++;
            Destroy(other.gameObject);

            UpdatePowerBar(); //atualiza a garrafinha
            receiveLife();

            if (goodObjects >= maxObjects)
            {
                LoadBoss(); // cena do boss               
                
                    
            }
        }
        else if (other.CompareTag("Ruim"))
        {
            badObjects++;
            Destroy(other.gameObject);

            TookDamage();

        }
    }

    void UpdatePowerBar()
    {
        //atualiza a garrafinha
        float fillAmount = (float)goodObjects / maxObjects;
        powerBottle.fillAmount = fillAmount;
    }

    /*void UpdateHearts()
    {

        // desativa os corações conforme coleta objetos ruins
        if (goodObjects >= powerBottle.fillAmount && Boss.activeSelf && ( badObjects >= 1 || badObjects <= 5) 
        {
            goodObjects++;
            vida[badObjects - 1].enabled = true;
            badObjects--;
        }       
        if (badObjects <= vida.Length && badObjects >= 1)
        {
            vida[badObjects - 1].enabled = false; // desativa um coração
        }
    }*/

    public void TookDamage()
    {
        if (badObjects - 1 <= vida.Count && badObjects >= 1)
        {
            vida[badObjects - 1].enabled = false; // desativa um coração
        }
        if (badObjects >= maxObjects)
        {
            GameOver();
        }
    }

    private void receiveLife()
    {
        if (goodObjects >= powerBottle.fillAmount && Boss.activeSelf && badObjects >= 1 && badObjects <= 5)
        {
            goodObjects++;
            vida[badObjects - 1].enabled = true;
            badObjects--;
        }
    }

    void LoadBoss()
    {
        Boss.SetActive(true);
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}