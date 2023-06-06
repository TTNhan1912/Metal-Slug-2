using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject Left, Right, Middle;
    public float speed, height;
    private Vector2 left, right, middle;
    public static bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
         left = Left.transform.position;
         right = Right.transform.position;
         middle = Middle.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    IEnumerator GoUp()
    {


        while (true)
        {
            Left.transform.position = new Vector2(
                Left.transform.position.x, Left.transform.position.y + speed * Time.deltaTime);
            if (Left.transform.position.y > left.y + height)
            {
                
                break;
            }
                
            yield return null;
        } 
        
        while (true)
        {
          Right.transform.position = new Vector2(
                Right.transform.position.x, Right.transform.position.y + speed * Time.deltaTime);
            if (Right.transform.position.y > right.y + height) break;
            yield return null;
        } 
        
        while (true)
        {
            Middle.transform.position = new Vector2(
                Middle.transform.position.x, Middle.transform.position.y + speed * Time.deltaTime);
            if (Middle.transform.position.y > middle.y + height) break;
            yield return null;
        }
        isPlaying = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GoUp());
        }
    }
}
