using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject objectToInstantiate;
    private Vector3 lastPosition;
    private float distanceMoved = 0f;
    public GameObject[] seasons;
    private float number = 1;
    private int heartsCollected = 0;
    private int totalheartsInGame = 0;
    public TMP_Text heartText;

    void Start()
    {
        // Initialize the last position
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the arrow keys
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(-moveY, 0, moveX);

        // Normalize the movement vector to ensure consistent speed in all directions
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        // Move the object
        transform.Translate(movement);

        // Update the distance moved
        distanceMoved += Mathf.Abs(transform.position.z - lastPosition.z);
        lastPosition = transform.position;
        for (int i = 1; i <= seasons.Length - 1; i++){
            if(seasons[i].gameObject.activeSelf){
                number = i;
            }
        }
        // Check if the player has moved 5 units forward
        if (distanceMoved >= 5f)
        {
            // Reset the distance moved
            distanceMoved = 0f;
            float randomX = Random.Range(-2f, 2f);
            float randomY = Random.Range(-2f, 2f);
            float randomZ = Random.Range(transform.position.z + 15, transform.position.z + 30);
        if (number == 2){
        randomX = Random.Range(-5f, 5f);
         randomY = Random.Range(-5f, 5f);
         randomZ = Random.Range(transform.position.z + 12, transform.position.z + 26);
        }
        if (number == 3){
        randomX = Random.Range(-8f, 8f);
        randomY = Random.Range(-8f, 8f);
        randomZ = Random.Range(transform.position.z + 12, transform.position.z + 24);
        }
        if (number == 4){
        randomX = Random.Range(-8f, 8f);
        randomY = Random.Range(-8f, 8f);
        randomZ = Random.Range(transform.position.z + 9, transform.position.z + 19);
        }

        // Calculate the new position
        Vector3 randomPosition = new Vector3(transform.position.x + randomX, transform.position.y + randomY, randomZ);

        // Instantiate the heart at the new position
        Instantiate(objectToInstantiate, randomPosition, Quaternion.identity);
        totalheartsInGame++;
        }
        heartText.text = heartsCollected.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a specific tag or component (adjust as needed)
        if (collision.gameObject.CompareTag("Heart"))
        {
            // Increase the counter
            heartsCollected++;

            // Delete the collided object
            Destroy(collision.gameObject);

            // Optionally, perform other actions or logic here
        }
    }
}