using UnityEngine;
public class Score_Script : MonoBehaviour
{
    int Score = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Score++;
            Debug.Log(Score);
            collision.gameObject.SetActive(false);
        }
    }
}