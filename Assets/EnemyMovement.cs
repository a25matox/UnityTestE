using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EnemyMovement : MonoBehaviour
{
    [Tooltip("The direction and speed of the movement. A value of (1,0,0) will move the object to the right at the speed of 1 m/s")]
    [SerializeField] private Vector3 velocity;

    public bool flipMovement =false;

    [Tooltip("Set to true if the object should start moving as soon as it is loaded into the scene. Set to false if you want to control when the object should start moving.")]
    [SerializeField] private bool activeOnStart;

    private Vector3 originalPosition;

    private bool active;
    public Health healthS;

    public float dam=1f;
    public string targetTag;
    public GameObject targetObject;
    
    // Awake is called before the first frame update
    void Awake()
    {
        GameObject.Find("Player").TryGetComponent<Health>(out healthS);
        originalPosition = transform.position;
        
        if (activeOnStart)
            StartMovement();
    }

    public bool flipRead = true;
    public IEnumerator readToFlip()
    {
        flipRead = false;
        yield return new WaitForSeconds(1);
        flipRead = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision !=null && collision.CompareTag(targetTag))
        {
            healthS.TakeDamage(dam);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision !=null && collision.CompareTag("Ground") && flipRead)
        {
            if (!flipMovement)
            {
                flipMovement=true;
                StartCoroutine(readToFlip());
            }
            else
            {
                flipMovement=false;
                StartCoroutine(readToFlip());
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        // update position of this object if the movement is active
        if (active &&flipMovement)
        {
            transform.position += (velocity * Time.deltaTime);
        }
        else
        {
            transform.position -= (velocity * Time.deltaTime);
        }
    }

    // Call this if you want to start moving the object
    public void StartMovement()
    {
        active = true;
    }

    // Call this if you want to stop moving the object (for example when it reaches a Trigger-collider).
    public void StopMovement()
    {
        active = false;
    }

    // Call this if you want to reset the object back to it's start-position
    public void ResetTransform(bool active = false)
    {
        transform.position = originalPosition;
        
        if (!this.active && active)
            StartMovement();
        else if (this.active && !active)
            StopMovement();
    }

    public void InvertVelocity()
    {
        velocity.x = -velocity.x;
        velocity.y = -velocity.y;
        velocity.z = -velocity.z;
    }
}
