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
    private Vector2 movementInput; // Agora capturamos o movimento com um Vector2
    private bool gameFinished = false;
    public AudioSource pickupSound;
    public AudioSource respawnSound;
    private bool DEEPER = false;

    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void FixedUpdate() 
    {
        Vector3 movement = new Vector3(movementInput.x, 0.0f, movementInput.y);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            pickupSound.Play();
        }
        if (other.gameObject.CompareTag("FallZone")) 
        {
            Respawn();
            respawnSound.Play();
        }
    }

    // Método chamado para movimento (teclado e controle)
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>(); // Captura input de teclado ou controle
    }

    // Método chamado para pular
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) // Verifica se o salto foi acionado
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1.1f)) // Verifica se está no chão
            {
                rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }
    }

    // Método chamado para reiniciar o jogo
    public void OnRestart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Application.LoadLevel(1); // Reinicia o nível
        }
    }

    // Método chamado para voltar ao menu principal
    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Application.LoadLevel(0); // Retorna ao menu principal
        }
    }

    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();
        
        if (count >= 21 && !DEEPER)
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
        if (!gameFinished)
        {
            float timeRemaining = timeLimit - Time.timeSinceLevelLoad;
            timeText.text = "Time: " + Mathf.Max(0, timeRemaining).ToString("F2") + "s";

            if (timeRemaining <= 0)
            {
                DEEPER = true;
                gameFinished = true;
                winTextObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose! Time's Up!";
                winTextObject.GetComponent<TextMeshProUGUI>().text += "\nPress R to try again!";
            }
        }
    }

    // Função para reposicionar o jogador no ponto de respawn
    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = respawnPoint.position;
    }
}
