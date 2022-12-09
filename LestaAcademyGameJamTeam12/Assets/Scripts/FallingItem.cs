using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    [SerializeField] private float flyingSpeed;

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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += ((Vector3)flyingGoal - transform.position).normalized * flyingSpeed * Time.deltaTime;
    }

    


}
