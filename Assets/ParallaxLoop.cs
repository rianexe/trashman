using UnityEngine;

public class ParallaxLoop : MonoBehaviour
{
    public float speed = 2f;
    private float length; // Calculado automaticamente

    private void Start()
    {
        // Calcula o comprimento com base nos limites combinados dos filhos
        float minX = float.MaxValue;
        float maxX = float.MinValue;

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            minX = Mathf.Min(minX, r.bounds.min.x);
            maxX = Mathf.Max(maxX, r.bounds.max.x);
        }

        length = maxX - minX;
    }

    private void Update()
    {
        if (!GameManager.Instance.isPlaying) return;

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        float leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero).x;

        // Só reposiciona quando o lado direito sair completamente da tela
        float rightEdgeOfObject = transform.position.x + (length / 2f);
        if (rightEdgeOfObject <= leftEdge)
        {
            transform.position += new Vector3(length * 2f, 0, 0);
        }
    }
}
