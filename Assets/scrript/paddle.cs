using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    [SerializeField] int world = 13;
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 13f;
    //cached references
    ball ball;
    gameStatus gameStatus;
    private void Awake()
    {
        ball = FindObjectOfType<ball>();
        gameStatus = FindObjectOfType<gameStatus>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        
        Vector2 paddlePos = new Vector2(GetXPos(), transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }
    private float GetXPos()
    {
        if (gameStatus.isAutoPlay())
        {
            return ball.transform.position.x;
        }
        else
        {
            float mousePos = Input.mousePosition.x / Screen.width * world;
            return mousePos;
            
        }
    }
}
