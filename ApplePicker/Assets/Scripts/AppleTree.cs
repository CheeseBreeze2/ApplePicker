using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AppleTree : MonoBehaviour
{
    [Header("inscribed")]
    //Prefab for instantiating apples
    public GameObject applePrefab;

    //speed at which the AppleTree Moves
    public float speed = 1f;

    //Distance that the AppleTree will change directions
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change direction
    public float changeDirChance = 0.1f;

    //Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    void Start()
    {
        //Start dropping apples
        Invoke("DropApple", 2f);

    }

    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move Right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position; //place that apple right on the apple tree
        Invoke("DropApple", appleDropDelay);
    }
}
