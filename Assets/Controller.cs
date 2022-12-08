using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
   
    [SerializeField] float speed = 2f;
    void Start()
    {
       PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
       MovePlayer();
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the game!");
        Debug.Log("Move your player with W, A, S, D");
        Debug.Log("Don't hit the walls!");
    }

    void MovePlayer()
    {
        var xValue = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var yValue = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(xValue, 0, yValue);
    }
}
