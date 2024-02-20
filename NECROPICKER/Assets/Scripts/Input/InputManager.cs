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
    GrabHandler grabHandler;
    // bool usingController;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
        grabHandler = GetComponentInChildren<GrabHandler>();
        itemHandler = GetComponentInChildren<ItemHandler>();
        pointer = GetComponentInChildren<Pointer>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementController.Move(context.ReadValue<Vector2>());
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        if(context.started)
            itemHandler.UseItem();
    }

    public void OnGrab(InputAction.CallbackContext context)
    {
        if(context.started)
            grabHandler.TakeItem();
    }

    public void OnScroll(InputAction.CallbackContext context)
    {
        if(context.ReadValue<Vector2>().y != 0)
        {
            int signo = (int)Mathf.Sign(context.ReadValue<Vector2>().y);
            inventory.SumToIndex(signo);
        }
    }

    public void SetPointerByMouseInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Vector2 pointer_direction = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()) - transform.position;
            pointer.SetPointer(pointer_direction);
        }
    }

    public void SetPointerByControllerInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            // usingController = true;
            Vector2 pointer_direction = context.ReadValue<Vector2>();
            pointer.SetPointer(pointer_direction);
        }
    }
}