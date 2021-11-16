using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 startingPosition;
    private Vector3 currentposition;
    private float speed = 3f;
    [SerializeField]private int oz; //One or Zero

    private void Start()
    {
        startingPosition = this.transform.position;
    }
    private void Update()
    {
        switch (oz)
        {
            case 0:
                currentposition = transform.localPosition;
                currentposition.z += speed * Time.deltaTime;
                transform.localPosition = currentposition;
                if (currentposition.z > startingPosition.z + 2f)
                    oz = 1;
                break;
            case 1:
                currentposition = transform.localPosition;
                currentposition.z -= speed * Time.deltaTime;
                transform.localPosition = currentposition;
                if (currentposition.z < startingPosition.z - 2f)
                    oz = 0;
                break;
        }


    }
}
