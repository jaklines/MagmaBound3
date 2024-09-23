using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    int goodObjects = 0;
    int badObjects = 0;
    int maxObjects = 5;

    public Image powerBottle; //garrafinha
    public Image[] vida;

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

            if (goodObjects >= maxObjects)
            {
                LoadNextScene(); // cena do boss
            }
        }
        else if (other.CompareTag("Ruim"))
        {
            badObjects++;
            Destroy(other.gameObject);

            UpdateHearts();

            if (badObjects >= maxObjects)
            {
                GameOver();
            }
        }
    }

    void UpdatePowerBar()
    {
        //atualiza a garrafinha
        float fillAmount = (float)goodObjects / maxObjects;
        powerBottle.fillAmount = fillAmount;
    }

    void UpdateHearts()
    {
        // desativa os corações conforme coleta objetos ruins
        if (badObjects <= vida.Length)
        {
            vida[badObjects - 1].enabled = false; // desativa um coração
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("BossScene");
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}