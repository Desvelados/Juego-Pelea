using UnityEngine;


public class MenuScript : MonoBehaviour
{


    public Texture2D IMGboton;

    void OnGUI()
    {
        const int buttonWidth = 100;
        const int buttonHeight = 80;


        //Donde se posiciona el boton
        Rect buttonRect = new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            );
        
        //Creo el boton (pedorro)
        if (GUI.Button(buttonRect,IMGboton))
        {
            //Haciendo click arranca el jueguito
            Application.LoadLevel("Escena1");
        }
    }
}