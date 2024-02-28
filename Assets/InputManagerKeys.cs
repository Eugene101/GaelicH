using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public class InputManagerKeys : MonoBehaviour
{

    void Update()
    {
        // Verificar si se presiona el botón A (botón de acción principal)
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("Botón A presionado");
        }

        // Verificar si se presiona el botón B (botón secundario)
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Debug.Log("Botón B presionado");
        }

        // Verificar si se presiona el botón X (botón secundario)
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("Botón X presionado");
        }

        // Verificar si se presiona el botón Y (botón secundario)
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Debug.Log("Botón Y presionado");
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

        // Verificar si se presiona el botón de menú
        if (Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            Debug.Log("Botón de menú presionado");
        }
    }
}

