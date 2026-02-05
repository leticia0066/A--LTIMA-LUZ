using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (move > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (move < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
