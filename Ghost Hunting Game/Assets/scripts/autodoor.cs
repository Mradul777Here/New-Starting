using UnityEngine;

public class autodoor : MonoBehaviour
{
    public Animator doorAnim;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetTrigger("Open");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetTrigger("Close");
        }
    }
}    