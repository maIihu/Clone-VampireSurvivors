using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    private Animator ani;
    private PlayerController playerController;
    void Start()
    {
        ani = GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ani.SetBool("CoolDown", !playerController.CanHeal);
    }
}
