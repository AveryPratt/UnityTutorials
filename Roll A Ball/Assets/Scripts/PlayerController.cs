using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody player;
    private int count;

    public Text CountText;
    public Text WinText;
    public float Speed;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        WinText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        player.AddForce(movement * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
        }
    }

    private void setCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if (count >= 4)
        {
            WinText.text = "You Win!";
        }
    }
}
