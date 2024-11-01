using UnityEngine;

public class BallRollingSound : MonoBehaviour
{
    public AudioClip rollingSound;
    private AudioSource audioSource;
    private bool isRolling = false;
    private bool hasPlayed = false; // Flag to track if the sound has been played
    private Rigidbody rb;
    public float rollingThreshold = 0.3f; // Adjust this value as needed

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = rollingSound;
        audioSource.loop = true; // Loop the rolling sound
        audioSource.volume = 0.3f; // Set the volume of the rolling sound
        rb = GetComponent<Rigidbody>();
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
                    hasPlayed = true; // Set the flag to true once the sound is played
                }
            }
            else
            {
                if (isRolling)
                {
                    audioSource.Stop();
                    isRolling = false;
                    hasPlayed = false; // Reset the flag when the ball stops rolling
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
            hasPlayed = false; // Reset the flag when the ball leaves the ground
        }
    }
}