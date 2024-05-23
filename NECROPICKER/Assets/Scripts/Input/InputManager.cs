using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    MovementController movementController;
    ItemHandler itemHandler;
    Pointer pointer;
    [SerializeField] Inventory inventory;
    [SerializeField] ItemHandler potionHandler;
    GrabHandler grabHandler;
    private void Awake()
    {
        movementController = GetComponent<MovementController>();
        grabHandler = GetComponentInChildren<GrabHandler>();
        itemHandler = GetComponentInChildren<ItemHandler>();
        pointer = GetComponentInChildren<Pointer>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementController.Move(context.ReadValue<Vector2>()); //Dependiendo del input que lea el mapa del inputsystem toma un vector de movimiento
        movementController.QuitParticules(); //Al dejar de moverse desactiva las partículas
    }
    public void OnUse(InputAction.CallbackContext context)
    {
        if (context.started) //Al pulsar el botón de lanzar objeto
            itemHandler.UseItem(); //Se utiliza el objeto que se tenga asignado
    }
    public void OnUsePotion(InputAction.CallbackContext context)
    {
        if (context.started) //Al pulsar el botón para curarse
            potionHandler.UseItem(); //Se utiliza la poción
    }
    public void OnGrab(InputAction.CallbackContext context)
    {
        if(context.started) //Al pulsar el botón de recoger objetos
            grabHandler.TakeItem(); //Se recoge el objeto 
    }
    public void OnDrop(InputAction.CallbackContext context)
    {
        if (context.started) //Al pulsar el botón de soltar objeto
            itemHandler.DropItem(); //Se suelta el objeto asignado
    }
    public void OnScroll(InputAction.CallbackContext context)
    {
        if(context.performed) //Si se pulsa el botón para cambiar de objeto en el inventario este se cambia dependiendo de si se ha pulsado el de ir a la izquierda o a la derecha
        {
            int signo = (int)Mathf.Sign(context.ReadValue<Vector2>().y);
            inventory.SumToIndex(signo);
        }
    }
    public void SetPointerByMouseInput(InputAction.CallbackContext context)
    {
        if(context.performed) //Si el mouse se mueve se coloca el pointer en la posición del mouse
        {
            Vector2 pointer_direction = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()) - transform.position;
            pointer.SetPointer(pointer_direction);
        }
    }
    public void SetPointerByControllerInput(InputAction.CallbackContext context)
    {
        if(context.performed) //Si el joystick se mueve se coloca el pointer en la posición en la que señala el joystick
        {
            Vector2 pointer_direction = context.ReadValue<Vector2>();
            pointer.SetPointer(pointer_direction);
        }
    }
}