using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.Arm;

public class Dan_Boss : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        ani= GetComponent<Animator>();
        rigidbody2d= GetComponent<Rigidbody2D>();
        ani.Play("boss-3");
        ani.SetBool("IsDan", true);

    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}
