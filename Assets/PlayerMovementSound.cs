using UnityEngine;

public class PlayerMovementSound : MonoBehaviour
{
    public AudioSource audioSource;  // Attach the audio source in the inspector
    public AudioClip movementSound;  // Assign your sound clip here
    public float soundInterval = 0.5f;  // Time between each sound in seconds

    private float timeSinceLastSound = 0f;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Set the clip and make sure it doesn't play on awake
        if (audioSource != null)
        {
            audioSource.clip = movementSound;
            audioSource.playOnAwake = false;
        }
    }

    void Update()
    {
        bool isMoving = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f;

        if (isMoving && timeSinceLastSound >= soundInterval)
        {
            audioSource.PlayOneShot(movementSound);
            timeSinceLastSound = 0f;
        }

        timeSinceLastSound += Time.deltaTime;
    }
}
