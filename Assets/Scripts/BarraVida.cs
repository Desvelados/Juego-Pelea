using UnityEngine;
using System.Collections;

public class BarraVida : MonoBehaviour
{
    public GUIStyle barraVida;
    public Texture2D imagenFondo;
    public Texture2D imagenFrent;
    public int healthPoints = 50;
    
    void OnGUI()
    {
        //GUI.BeginGroup(new Rect(160, 100, 512, 20));
        GUI.BeginGroup(new Rect(10, 10, 512, 20));
        GUI.Box(new Rect(0, 0,512,20),imagenFondo,barraVida);
        
        GUI.BeginGroup(new Rect(0, 0, healthPoints, 20));
        //GUI.BeginGroup(new Rect(150, 90, healthPoints, 20));
        GUI.Box(new Rect(0, 0, 512, 20), imagenFrent, barraVida);

        GUI.EndGroup();
        GUI.EndGroup();
    }
    void takeDamage(int cant)
    {
        healthPoints += cant;
        if(healthPoints >= 100)
        {
            //me mori
        }
    }
}