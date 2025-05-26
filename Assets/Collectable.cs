using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{
    public int points = 10; // valor do coletável

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.currentScore += points;

            // Toca o som de coleta
            AudioManager.instance.PlaySFX(AudioManager.instance.collect);

            StartCoroutine(FadeAndDestroy());
        }
    }

    private IEnumerator FadeAndDestroy()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color originalColor = sr.color;

        float duration = 0.5f;
        float timer = 0f;

        while (timer < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / duration);
            sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
