using System;
using UnityEngine;

public class triggerEnterEvent : MonoBehaviour
{
    public string targetTag;
    public GameObject targetObject;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision !=null && collision.CompareTag(targetTag))
        {
            Debug.Log("enter"+collision.name);
            targetObject.SetActive(true);
            
            this.enabled = false;
        }
    }

}
