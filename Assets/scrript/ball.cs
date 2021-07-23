using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] paddle paddle;
    [SerializeField] AudioClip[] ballAudioClip;
    [SerializeField] float randomFactor;
    //state variables
    Vector2 paddletoballvector;
    bool hasStarted = false;
    //cached references
    Rigidbody2D rb;
    AudioSource ballAudio;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ballAudio=  GetComponent<AudioSource>();

    }
    void Start()
    {
        paddletoballvector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lockballtopaddle();
        LaunchBallOnClick();
    }

    private void lockballtopaddle()
    {
        if (!hasStarted)
        {
            Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            transform.position = paddlePos + paddletoballvector;
        }
        
    }
    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0)&&(!hasStarted))
        {
            hasStarted = true;
            rb.velocity = new Vector2 (5f, 15f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float randomfactorX = Random.Range(-randomFactor, randomFactor);
        float randomfactory = Random.Range(-randomFactor, randomFactor);
        Vector2 velocityTweak = new Vector2(randomfactorX, randomfactory);
        if (hasStarted)
        {
            AudioClip clips = ballAudioClip[Random.Range(0, ballAudioClip.Length)];
            ballAudio.PlayOneShot(clips);
            rb.velocity += velocityTweak;
            
        }
        
    }
}
