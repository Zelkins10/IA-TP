using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class ClickingTest : MonoBehaviour
{
    private PlayerController player_controller;
    private int z;
    private int i;

    public void set_coord(PlayerController PC, int Cz, int Ci)
    {
        player_controller = PC;
        z = Cz;
        i = Ci;
    }

    void OnMouseDown()
    {
        player_controller.disactivate_cube(z, i);
    }
}
