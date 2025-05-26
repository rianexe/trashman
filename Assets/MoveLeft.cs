using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Destroi caso saia da tela (ajuste o valor conforme seu jogo)
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}

