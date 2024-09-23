using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA; // Ponto A
    public Transform pointB; // Ponto B
    public float speed = 6.0f; // Velocidade de movimento
    private Vector3 target; // Alvo atual do inimigo

    void Start()
    {
        // Define o alvo inicial como o ponto A
        target = pointA.position;
    }

    void Update()
    {
        // Move o inimigo em direção ao alvo (pointA ou pointB)
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Quando o inimigo chega ao ponto alvo, troca para o outro ponto
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }
}
