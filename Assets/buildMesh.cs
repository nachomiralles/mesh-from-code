using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildMesh : MonoBehaviour {

    public Vector3 vertLeftTopFront = new Vector3(-1, 1, 1);
    public Vector3 vertRightTopFront = new Vector3(1, 1, 1);
    public Vector3 vertRightTopBack = new Vector3(1, 1, -1);
    public Vector3 vertLeftTopBack = new Vector3(-1, 1, -1);

    private float waitN = 3f;
    private float waitD = 3f;
    public int shapeN = 0;

    void Start () {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;

        //VERTICES
        Vector3[] vertices = new Vector3[]
        {
            //cara Delantera
            vertLeftTopFront,//superior izquierda, 0
            vertRightTopFront,//superior derecha, 1
            new Vector3(-1,-1,1),//inferior izquierda, 2
            new Vector3(1,-1,1),//inferior derecha, 3

            //cara Trasera
            vertRightTopBack,//superior derecha, 4
            vertLeftTopBack,//superior izquierda, 5
            new Vector3(1,-1,-1),//inferior derecha, 6
            new Vector3(-1,-1,-1),//inferior izquierda, 7

            //Cara Izquierda
            vertLeftTopBack,//arriba detras 8
            vertLeftTopFront,//arriba delante 9
            new Vector3(-1,-1,-1),//debajo detras 10
            new Vector3(-1,-1,1),//debajo delante 11

            //Cara Derecha
            vertRightTopFront,//arriba delante 12
            vertRightTopBack,//arriba detras 13
            new Vector3(1,-1,1),//debajo delante 14
            new Vector3(1,-1,-1),//debajo detrás 15

            //Cara Superior
            vertLeftTopBack,//izquierda detras 16
            vertRightTopBack,//derecha detras 17
            vertLeftTopFront,//izquierda delante 18
            vertRightTopFront,//derecha delante 19

            //Cara Inferior
            new Vector3(-1,-1,1),//izquierda delante 20
            new Vector3(1,-1,1),//derecha delante 21
            new Vector3(-1,-1,-1),//izquierda detras 22
            new Vector3(1,-1,-1)//derecha detras 23


        };

        //TRIANGULOS 3 puntos, orden de las agujas del reloj definen que cara es visible
        int[] triangles = new int[]
        {
            //Cara delantera
            0,2,3,//primer triángulo
            3,1,0,//segundo triángulo

            //Cara trasera
            4,6,7,//primer triángulo
            7,5,4,//segundo triángulo

            //Cara izquierda
            8,10,11,//primer triángulo
            11,9,8,//segundo triángulo

            //Cara derecha
            12,14,15,//primer triángulo
            15,13,12,//segundo triángulo

            //Cara arriba
            16,18,19,//primer triángulo
            19,17,16,//segundo triángulo

            //Cara abajo
            20,22,23,//primer triángulo
            23,21,20//segundo triángulo
        };

        //UVs
        Vector2[] uvs = new Vector2[]
        {
            //Cara delantera. 0,0 es abajo izquierda; 1,1 es arriba derecha
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0)
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //mesh.uv = uvs;
        //mesh.Optimize();
        mesh.RecalculateNormals();

	}
	
	void Update () {
        if (waitN > 0f)
        {
            waitN -= Time.deltaTime;

        }
        else
        {
            waitN = waitD;
            shapeN++;
            if (shapeN > 3)
            {
                shapeN = 0;
            }
        }

        //morph to cube
        if(shapeN == 0)
        {
            vertLeftTopFront = Vector3.Lerp(vertLeftTopFront, new Vector3(-1,1,1), Time.deltaTime);
            vertRightTopFront = Vector3.Lerp(vertRightTopFront, new Vector3(1, 1, 1), Time.deltaTime);
            vertRightTopBack = Vector3.Lerp(vertRightTopBack, new Vector3(1, 1, -1), Time.deltaTime);
            vertLeftTopBack = Vector3.Lerp(vertLeftTopBack, new Vector3(-1, 1, -1), Time.deltaTime);
        }

        //morph to pyramid
        if (shapeN == 1)
        {
            vertLeftTopFront = Vector3.Lerp(vertLeftTopFront, new Vector3(0, 1, 0), Time.deltaTime);
            vertRightTopFront = Vector3.Lerp(vertRightTopFront, new Vector3(0, 1, 0), Time.deltaTime);
            vertRightTopBack = Vector3.Lerp(vertRightTopBack, new Vector3(0, 1, 0), Time.deltaTime);
            vertLeftTopBack = Vector3.Lerp(vertLeftTopBack, new Vector3(0, 1, 0), Time.deltaTime);
        }

        //morph to ramp
        if (shapeN == 2)
        {
            vertLeftTopFront = Vector3.Lerp(vertLeftTopFront, new Vector3(-1, -1, 2), Time.deltaTime);
            vertRightTopFront = Vector3.Lerp(vertRightTopFront, new Vector3(1, -1, 2), Time.deltaTime);
            vertRightTopBack = Vector3.Lerp(vertRightTopBack, new Vector3(1, 0.5f, -1), Time.deltaTime);
            vertLeftTopBack = Vector3.Lerp(vertLeftTopBack, new Vector3(-1, 0.5f, -1), Time.deltaTime);
        }

        //morph to roof
        if (shapeN == 3)
        {
            vertLeftTopFront = Vector3.Lerp(vertLeftTopFront, new Vector3(-1, 0.2f, 0), Time.deltaTime);
            vertRightTopFront = Vector3.Lerp(vertRightTopFront, new Vector3(1, 0.2f, 0), Time.deltaTime);
            vertRightTopBack = Vector3.Lerp(vertRightTopBack, new Vector3(1, 0.2f, 0), Time.deltaTime);
            vertLeftTopBack = Vector3.Lerp(vertLeftTopBack, new Vector3(-1, 0.2f, 0), Time.deltaTime);
        }

        Start();
    }
}
