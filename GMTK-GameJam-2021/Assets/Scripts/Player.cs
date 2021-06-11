using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var direction = new Vector2(x, y);

        Move(direction);
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    void Move(Vector2 direction)
    {
        //Find the screen limits to the player's movement
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        //Get the player's current position
        Vector2 pos = transform.position;
        //Calculate the proposed position
        pos += direction * speed * Time.deltaTime;
        //Ensure that the proposed position isn't outside of the limits
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        //Update the player's position
        transform.position = pos;
    }

}
