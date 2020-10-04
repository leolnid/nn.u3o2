using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        fallSpeed = 0;
        BallController[] balloons = GameObject.FindObjectsOfType<BallController>();

        foreach (var b in balloons)
        {
            b.blowEvent.AddListener(BalloonsHasBlown);
        }
    }

    public void BalloonsHasBlown()
    {
        Debug.Log("Game Over");
        fallSpeed += 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }
}