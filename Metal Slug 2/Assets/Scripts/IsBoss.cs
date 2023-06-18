using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBoss : MonoBehaviour
{
   // public GameObject isB;
    public static bool isBoss;
    // Start is called before the first frame update
    void Start()
    {
        isBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isBoss=true; 
            gameObject.SetActive(false);
        }
    }
}
