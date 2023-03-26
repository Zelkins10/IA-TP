using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Asset name conversion :
// Désert : M = 0;
// Forêt  : F = 1;
// Sable  : S = 2;

// Edge number correspondance :
// 0 = left; -> bot to top
// 1 = top; -> left to right
// 2 = bottom; -> bot to top
// 3 = right; -> left to right

public class WFC_Datas : MonoBehaviour
{
    public List<WFC_Terrain> list_of_terrains = new List<WFC_Terrain>();

    // private GameObject MMMM; // For center mountain.
    public GameObject FFFF1;
    public GameObject FFFF2;
    public GameObject FFFF3;
    public GameObject FFFF4;
    public GameObject FFFF5;
    public GameObject FFFF6;
    public GameObject FFFM;
    public GameObject FFMF;
    public GameObject FFMM;
    public GameObject FFSS;
    public GameObject FMFF;
    public GameObject FMFM;
    public GameObject FMMM;
    public GameObject FSFS;
    public GameObject FSSS;
    public GameObject MFFF;
    public GameObject MFMF;
    public GameObject MFMM;
    public GameObject MMFF;
    public GameObject MMFM;
    public GameObject MMMF;
    public GameObject SFSF;
    public GameObject SFSS;
    public GameObject SSFF;
    public GameObject SSFS;
    public GameObject SSSF;
    public GameObject SSSS1;
    public GameObject SSSS2;
    public GameObject SSSS3;
    public GameObject SSSS4;
    public GameObject FMSS;
    public GameObject FSMS;
    public GameObject MFSS;
    public GameObject MSFS;
    public GameObject SFSM;
    public GameObject SMSF;
    public GameObject SSFM;
    public GameObject SSMF;

    void Awake()
    {
        // WFC_Terrain terrain_0 = new WFC_Terrain();
        // terrain_0.id = 38;
        // terrain_0.terrain = MMMM;
        // terrain_0.list_of_edges = new List<Vector2>();
        // terrain_0.list_of_edges.Add(new Vector2(0, 0));
        // terrain_0.list_of_edges.Add(new Vector2(0, 0));
        // terrain_0.list_of_edges.Add(new Vector2(0, 0));
        // terrain_0.list_of_edges.Add(new Vector2(0, 0));
        // list_of_terrains.Add(terrain_0);

        WFC_Terrain terrain_1 = new WFC_Terrain();
        terrain_1.id = 0;
        terrain_1.terrain = FFFF1;
        terrain_1.list_of_edges = new List<Vector2>();
        terrain_1.list_of_edges.Add(new Vector2(1, 1));
        terrain_1.list_of_edges.Add(new Vector2(1, 1));
        terrain_1.list_of_edges.Add(new Vector2(1, 1));
        terrain_1.list_of_edges.Add(new Vector2(1, 1));
        list_of_terrains.Add(terrain_1);

        WFC_Terrain terrain_2 = new WFC_Terrain();
        terrain_2.id = 1;
        terrain_2.terrain = FFFF2;
        terrain_2.list_of_edges = new List<Vector2>();
        terrain_2.list_of_edges.Add(new Vector2(1, 1));
        terrain_2.list_of_edges.Add(new Vector2(1, 1));
        terrain_2.list_of_edges.Add(new Vector2(1, 1));
        terrain_2.list_of_edges.Add(new Vector2(1, 1));
        list_of_terrains.Add(terrain_2);

        WFC_Terrain terrain_3 = new WFC_Terrain();
        terrain_3.id = 2;
        terrain_3.terrain = FFFF3;
        terrain_3.list_of_edges = new List<Vector2>();
        terrain_3.list_of_edges.Add(new Vector2(1, 1));
        terrain_3.list_of_edges.Add(new Vector2(1, 1));
        terrain_3.list_of_edges.Add(new Vector2(1, 1));
        terrain_3.list_of_edges.Add(new Vector2(1, 1));
        list_of_terrains.Add(terrain_3);

        WFC_Terrain terrain_4 = new WFC_Terrain();
        terrain_4.id = 3;
        terrain_4.terrain = FFFF4;
        terrain_4.list_of_edges = new List<Vector2>();
        terrain_4.list_of_edges.Add(new Vector2(1, 1));
        terrain_4.list_of_edges.Add(new Vector2(1, 1));
        terrain_4.list_of_edges.Add(new Vector2(1, 1));
        terrain_4.list_of_edges.Add(new Vector2(1, 1));
        list_of_terrains.Add(terrain_4);

        WFC_Terrain terrain_5 = new WFC_Terrain();
        terrain_5.id = 4;
        terrain_5.terrain = FFFF5;
        terrain_5.list_of_edges = new List<Vector2>();
        terrain_5.list_of_edges.Add(new Vector2(1, 1));
        terrain_5.list_of_edges.Add(new Vector2(1, 1));
        terrain_5.list_of_edges.Add(new Vector2(1, 1));
        terrain_5.list_of_edges.Add(new Vector2(1, 1));
        list_of_terrains.Add(terrain_5);

        WFC_Terrain terrain_6 = new WFC_Terrain();
        terrain_6.id = 5;
        terrain_6.terrain = FFFF6;
        terrain_6.list_of_edges = new List<Vector2>();
        terrain_6.list_of_edges.Add(new Vector2(1, 1));
        terrain_6.list_of_edges.Add(new Vector2(1, 1));
        terrain_6.list_of_edges.Add(new Vector2(1, 1));
        terrain_6.list_of_edges.Add(new Vector2(1, 1));
        list_of_terrains.Add(terrain_6);

        WFC_Terrain terrain_7 = new WFC_Terrain();
        terrain_7.id = 6;
        terrain_7.terrain = FFFM;
        terrain_7.list_of_edges = new List<Vector2>();
        terrain_7.list_of_edges.Add(new Vector2(1, 1));
        terrain_7.list_of_edges.Add(new Vector2(1, 1));
        terrain_7.list_of_edges.Add(new Vector2(0, 1));
        terrain_7.list_of_edges.Add(new Vector2(1, 0));
        list_of_terrains.Add(terrain_7);

        WFC_Terrain terrain_8 = new WFC_Terrain();
        terrain_8.id = 7;
        terrain_8.terrain = FFMF;
        terrain_8.list_of_edges = new List<Vector2>();
        terrain_8.list_of_edges.Add(new Vector2(0, 1));
        terrain_8.list_of_edges.Add(new Vector2(1, 1));
        terrain_8.list_of_edges.Add(new Vector2(1, 1));
        terrain_8.list_of_edges.Add(new Vector2(0, 1));
        list_of_terrains.Add(terrain_8);

        WFC_Terrain terrain_9 = new WFC_Terrain();
        terrain_9.id = 8;
        terrain_9.terrain = FFMM;
        terrain_9.list_of_edges = new List<Vector2>();
        terrain_9.list_of_edges.Add(new Vector2(0, 1));
        terrain_9.list_of_edges.Add(new Vector2(1, 1));
        terrain_9.list_of_edges.Add(new Vector2(0, 1));
        terrain_9.list_of_edges.Add(new Vector2(0, 0));
        list_of_terrains.Add(terrain_9);

        WFC_Terrain terrain_10 = new WFC_Terrain();
        terrain_10.id = 9;
        terrain_10.terrain = FFSS;
        terrain_10.list_of_edges = new List<Vector2>();
        terrain_10.list_of_edges.Add(new Vector2(2, 1));
        terrain_10.list_of_edges.Add(new Vector2(1, 1));
        terrain_10.list_of_edges.Add(new Vector2(2, 1));
        terrain_10.list_of_edges.Add(new Vector2(2, 2));
        list_of_terrains.Add(terrain_10);

        WFC_Terrain terrain_11 = new WFC_Terrain();
        terrain_11.id = 10;
        terrain_11.terrain = FMFF;
        terrain_11.list_of_edges = new List<Vector2>();
        terrain_11.list_of_edges.Add(new Vector2(1, 1));
        terrain_11.list_of_edges.Add(new Vector2(1, 0));
        terrain_11.list_of_edges.Add(new Vector2(1, 0));
        terrain_11.list_of_edges.Add(new Vector2(1, 1));
        list_of_terrains.Add(terrain_11);

        WFC_Terrain terrain_12 = new WFC_Terrain();
        terrain_12.id = 11;
        terrain_12.terrain = FMFM;
        terrain_12.list_of_edges = new List<Vector2>();
        terrain_12.list_of_edges.Add(new Vector2(1, 1));
        terrain_12.list_of_edges.Add(new Vector2(1, 0));
        terrain_12.list_of_edges.Add(new Vector2(0, 0));
        terrain_12.list_of_edges.Add(new Vector2(1, 0));
        list_of_terrains.Add(terrain_12);

        WFC_Terrain terrain_13 = new WFC_Terrain();
        terrain_13.id = 12;
        terrain_13.terrain = FMMM;
        terrain_13.list_of_edges = new List<Vector2>();
        terrain_13.list_of_edges.Add(new Vector2(0, 1));
        terrain_13.list_of_edges.Add(new Vector2(1, 0));
        terrain_13.list_of_edges.Add(new Vector2(0, 0));
        terrain_13.list_of_edges.Add(new Vector2(0, 0));
        list_of_terrains.Add(terrain_13);

        WFC_Terrain terrain_14 = new WFC_Terrain();
        terrain_14.id = 13;
        terrain_14.terrain = FSFS;
        terrain_14.list_of_edges = new List<Vector2>();
        terrain_14.list_of_edges.Add(new Vector2(1, 1));
        terrain_14.list_of_edges.Add(new Vector2(1, 2));
        terrain_14.list_of_edges.Add(new Vector2(2, 2));
        terrain_14.list_of_edges.Add(new Vector2(1, 2));
        list_of_terrains.Add(terrain_14);

        WFC_Terrain terrain_15 = new WFC_Terrain();
        terrain_15.id = 14;
        terrain_15.terrain = FSSS;
        terrain_15.list_of_edges = new List<Vector2>();
        terrain_15.list_of_edges.Add(new Vector2(2, 1));
        terrain_15.list_of_edges.Add(new Vector2(1, 2));
        terrain_15.list_of_edges.Add(new Vector2(2, 2));
        terrain_15.list_of_edges.Add(new Vector2(2, 2));
        list_of_terrains.Add(terrain_15);

        WFC_Terrain terrain_16 = new WFC_Terrain();
        terrain_16.id = 15;
        terrain_16.terrain = MFFF;
        terrain_16.list_of_edges = new List<Vector2>();
        terrain_16.list_of_edges.Add(new Vector2(1, 0));
        terrain_16.list_of_edges.Add(new Vector2(0, 1));
        terrain_16.list_of_edges.Add(new Vector2(1, 1));
        terrain_16.list_of_edges.Add(new Vector2(1, 1));
        list_of_terrains.Add(terrain_16);

        WFC_Terrain terrain_17 = new WFC_Terrain();
        terrain_17.id = 16;
        terrain_17.terrain = MFMF;
        terrain_17.list_of_edges = new List<Vector2>();
        terrain_17.list_of_edges.Add(new Vector2(0, 0));
        terrain_17.list_of_edges.Add(new Vector2(0, 1));
        terrain_17.list_of_edges.Add(new Vector2(1, 1));
        terrain_17.list_of_edges.Add(new Vector2(0, 1));
        list_of_terrains.Add(terrain_17);

        WFC_Terrain terrain_18 = new WFC_Terrain();
        terrain_18.id = 17;
        terrain_18.terrain = MFMM;
        terrain_18.list_of_edges = new List<Vector2>();
        terrain_18.list_of_edges.Add(new Vector2(0, 0));
        terrain_18.list_of_edges.Add(new Vector2(0, 1));
        terrain_18.list_of_edges.Add(new Vector2(0, 1));
        terrain_18.list_of_edges.Add(new Vector2(0, 0));
        list_of_terrains.Add(terrain_18);

        WFC_Terrain terrain_19 = new WFC_Terrain();
        terrain_19.id = 18;
        terrain_19.terrain = MMFF;
        terrain_19.list_of_edges = new List<Vector2>();
        terrain_19.list_of_edges.Add(new Vector2(1, 0));
        terrain_19.list_of_edges.Add(new Vector2(0, 0));
        terrain_19.list_of_edges.Add(new Vector2(1, 0));
        terrain_19.list_of_edges.Add(new Vector2(1, 1));
        list_of_terrains.Add(terrain_19);

        WFC_Terrain terrain_20 = new WFC_Terrain();
        terrain_20.id = 19;
        terrain_20.terrain = MMFM;
        terrain_20.list_of_edges = new List<Vector2>();
        terrain_20.list_of_edges.Add(new Vector2(1, 0));
        terrain_20.list_of_edges.Add(new Vector2(0, 0));
        terrain_20.list_of_edges.Add(new Vector2(0, 0));
        terrain_20.list_of_edges.Add(new Vector2(1, 0));
        list_of_terrains.Add(terrain_20);

        WFC_Terrain terrain_21 = new WFC_Terrain();
        terrain_21.id = 20;
        terrain_21.terrain = MMMF;
        terrain_21.list_of_edges = new List<Vector2>();
        terrain_21.list_of_edges.Add(new Vector2(0, 0));
        terrain_21.list_of_edges.Add(new Vector2(0, 0));
        terrain_21.list_of_edges.Add(new Vector2(1, 0));
        terrain_21.list_of_edges.Add(new Vector2(0, 1));
        list_of_terrains.Add(terrain_21);

        WFC_Terrain terrain_22 = new WFC_Terrain();
        terrain_22.id = 21;
        terrain_22.terrain = SFSF;
        terrain_22.list_of_edges = new List<Vector2>();
        terrain_22.list_of_edges.Add(new Vector2(2, 2));
        terrain_22.list_of_edges.Add(new Vector2(2, 1));
        terrain_22.list_of_edges.Add(new Vector2(1, 1));
        terrain_22.list_of_edges.Add(new Vector2(2, 1));
        list_of_terrains.Add(terrain_22);

        WFC_Terrain terrain_23 = new WFC_Terrain();
        terrain_23.id = 22;
        terrain_23.terrain = SFSS;
        terrain_23.list_of_edges = new List<Vector2>();
        terrain_23.list_of_edges.Add(new Vector2(2, 2));
        terrain_23.list_of_edges.Add(new Vector2(2, 1));
        terrain_23.list_of_edges.Add(new Vector2(2, 1));
        terrain_23.list_of_edges.Add(new Vector2(2, 2));
        list_of_terrains.Add(terrain_23);

        WFC_Terrain terrain_24 = new WFC_Terrain();
        terrain_24.id = 23;
        terrain_24.terrain = SSFF;
        terrain_24.list_of_edges = new List<Vector2>();
        terrain_24.list_of_edges.Add(new Vector2(1, 2));
        terrain_24.list_of_edges.Add(new Vector2(2, 2));
        terrain_24.list_of_edges.Add(new Vector2(1, 2));
        terrain_24.list_of_edges.Add(new Vector2(1, 1));
        list_of_terrains.Add(terrain_24);

        WFC_Terrain terrain_25 = new WFC_Terrain();
        terrain_25.id = 24;
        terrain_25.terrain = SSFS;
        terrain_25.list_of_edges = new List<Vector2>();
        terrain_25.list_of_edges.Add(new Vector2(1, 2));
        terrain_25.list_of_edges.Add(new Vector2(2, 2));
        terrain_25.list_of_edges.Add(new Vector2(2, 2));
        terrain_25.list_of_edges.Add(new Vector2(1, 2));
        list_of_terrains.Add(terrain_25);

        WFC_Terrain terrain_26 = new WFC_Terrain();
        terrain_26.id = 25;
        terrain_26.terrain = SSSF;
        terrain_26.list_of_edges = new List<Vector2>();
        terrain_26.list_of_edges.Add(new Vector2(2, 2));
        terrain_26.list_of_edges.Add(new Vector2(2, 2));
        terrain_26.list_of_edges.Add(new Vector2(1, 2));
        terrain_26.list_of_edges.Add(new Vector2(2, 1));
        list_of_terrains.Add(terrain_26);

        WFC_Terrain terrain_27 = new WFC_Terrain();
        terrain_27.id = 26;
        terrain_27.terrain = SSSS1;
        terrain_27.list_of_edges = new List<Vector2>();
        terrain_27.list_of_edges.Add(new Vector2(2, 2));
        terrain_27.list_of_edges.Add(new Vector2(2, 2));
        terrain_27.list_of_edges.Add(new Vector2(2, 2));
        terrain_27.list_of_edges.Add(new Vector2(2, 2));
        list_of_terrains.Add(terrain_27);

        WFC_Terrain terrain_28 = new WFC_Terrain();
        terrain_28.id = 27;
        terrain_28.terrain = SSSS2;
        terrain_28.list_of_edges = new List<Vector2>();
        terrain_28.list_of_edges.Add(new Vector2(2, 2));
        terrain_28.list_of_edges.Add(new Vector2(2, 2));
        terrain_28.list_of_edges.Add(new Vector2(2, 2));
        terrain_28.list_of_edges.Add(new Vector2(2, 2));
        list_of_terrains.Add(terrain_28);

        WFC_Terrain terrain_29 = new WFC_Terrain();
        terrain_29.id = 28;
        terrain_29.terrain = SSSS3;
        terrain_29.list_of_edges = new List<Vector2>();
        terrain_29.list_of_edges.Add(new Vector2(2, 2));
        terrain_29.list_of_edges.Add(new Vector2(2, 2));
        terrain_29.list_of_edges.Add(new Vector2(2, 2));
        terrain_29.list_of_edges.Add(new Vector2(2, 2));
        list_of_terrains.Add(terrain_29);

        WFC_Terrain terrain_30 = new WFC_Terrain();
        terrain_30.id = 29;
        terrain_30.terrain = SSSS4;
        terrain_30.list_of_edges = new List<Vector2>();
        terrain_30.list_of_edges.Add(new Vector2(2, 2));
        terrain_30.list_of_edges.Add(new Vector2(2, 2));
        terrain_30.list_of_edges.Add(new Vector2(2, 2));
        terrain_30.list_of_edges.Add(new Vector2(2, 2));
        list_of_terrains.Add(terrain_30);

        WFC_Terrain terrain_31 = new WFC_Terrain();
        terrain_31.id = 30;
        terrain_31.terrain = FMSS;
        terrain_31.list_of_edges = new List<Vector2>();
        terrain_31.list_of_edges.Add(new Vector2(2, 1));
        terrain_31.list_of_edges.Add(new Vector2(1, 0));
        terrain_31.list_of_edges.Add(new Vector2(2, 0));
        terrain_31.list_of_edges.Add(new Vector2(2, 2));
        list_of_terrains.Add(terrain_31);

        WFC_Terrain terrain_32 = new WFC_Terrain();
        terrain_32.id = 31;
        terrain_32.terrain = FSMS;
        terrain_32.list_of_edges = new List<Vector2>();
        terrain_32.list_of_edges.Add(new Vector2(0, 1));
        terrain_32.list_of_edges.Add(new Vector2(1, 2));
        terrain_32.list_of_edges.Add(new Vector2(2, 2));
        terrain_32.list_of_edges.Add(new Vector2(0, 2));
        list_of_terrains.Add(terrain_32);

        WFC_Terrain terrain_33 = new WFC_Terrain();
        terrain_33.id = 32;
        terrain_33.terrain = MFSS;
        terrain_33.list_of_edges = new List<Vector2>();
        terrain_33.list_of_edges.Add(new Vector2(2, 0));
        terrain_33.list_of_edges.Add(new Vector2(0, 1));
        terrain_33.list_of_edges.Add(new Vector2(2, 1));
        terrain_33.list_of_edges.Add(new Vector2(2, 2));
        list_of_terrains.Add(terrain_33);

        WFC_Terrain terrain_34 = new WFC_Terrain();
        terrain_34.id = 33;
        terrain_34.terrain = MSFS;
        terrain_34.list_of_edges = new List<Vector2>();
        terrain_34.list_of_edges.Add(new Vector2(1, 0));
        terrain_34.list_of_edges.Add(new Vector2(0, 2));
        terrain_34.list_of_edges.Add(new Vector2(2, 2));
        terrain_34.list_of_edges.Add(new Vector2(1, 2));
        list_of_terrains.Add(terrain_34);

        WFC_Terrain terrain_35 = new WFC_Terrain();
        terrain_35.id = 34;
        terrain_35.terrain = SFSM;
        terrain_35.list_of_edges = new List<Vector2>();
        terrain_35.list_of_edges.Add(new Vector2(2, 2));
        terrain_35.list_of_edges.Add(new Vector2(2, 1));
        terrain_35.list_of_edges.Add(new Vector2(0, 1));
        terrain_35.list_of_edges.Add(new Vector2(2, 0));
        list_of_terrains.Add(terrain_35);

        WFC_Terrain terrain_36 = new WFC_Terrain();
        terrain_36.id = 35;
        terrain_36.terrain = SMSF;
        terrain_36.list_of_edges = new List<Vector2>();
        terrain_36.list_of_edges.Add(new Vector2(2, 2));
        terrain_36.list_of_edges.Add(new Vector2(2, 0));
        terrain_36.list_of_edges.Add(new Vector2(1, 0));
        terrain_36.list_of_edges.Add(new Vector2(2, 1));
        list_of_terrains.Add(terrain_36);

        WFC_Terrain terrain_37 = new WFC_Terrain();
        terrain_37.id = 36;
        terrain_37.terrain = SSFM;
        terrain_37.list_of_edges = new List<Vector2>();
        terrain_37.list_of_edges.Add(new Vector2(1, 2));
        terrain_37.list_of_edges.Add(new Vector2(2, 2));
        terrain_37.list_of_edges.Add(new Vector2(0, 2));
        terrain_37.list_of_edges.Add(new Vector2(1, 0));
        list_of_terrains.Add(terrain_37);

        WFC_Terrain terrain_38 = new WFC_Terrain();
        terrain_38.id = 37;
        terrain_38.terrain = SSMF;
        terrain_38.list_of_edges = new List<Vector2>();
        terrain_38.list_of_edges.Add(new Vector2(0, 2));
        terrain_38.list_of_edges.Add(new Vector2(2, 2));
        terrain_38.list_of_edges.Add(new Vector2(1, 2));
        terrain_38.list_of_edges.Add(new Vector2(0, 1));
        list_of_terrains.Add(terrain_38);

        foreach (WFC_Terrain terrain in list_of_terrains)
        {
            int count0 = 0,
                count1 = 0,
                count2 = 0;
            foreach (Vector2 edge in terrain.list_of_edges)
            {
                if (edge.x == 0)
                    count0++;
                else if (edge.x == 1)
                    count1++;
                else if (edge.x == 2)
                    count2++;
                if (edge.y == 0)
                    count0++;
                else if (edge.y == 1)
                    count1++;
                else if (edge.y == 2)
                    count2++;
            }
            terrain.environment = new EnvironmentParameters();
            terrain.environment.altitude = 400f + count0 * 200f - count1 * 25f - count2 * 50f;
            terrain.environment.humidity = count0 * 3f + count1 * 5f + count2 * 0f;
            terrain.environment.temperature = -count0 * 2f + count1 * 3f + count2 * 5f;
        }
    }
}
