using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PrisonerScript : MonoBehaviour
{
    private Animator ani;
    //public Player playerCharacter;
    private bool isCollideNPC/*, isRescued*/;
    private Vector2 originalPosition;
    public GameObject ammo, item, item1;
    private bool reward = false;

    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        //playerCharacter = GetComponent<Player>();
        ani = GetComponent<Animator>();
        originalPosition = transform.position;
        //isRescued = false;
        isRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (isCollideNPC)
            {
                ani.SetBool("isRescue", true);
                ani.SetBool("isReward", true);
                StartCoroutine(DropItem());  
                //isRescued =true;
            }

        }

        //if(isRescued)
        //{
        //    Vector3 vector3;
        //    if (isRight)
        //    {
        //        StartCoroutine(WaitForEscape());
        //        ani.SetBool("isRunAway", true);
        //        Vector2 scale = transform.localScale;
        //        scale.x *= scale.x > 0 ? -1 : 1;
        //        transform.localScale = scale;
        //        vector3 = new Vector3(1, 0, 0);
        //    }
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollideNPC = true;
        }
    }

    IEnumerator DropItem()
    {
        yield return new WaitForSeconds(1);
        GameObject newItem;
        int random = Random.Range(0, 3);
        if (random == 1)
            newItem = Instantiate<GameObject>(ammo);
        else if (random == 2)
            newItem = Instantiate<GameObject>(item);
        else if (random == 3)
            newItem = Instantiate<GameObject>(item1);
        else
            newItem = Instantiate<GameObject>(ammo);
        newItem.transform.position = new Vector2(
        transform.position.x + 2f,
        transform.position.y);
        yield return null;  
    }


    //IEnumerator WaitForEscape()
    //{
    //    yield return new WaitForSeconds(5);
    //    yield return null;
    //}
}
