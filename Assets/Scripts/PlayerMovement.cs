using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 2f;

    private bool flip = false;

    public SpriteRenderer sprite;

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.Q)) // Влево-вверх
        {
            movement += new Vector2(-1, 1).normalized;
            if (flip)
            {
                sprite.flipX = false;
                flip = false;
                GameObject b = GameObject.Find("basket");
                b.transform.position = new Vector3(b.transform.position.x - 0.87f, b.transform.position.y, b.transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.A)) // Влево-вниз
        {
            movement += new Vector2(-1, -1).normalized;
            if (flip)
            {
                sprite.flipX = false;
                flip = false;
                GameObject b = GameObject.Find("basket");
                b.transform.position = new Vector3(b.transform.position.x +-0.87f, b.transform.position.y, b.transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.E)) // Вправо-вверх
        {
            movement += new Vector2(1, 1).normalized;
            if (!flip)
            {
                sprite.flipX = true;
                flip = true;
                GameObject b = GameObject.Find("basket");
                b.transform.position = new Vector3(b.transform.position.x + 0.87f, b.transform.position.y, b.transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.D)) // Вправо-вниз
        {
            movement += new Vector2(1, -1).normalized;
            if (!flip)
            {
                sprite.flipX = true;
                flip = true;
                GameObject b = GameObject.Find("basket");
                b.transform.position = new Vector3(b.transform.position.x + 0.87f, b.transform.position.y, b.transform.position.z);
            }
        }

        transform.Translate(movement * speed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
    

}
