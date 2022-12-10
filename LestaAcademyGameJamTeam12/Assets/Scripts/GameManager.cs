using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> items;
    [SerializeField] private Transform leftSpawnPoint, rightSpawnPoint;
    [SerializeField] private Transform chestPosition;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private AnimationCurve fallingTrajectory;
    [SerializeField] private DifficultyManager difficultyManager;

    [Range(0, 100)]
    [SerializeField] private float heat = 100f;

    [SerializeField] private float heatDecreaseRate = 1.0f;

    [SerializeField] private Slider heatSlider;

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
        StartCoroutine(StartingFallingObjectsCour());
    }

    private void Update()
    {
        DecreaseHeat();
    }

    private IEnumerator StartingFallingObjectsCour()
    {
        StartCoroutine(FallingObjectSpawnCour());
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FallingObjectSpawnCour());
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(FallingObjectSpawnCour());
        yield return new WaitForSeconds(0.1f);

    }

    private IEnumerator FallingObjectSpawnCour()
    {
        while (true)
        {
            Vector2 spawnPosition = GenerateSpawnPosition();
            GameObject randomObject = GenerateFallingItem();
            GameObject createdItem = Instantiate(randomObject, spawnPosition, Quaternion.identity);

            createdItem.GetComponent<FallingItem>().FlyingGoal = chestPosition.position;
            createdItem.GetComponent<FallingItem>().FallingTrajectory = fallingTrajectory;

            float randomFlyingSpeed = difficultyManager.GenerateFlyingSpeed();
            createdItem.GetComponent<FallingItem>().Duration = randomFlyingSpeed;

            StartCoroutine(createdItem.GetComponent<FallingItem>().CurveMovement());
            yield return new WaitForSeconds(difficultyManager.CurrentWaitTimeBetweenSpawns);
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

    public void AddHeat(float heat)
    {
        this.heat += heat;
        if (this.heat > 100)
        {
            this.heat = 100;
        }
    }

    private void DecreaseHeat()
    {
        heat -= heatDecreaseRate * Time.deltaTime;
        heatSlider.value = heat;

        if (heat <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
