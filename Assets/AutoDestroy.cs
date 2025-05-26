using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Update()
    {
        // Se o objeto estiver fora da tela pela esquerda, destrói
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
