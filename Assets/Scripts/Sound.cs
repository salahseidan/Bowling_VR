using UnityEngine;

public class PinCollisionSound : MonoBehaviour
{
    public AudioClip collisionSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}