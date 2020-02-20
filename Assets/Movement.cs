using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Movement : MonoBehaviour
{
    public float speed;
    public float clampLeft;
    public float clampRight;
    public Rigidbody2D rb;
    public int jumpForce;
    private GameObject[] PowerUp;
    private int count;
    public GameObject enemy;
    public GameObject player;
    private Renderer rend;
    private Color colorToTurnTo = Color.magenta;
    public Text cover1;
    public Text cover2;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        PowerUp = GameObject.FindGameObjectsWithTag("PowerUp");
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * 3f * Time.deltaTime, 0f, 0f);
        Vector3 character = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            character.x = -1;

        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            character.x = 1;
        }
        transform.localScale = character;


        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) 
        {
            if (rb && Mathf.Abs(rb.velocity.y) < 0.05f)
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("PowerUp"))
        {
            collider.gameObject.SetActive(false);
            count++;
            rend.material.color = colorToTurnTo;
            cover1.text = "Destruyelo!";
            cover2.text = "Destruyelo!";
            //collider.gameObject.CompareTag("Enemy");
            //collider.gameObject.SetActive(false);
            // Destroy(enemy);





        }
        else if (collider.gameObject.CompareTag("Enemy"))
        {
            //SceneManager.LoadScene("DemoScene");
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (count == 0)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                SceneManager.LoadScene("MyWorld");

            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
        
    }



}
