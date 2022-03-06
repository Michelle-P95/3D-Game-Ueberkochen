using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    private Vector2 movementInput;
    private Animator anim;
    private GameMenu gameMenu;
    private bool pauseBool;

    private void Start(){
        anim = GetComponent<Animator>();
        gameMenu = GameObject.FindGameObjectWithTag("UITag").GetComponent<GameMenu>();
    }

    void FixedUpdate(){
        PlayerMovement();
        if(pauseBool){
            PauseGame();
        }
    }

    void PlayerMovement(){
        float ver = movementInput.x;
        float hor = movementInput.y;
        Vector3 playerMovement = new Vector3(hor, 0f, -ver);
        playerMovement.Normalize();

        if (playerMovement != Vector3.zero) {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        transform.Translate(playerMovement * speed * Time.deltaTime, Space.World);

        if (playerMovement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerMovement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    public void OnPause(InputAction.CallbackContext ptx) => pauseBool = ptx.ReadValueAsButton();

    void PauseGame(){
        gameMenu.PauseMenu();
    }
}
