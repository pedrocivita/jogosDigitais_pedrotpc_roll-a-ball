using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timeText; // Campo para o cronômetro
    public GameObject winTextObject;
    public Transform respawnPoint; // Adicione o ponto de respawn
    public float timeLimit = 60.0f; // Limite de tempo
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool gameFinished = false;
    public AudioSource pickupSound;
    public AudioSource respawnSound;
    private bool DEEPER = false;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void FixedUpdate() 
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            pickupSound.Play();
        }
        // Detecta se a bola caiu fora da área e reposiciona
        if (other.gameObject.CompareTag("FallZone")) 
        {
            Respawn();
            respawnSound.Play();
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();
        
        if (count >= 21 && DEEPER != true)
        {
            DEEPER = true;
            gameFinished = true;
            float timeRemaining = Mathf.Max(0, timeLimit - Time.timeSinceLevelLoad);
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win! Time Remaining: " + timeRemaining.ToString("F2") + "s";
            winTextObject.GetComponent<TextMeshProUGUI>().text += "\nPress R to play again!";
        }
    }

    void Update()
    {
        // Atualiza o cronômetro enquanto o jogo está em andamento
        if (!gameFinished)
        {
            // Calcula o tempo restante
            float timeRemaining = timeLimit - Time.timeSinceLevelLoad;
            timeText.text = "Time: " + Mathf.Max(0, timeRemaining).ToString("F2") + "s";

            // Verifica se o tempo acabou
            if (timeRemaining <= 0)
            {
                DEEPER = true;
                gameFinished = true;
                winTextObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose! Time's Up!";
                winTextObject.GetComponent<TextMeshProUGUI>().text += "\nPress R to try again!";
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(1);
        }

        //Back To Main Menu
        if (Input.GetKeyDown(KeyCode.M))
        {
            Application.LoadLevel(0);
        }

        // Jump from stationary, using ray when ball is on floor
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1.1f))
            {
                rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }
    }

    // Função para reposicionar a bola no ponto de respawn
    void Respawn()
    {
        rb.velocity = Vector3.zero; // Reseta a velocidade
        rb.angularVelocity = Vector3.zero; // Reseta a rotação
        transform.position = respawnPoint.position; // Reposiciona no ponto de respawn
    }
}
