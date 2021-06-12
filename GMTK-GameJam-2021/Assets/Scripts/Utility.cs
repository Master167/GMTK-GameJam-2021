using UnityEngine;

public static class Utility
{
    /// <summary>
    /// Move the transform in the direction with the provided speed.
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="transform"></param>
    /// <param name="speed"></param>
    public static void Move(Vector2 direction, Transform transform, float speed)
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
