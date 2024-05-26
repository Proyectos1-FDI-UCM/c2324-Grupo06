using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script controla las animaciones del menú en respuesta a cambios en el estado global del juego,
//utilizando eventos del gestor global del estado para determinar cuándo mostrar u ocultar el menú.
public class MenuAnimatorController : MonoBehaviour
{
    [SerializeField] string PopUp;
    [SerializeField] string PopDown;
    [SerializeField] GlobalStateManager _global;
    AnimationPlayer _myAnim;

    private void Awake()
    {
        _myAnim = GetComponent<AnimationPlayer>();
        _global.OnPause.AddListener(() => Play(PopUp));
        _global.OnMinimap.AddListener(() => Play(PopUp));
        _global.OnResume.AddListener(() => Play(PopDown));
    }
    public void Play(string animation)
    {
        _myAnim.PlayAnimation(animation);
    }
}
