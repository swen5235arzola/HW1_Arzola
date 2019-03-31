using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidBody;
    private int count = 0;
    public Text countText;
    public Text winText;

    // Start is called before the first frame update
    private void Start()
    {
        this.rigidBody = GetComponent<Rigidbody>();
        SetCountText();
    }



    // Update is called once per frame
    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        AddForceToPlayer(movement);
    }

    /// <summary>
    /// moves player around board
    /// </summary>
    /// <param name="movement"></param>
    private void AddForceToPlayer(Vector3 movement)
    {
        rigidBody.AddForce(movement * this.speed);
    }

    /// <summary>
    /// Disables collectable objects and increments count 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            this.count++;
            SetCountText();
        }
    }

    /// <summary>
    /// Sets Games Count Text Value
    /// </summary>
    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (this.count >= 12)
            winText.text = "You Win!";
    }
}
