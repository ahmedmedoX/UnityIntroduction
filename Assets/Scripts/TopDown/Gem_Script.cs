using UnityEngine;
public class Gem_Script : MonoBehaviour
{
    void Awake()
    {
        this.GetComponent<Animator>().SetBool("Blue", Random.value > 0.5f);
    }
}