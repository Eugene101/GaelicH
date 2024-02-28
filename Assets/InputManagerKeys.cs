using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public class InputManagerKeys : MonoBehaviour
{

    void Update()
    {
        // Verificar si se presiona el bot�n A (bot�n de acci�n principal)
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("Bot�n A presionado");
        }

        // Verificar si se presiona el bot�n B (bot�n secundario)
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Debug.Log("Bot�n B presionado");
        }

        // Verificar si se presiona el bot�n X (bot�n secundario)
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("Bot�n X presionado");
        }

        // Verificar si se presiona el bot�n Y (bot�n secundario)
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Debug.Log("Bot�n Y presionado");
        }

        // Verificar si se presiona el gatillo izquierdo
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            Debug.Log("Gatillo izquierdo presionado");
        }

        // Verificar si se presiona el gatillo derecho
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            Debug.Log("Gatillo derecho presionado");
        }

        // Verificar si se presiona el bot�n de men�
        if (Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            Debug.Log("Bot�n de men� presionado");
        }
    }
}

