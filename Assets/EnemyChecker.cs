using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public Animator animator;
    PlayerControls playerControls;
    public GameObject deathScreen;
    enum DeadTypes
    {
        Runner = 1,
        Trap,       // 2 
        Axe
    }
    private void Awake()
    {
        playerControls = gameObject.GetComponent<PlayerControls>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.collider.gameObject;
        if( gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
           animator.SetBool("dead", true);
            switch (gameObject.tag)
            {
                case "Trap":  animator.SetInteger("deadType", (int)DeadTypes.Trap); 
                    break;
                case "Runner": 
                    animator.SetInteger("deadType", (int)DeadTypes.Runner);
                    animator.Play("Fly Back");

                    playerControls.speed = 0;
                    break;
                case "Axe": 
                    animator.SetInteger("deadType", (int)DeadTypes.Axe);
                    animator.Play("Standing Death");
                   
                    break;
            }
            playerControls.isDead = true;
            deathScreen.SetActive(true);
            //Stop Player;
        }
    }

}
