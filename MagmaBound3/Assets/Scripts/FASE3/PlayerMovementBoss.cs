using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBoss : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    void Update()
    {
        //movimentação
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveInput * moveSpeed, 0);
        transform.Translate(movement * Time.deltaTime);

        //implementar tiro nessa script
    }
}
