using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayAbleController : MonoBehaviour
{
    public Animator animator;
    public EnemyControl enemyControl;
    private void Start()
    {
        animator.Play("Idle", 0,0);
        enemyControl.enabled = true;
        enemyControl.gameObject.GetComponent<CharacterController>().enabled = true;
        //enemyControl.controller.enabled = true;

        Debug.Log("123");
    }
    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            animator.applyRootMotion = true;
        else
            return;
    }
    public void onStart(float theValue)
    {
        Debug.Log("PrintFloat is called with a value of " + theValue);
    }
}
