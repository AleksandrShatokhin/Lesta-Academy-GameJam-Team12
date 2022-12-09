using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //При столкновении с объектом проверять его тип, и взависимости от него добавлять или убирать очки
        if (other.GetComponent<FallingItem>() != null)
        {
            gameManager.Score += other.GetComponent<FallingItem>().Value();
            Debug.Log(gameManager.Score);
            Destroy(other.gameObject);
        }
    }
}
