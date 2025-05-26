using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public List<Sprite> collectibleSprites;

    public float spawnInterval = 2f;
    public float spawnX = 10f; // fora da tela à direita
    public float minY = -2f;
    public float maxY = 2f;

    private bool spawning = false;

    private void Start()
    {
        // Deixe vazio se o spawner só começa com StartSpawning()
    }

    void SpawnCollectible()
    {
        Vector3 spawnPosition = new Vector3(spawnX, Random.Range(minY, maxY), 0f);
        GameObject newCollectible = Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
        newCollectible.transform.localScale = new Vector3(0.5f, 0.5f, 1f); 

        // Sorteia o sprite
        SpriteRenderer sr = newCollectible.GetComponent<SpriteRenderer>();
        if (sr != null && collectibleSprites.Count > 0)
        {
            Sprite randomSprite = collectibleSprites[Random.Range(0, collectibleSprites.Count)];
            sr.sprite = randomSprite;
        }
    }

    public void StartSpawning()
    {
        spawning = true;
        StartCoroutine(SpawnRoutine());
    }

    public void StopSpawning()
    {
        spawning = false;
    }

    private IEnumerator SpawnRoutine()
    {
        while (spawning)
        {
            SpawnCollectible();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
