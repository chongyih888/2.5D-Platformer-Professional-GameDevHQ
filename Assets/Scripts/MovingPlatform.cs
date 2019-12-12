using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;

    private float _speed = 1.0f;

    private bool _switching = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_switching == false)
        {
            //move to target b
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);

        }else if(_switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);

        }


        //if current position == targetB
        //go to targetA

        if (transform.position == _targetB.position)
        {
            _switching = true;

        } else if (transform.position == _targetA.position)
        {
            _switching = false;
        }
        
        //current transform = Vector3.Movetowards(current pos, target, )
        //go to point b
        //if at point b
        //go to point a
        //if at point a
        //go to point b

    }

    //collision detection with player
    //if we collide with player
    //take the player parent = this game object

    //exit collision
    //check if the player exited
    //take the player parent = null
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (other.tag == "Player")
        {
            if (player != null)
            {
                player.transform.parent = this.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (other.tag == "Player")
        {
            if (player != null)
            {
                player.transform.parent = null;
            }
        }
        
    }
}
