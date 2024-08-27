using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Net.Sockets;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI WinText;
    private Rigidbody rb;
    private int score;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb  = GetComponent<Rigidbody>();
        score = 0;

        SetScoreTest();
        WinText.gameObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

         movementX = movementVector.x;
         movementY = movementVector.y;
    }
    
    void SetScoreTest()
    {
        scoreText.text = "Score :" + score.ToString();
        if (score >= 5)
        {
            WinText.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movemont = new Vector3 (movementX, 0f, movementY);

        rb.AddForce (movemont * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
            //score = score + 1;
            SetScoreTest();
        }
       
    }
}
