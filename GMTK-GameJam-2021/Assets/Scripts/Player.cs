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

        Utility.Move(direction, transform, speed);
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    

}
