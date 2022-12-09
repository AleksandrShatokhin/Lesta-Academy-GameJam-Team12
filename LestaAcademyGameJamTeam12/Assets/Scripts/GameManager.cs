using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> items;
    [SerializeField] private GameObject coin;
    [SerializeField] private Transform leftSpawnPoint, rightSpawnPoint;
    [SerializeField] private Transform chestPosition;
    [SerializeField] private float waitTimeBetweenSpawns = 2.0f;
    [SerializeField] private UIManager uIManager;

    private float score;

    public float Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            uIManager.SetHighscoreText((int)Score);
        }
    }

    private void Start()
    {
        StartCoroutine(FallingObjectSpawnCour());
    }

    private IEnumerator FallingObjectSpawnCour()
    {
        while (true)
        {
            Vector2 spawnPosition = GenerateSpawnPosition();
            GameObject randomObject = GenerateFallingItem();
            GameObject createdItem = Instantiate(randomObject, spawnPosition, Quaternion.identity);

            createdItem.GetComponent<FallingItem>().FlyingGoal = chestPosition.position;
            yield return new WaitForSeconds(waitTimeBetweenSpawns);
        }
    }

    private Vector2 GenerateSpawnPosition()
    {
        float distanceBetweenSpawnPoints = rightSpawnPoint.position.x - leftSpawnPoint.position.x;
        float randomPositionX = leftSpawnPoint.position.x + Random.Range(0, distanceBetweenSpawnPoints);

        Vector2 spawnPosition = new Vector2(randomPositionX, rightSpawnPoint.position.y);
        return spawnPosition;
    }

    private GameObject GenerateFallingItem()
    {
        int randomNumber = Random.Range(0, items.Count);
        return items[randomNumber];
    }
}
