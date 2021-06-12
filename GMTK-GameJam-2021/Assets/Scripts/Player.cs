using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public GameObject Sword;
    private bool canSwingSword;
    // Start is called before the first frame update
    void Start()
    {
        canSwingSword = true;
        Sword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");// TODO - Move to Input.System https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Installation.html
        var y = Input.GetAxis("Vertical");

        var direction = new Vector2(x, y);

        Utility.Move(direction, transform, speed);

        if (Input.GetButton("Jump"))
        {
            SwingSword();
        }
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    private void SwingSword()
    {
        if (canSwingSword)
        {
            Debug.Log("Swinging Sword");
            Sword.SetActive(true);
            Invoke(nameof(EnableSword), 1);
            canSwingSword = false;
        }
    }

    void EnableSword()
    {
        canSwingSword = true;
    }

}
