using UnityEngine;

public class InstancingPlayer_Script : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        Vector2 Starting_Point = new Vector2(-30, 3);
        Quaternion Rotation = new Quaternion();
        Instantiate(player, Starting_Point, Rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
