using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    private float duration = 1f;
    public float Duration
    {
        get
        {
            return duration;
        }
        set
        {
            duration = value;
        }
    }

    private AnimationCurve fallingTrajectory;
    public AnimationCurve FallingTrajectory
    {
        get
        {
            return fallingTrajectory;
        }

        set
        {
            fallingTrajectory = value;
        }
    }
    //Коробка может не знать про тип объекта, просто добавлять значение value, которое может быть отрицательным
    [SerializeField] private float value;
    public float Value() => value;

    private Vector2 flyingGoal;
    public Vector2 FlyingGoal
    {
        get
        {
            return flyingGoal;
        }

        set
        {
            flyingGoal = value;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator CurveMovement()
    {
        float currentTimePassed = 0f;
        Vector2 start = transform.position;

        while (currentTimePassed < duration && this != null)
        {
            currentTimePassed += Time.deltaTime;

            //По факту у нас получается значение от 0 до 1, которое можно использовать для получения позиции в графике AC в данный момент времени
            float linearTime = currentTimePassed / duration;
            float timeToCurve = fallingTrajectory.Evaluate(linearTime);

            float objectPositionX = Mathf.Lerp(0f, flyingGoal.x - start.x, timeToCurve);

            transform.position = Vector2.Lerp(start, flyingGoal, linearTime) + new Vector2(objectPositionX, 0f);
            yield return null;
        }
    }
}
