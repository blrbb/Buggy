using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] float defaultMoveSpeed = 30f;
    [SerializeField] float moveSpeed;
    
    void Start()
    {
        moveSpeed = defaultMoveSpeed;
    }

    void Update()
    {
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        
        transform.Translate(new Vector3(moveX,moveY,0));
    }
}
