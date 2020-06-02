using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestCollision : MonoBehaviour
{
    public Animator animatorLift;
    public Animator kosmonautas;
    // Start is called before the first frame update
    void Start()
    {
        animatorLift.enabled = true;
        animatorLift.SetBool("AnimatorLift", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        animatorLift.SetBool("AnimatorLift", true);

        kosmonautas = other.GetComponent<Animator>();
        kosmonautas.SetBool("gynyba", true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision ended");
        animatorLift.SetBool("AnimatorLift", false);
        kosmonautas.SetBool("gynyba", false);
    }
}
