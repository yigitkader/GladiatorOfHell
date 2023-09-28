using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorMoveScript : MonoBehaviour
{

    private CharacterController gladiatorController;

    private GladiatorAnimations gladiatorAnimations;

    public float movementSpeed = GladiatorModel.MOVEMENT_SPEED;
    public float gravity = GladiatorModel.GRAVITY;

    public float rotationSpeed = GladiatorModel.ROTATION_SPEED;

    public float rotationDegreesPerSecond = GladiatorModel.ROTATION_DEGREES_PER_SECOND;




    // Start is called before the first frame update
    void Start()
    {
        gladiatorController = GetComponent<CharacterController>();
        gladiatorAnimations = GetComponent<GladiatorAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        AnimateRun();
        AnimateWalkBack();
    }


    private void Move(){
        if(Input.GetAxis(Axis.VERTICAL_AXIS) >0){
            
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            gladiatorController.Move(moveDirection * movementSpeed * Time.deltaTime);
        }else if(Input.GetAxis(Axis.VERTICAL_AXIS) < 0){

            // Going backwards
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            gladiatorController.Move(moveDirection * movementSpeed * Time.deltaTime);
        }else{
            // if we dont have any input to move the character
            gladiatorController.Move(Vector3.zero);
        }
    }


    private void Rotate(){
        Vector3 rotationDirection = Vector3.zero;
        if(Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0){
            rotationDirection = transform.TransformDirection(Vector3.left);

        } 
        
        if(Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0){
            rotationDirection = transform.TransformDirection(Vector3.right);
        }

        if(rotationDirection != Vector3.zero){
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, 
                Quaternion.LookRotation(rotationDirection),
                rotationDegreesPerSecond * Time.deltaTime
            );
        }
    }


    void AnimateRun(){
        //Debug.Log(gladiatorController.velocity.sqrMagnitude);
        if(gladiatorController.velocity.sqrMagnitude != 0f && Input.GetAxis(Axis.VERTICAL_AXIS) > 0){
            gladiatorAnimations.Run(true);
        }else{
            gladiatorAnimations.Run(false);
        }
    }


    void AnimateWalkBack(){
        //Debug.Log(gladiatorController.velocity.sqrMagnitude);
        if(gladiatorController.velocity.sqrMagnitude != 0f && Input.GetAxis(Axis.VERTICAL_AXIS) < 0){
            gladiatorAnimations.WalkBack(true);
        }else{
            gladiatorAnimations.WalkBack(false);
        }
    }


}
