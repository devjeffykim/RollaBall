using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI speedText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public GameObject userNameObject;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        speed = 5;
        
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        userNameObject.SetActive(true);
        SetCountText();
        SetSpeedText();
    }

    private void OnMove(InputValue movementValue)
    {
        //function body
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count > 11)
        {
            winTextObject.SetActive(true);
        }


    }
    void SetSpeedText()
    {
        speedText.text = "Speed: " + speed.ToString();
        if (count < 11 && speed <= 0)
        {
            loseTextObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //SetSpeed();
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
        if (other.gameObject.CompareTag("SpeedBoost"))
        {
            speed+=5;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Slow"))
        {
            speed-=2;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("SlowPool"))
        {
            speed -= 3;
        }
        SetCountText();
        SetSpeedText();
    }
}
