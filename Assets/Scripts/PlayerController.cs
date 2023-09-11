using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float turnSpeed;

    void Start()
    {
        hp = 100;
        moveSpeed = 10f;
        turnSpeed = 45f;

        Debug.Log("MainPlayer Values : HP is " + hp + ", moveSpeed is " + moveSpeed + ", turnSpeed is " + turnSpeed);
    }
}
