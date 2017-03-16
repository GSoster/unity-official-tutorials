using UnityEngine;
using System.Collections;
using UnityEngine.UI; //namespace for UI components
public class PlayerController : MonoBehaviour
{
    public const int MAX_COLLECTABLE_OBJECTS = 12;

    public float speed;
    public Text countText;//ui element
    public Text winText;//ui element

    private Rigidbody rb;
    private int count;//points that the player has picked up

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            //Destroy(other.gameObject);//we don't want to destroy it, just inativate
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= MAX_COLLECTABLE_OBJECTS)
        {
            winText.text = "You Win!";
        }
    }

}