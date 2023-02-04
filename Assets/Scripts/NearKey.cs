using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NearKey : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyNames();
    } 

    string KeyNames()
    {
        // From Q to P
        if (Input.GetKeyDown(KeyCode.Q))
        {
            return "W, A";
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            return "Q, A, S, E";
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            return "W, S, D, R";
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            return "E, D, F, T";
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            return "R, F, G, Y";
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            return "T, G, H, U";
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            return "Y, H, J, I";
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            return "U, J, K, O";
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            return "I, K, L, P";
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            return "O, L";
        }

        // From A to L
        else if (Input.GetKeyDown(KeyCode.A))
        {
            return "Q, W, S, Z";
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            return "W, A, Z, X, D, E";
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            return "E, R, F, C, X, S";
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            return "R, D, C, V, G, T";
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            return "T, Y, H, B, V, F";
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            return "Y, G, B, N, J, U";
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            return "U, H, N, M, K, I";
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            return "I, J, M, L, O";
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            return "O, K";
        }

        // From Z to M
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            return "A, S, X";
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            return "Z, S, D, C";
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            return "X, D, F, V";
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            return "C, F, G, B";
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            return "V, G, H, N";
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            return "B, H, J, M";
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            return "N, J, K";
        }

    return "Nie ma takich klawiszy";
    }
}
