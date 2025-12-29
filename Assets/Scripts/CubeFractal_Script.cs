using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;

public class CubeFractal_Script : MonoBehaviour
{
    GameObject cube;
    Vector3 Per_cube_Position;
    Vector3 Scale;
    public int iterations = 2;
    List<GameObject> All_Cubes = new List<GameObject>();
    Renderer r;
    Color c;
    void Start()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        r = cube.GetComponent<Renderer>();
        c = UnityEngine.Random.ColorHSV();
        //r.material.color ;

        GenerateFractal(new Vector3(0, 0, 0), new Vector3(1, 1, 1), iterations);
    }

    void GenerateFractal(Vector3 position, Vector3 scale, int depth)
    {
        if (depth == 0)
            return;
        //r.material.color = UnityEngine.Random.ColorHSV();
        Color depthColor = Color.Lerp(Color.blue, Color.red, depth / (float)iterations);
        float d = scale.x * 0.75f;
        GameObject cubes;
        cubes = Instantiate(cube, position + new Vector3(d, 0, 0), Quaternion.identity);
        cubes.transform.localScale = scale * 0.5f;
        All_Cubes.Add(cubes);
        cubes.GetComponent<Renderer>().material.color = depthColor;
        GenerateFractal(cubes.transform.position, cubes.transform.localScale, depth - 1);
        cubes = Instantiate(cube, position + new Vector3(0, d, 0), Quaternion.identity);
        cubes.transform.localScale = scale * 0.5f;
        All_Cubes.Add(cubes);
        cubes.GetComponent<Renderer>().material.color = depthColor;
        GenerateFractal(cubes.transform.position, cubes.transform.localScale, depth - 1);
        cubes = Instantiate(cube, position + new Vector3(0, 0, d), Quaternion.identity);
        cubes.transform.localScale = scale * 0.5f;
        All_Cubes.Add(cubes);
        cubes.GetComponent<Renderer>().material.color = depthColor;
        GenerateFractal(cubes.transform.position, cubes.transform.localScale, depth - 1);
        cubes = Instantiate(cube, position + new Vector3(-d, 0, 0), Quaternion.identity);
        cubes.transform.localScale = scale * 0.5f;
        All_Cubes.Add(cubes);
        cubes.GetComponent<Renderer>().material.color = depthColor;
        GenerateFractal(cubes.transform.position, cubes.transform.localScale, depth - 1);
        cubes = Instantiate(cube, position + new Vector3(0, -d, 0), Quaternion.identity);
        cubes.transform.localScale = scale * 0.5f;
        All_Cubes.Add(cubes);
        cubes.GetComponent<Renderer>().material.color = depthColor;
        GenerateFractal(cubes.transform.position, cubes.transform.localScale, depth - 1);
        cubes = Instantiate(cube, position + new Vector3(0, 0, -d), Quaternion.identity);
        cubes.transform.localScale = scale * 0.5f;
        All_Cubes.Add(cubes);
        cubes.GetComponent<Renderer>().material.color = depthColor;
        GenerateFractal(cubes.transform.position, cubes.transform.localScale, depth - 1);

    }
    void Update()
    { }
}