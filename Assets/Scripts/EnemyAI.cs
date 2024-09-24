using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public float detectionRange = 15.0f; // Alcance em que o inimigo detecta o jogador
    public float speed = 10.0f; // Velocidade de movimento do inimigo
    public float minZ = 27.6f; // Limite mínimo no eixo Z (corrigido)
    public float maxZ = 46.5f; // Limite máximo no eixo Z
    private Rigidbody rb; // Rigidbody para o movimento do inimigo

    private void Start()
    {
        // Pegamos o Rigidbody do inimigo
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calcula a distância entre o jogador e o inimigo
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Se o jogador estiver dentro do raio de detecção, o inimigo começa a persegui-lo
        if (distanceToPlayer <= detectionRange)
        {
            FollowPlayer(); // Chama a função de seguir o jogador
        }
        else
        {
            // Para o movimento do inimigo quando o jogador sai do alcance
            rb.velocity = Vector3.zero;
        }

        // Limita a posição no eixo Z para garantir que o inimigo fique entre minZ e maxZ
        LimitPosition();
    }

    // Função para seguir o jogador
    void FollowPlayer()
    {
        // Calcula a direção do inimigo em relação ao jogador
        Vector3 direction = (player.position - transform.position).normalized;

        // Usar o Rigidbody.velocity para mover o inimigo em direção ao jogador
        rb.velocity = direction * speed;
    }

    // Função para limitar a posição do inimigo no eixo Z
    void LimitPosition()
    {
        Vector3 position = transform.position;

        // Limita o valor de Z entre minZ e maxZ
        position.z = Mathf.Clamp(position.z, minZ, maxZ);

        // Aplica a nova posição limitada
        transform.position = position;
    }

    // (Opcional) Desenhar a área de detecção no editor para ajudar a visualizar o alcance de perseguição
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
