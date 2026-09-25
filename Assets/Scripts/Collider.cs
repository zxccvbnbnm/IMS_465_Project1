using UnityEditor;
using UnityEngine;

public class Collider : MonoBehaviour
{
    private Moveable parentScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentScript = GetComponentInParent<Moveable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Player P = other.GetComponent<Player>();
            P.canGrab = true;
                parentScript.held = true;




        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Player P = other.GetComponent<Player>();
            P.canGrab = false;
            parentScript.held = false;
        }
    }

}
