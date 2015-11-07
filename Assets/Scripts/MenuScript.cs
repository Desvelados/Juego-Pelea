using UnityEngine;


public class MenuScript : MonoBehaviour
{
    void OnGUI()
    {
        const int buttonWidth = 84;
        const int buttonHeight = 60;

        //Donde se posiciona el boton
        Rect buttonRect = new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            );

        //Creo el boton (pedorro)
        if (GUI.Button(buttonRect, "Start!"))
        {
            //Haciendo click arranca el jueguito
            Application.LoadLevel("Escena1");
        }
    }
}