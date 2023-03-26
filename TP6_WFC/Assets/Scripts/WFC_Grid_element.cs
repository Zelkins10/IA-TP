using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFC_Grid_element : MonoBehaviour
{
    public int value = -1;
    public List<int> possible_terrains = new List<int>();
    public Dictionary<int, WFC_Grid_element> list_of_neighbors =
        new Dictionary<int, WFC_Grid_element>();
}
