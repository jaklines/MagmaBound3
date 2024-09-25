using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coletarMoedas2 : MonoBehaviour
{
    private int collectedCoins = 0;

    private void OnTriggerEnter2D(Collider2D moe)
    {
        if (moe.CompareTag("Moeda"))
        {
            Destroy(moe.gameObject);
            collectedCoins++;

            if (collectedCoins >= 5)
            {
               //perguntar se eu coloco o codigo de pegar a informação de quantidade armazenada de
               //moedas na script do player ou se faço aqui pra atirar automaticamente e perguntar se eu usei o RayCast certo


            }
        }
    }





}
