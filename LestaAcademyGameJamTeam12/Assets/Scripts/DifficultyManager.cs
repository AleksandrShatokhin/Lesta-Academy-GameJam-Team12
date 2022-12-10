using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{

    [SerializeField] private float startingWaitTimeBetweenSpawns = 2.0f;
    [SerializeField] private float startingObjectFlyingDuration = 1.5f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float minFlyingDuration = 1.0f;
    [SerializeField] private float maxFlyingDuration = 2.0f;

    private float spentGold = 0f;

    private float currentWaitTimeBetweenSpawns;
    public float CurrentWaitTimeBetweenSpawns
    {
        get
        {
            return currentWaitTimeBetweenSpawns;
        }

        private set
        {
            currentWaitTimeBetweenSpawns = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentWaitTimeBetweenSpawns = startingWaitTimeBetweenSpawns;
    }

    /*
        При увеличении сложности увеличить количество объектов от 1 до ??
        За сложность отвечает скрытый параметр, представляющий из себя сумму купленных предметов + счет от 1 до 5
        Duration от 1 до 2
    */

    public void AddToSpentGold(float itemPrice)
    {
        spentGold += itemPrice;
    }

    public float GenerateFlyingSpeed()
    {
        float randomNumber = Random.Range(minFlyingDuration, maxFlyingDuration);
        return randomNumber;
    }

    //Возвращает общую сумму денег потраченную на предметы + текущее количество денег
    private float SumGold() => gameManager.Score + spentGold;

    /* 
        Монетка - 1
        Золотая - 3
        Слиток -5 

        Банан - -1
        Яблоко - -3
        Сиги - -5
        Бутылка - -10
    */
}
