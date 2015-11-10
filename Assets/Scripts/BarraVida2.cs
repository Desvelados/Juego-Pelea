using UnityEngine;
using System.Collections;

public class BarraVida2 : MonoBehaviour
{
    public GUIStyle barraVida;
    public Texture2D imagenFondoP2;
    public Texture2D imagenFrentP2;
    public int healthPoints = 0;
    private bool vivo = true;
    void OnGUI()
    {
        //GUI.BeginGroup(new Rect(160, 100, 512, 20));
        GUI.BeginGroup(new Rect(650, 115, 512, 20));
        GUI.Box(new Rect(0, 0,512,20),imagenFondoP2,barraVida);
        
        GUI.BeginGroup(new Rect(0, 0, healthPoints, 20));
        //GUI.BeginGroup(new Rect(150, 90, healthPoints, 20));
        GUI.Box(new Rect(0, 0, 512, 20), imagenFrentP2, barraVida);

        GUI.EndGroup();
        GUI.EndGroup();
    }
    public void takeDamage(int cant)
    {
        if (vivo)
        {
            healthPoints += cant;
            if (healthPoints >= 100)
            {
                //dejo de restar cosas
                vivo = false;
            }
        }
    }
}