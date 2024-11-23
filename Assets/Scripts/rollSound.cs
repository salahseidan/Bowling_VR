using UnityEngine;

public class BallRollingSound : MonoBehaviour
{
    public AudioClip rollingSound;
    private AudioSource audioSource;
    private bool isRolling = false;
    private bool hasPlayed = false; 
    private Rigidbody rb;
    public float rollingThreshold; 

    // private int i; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // i = 3; 
        audioSource.clip = rollingSound;
        audioSource.loop = true; 
        audioSource.volume = 0.5f; 
        rb = GetComponent<Rigidbody>();
    }
    
    void Update ()
    {
        if (isRolling)
        {
            audioSource.pitch = rb.linearVelocity.magnitude / 5;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("WoodenGround"))
        {
            if (rb.linearVelocity.magnitude > rollingThreshold)
            {
                if (!isRolling && !audioSource.isPlaying && !hasPlayed)
                {
                    audioSource.Play();
                    isRolling = true;
                    hasPlayed = true; 
                }
            }
            else
            {
                if (isRolling)
                {
                    audioSource.Stop();
                    isRolling = false;
                    hasPlayed = false; 
                }
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("WoodenGround"))
        {
            audioSource.Stop();
            isRolling = false;
            hasPlayed = false; 
        }
    }
}