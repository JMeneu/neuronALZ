using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollisionHandler: MonoBehaviour
{
    private List<ICollisionHandler> _gameCollisions= new List<ICollisionHandler>();
    private static int _counter = 0;
    private static int _counterLimit = 0;
    private static float _timer = 60f;



    private void Awake(){
        _gameCollisions.Add(GetComponent<ShapesCollision>());
        _gameCollisions.Add(GetComponent<PuzzleCollision>());
        _gameCollisions.Add(GetComponent<LaberinthCollision>());
    }

    public void Collision(GameObject _otherObject, Collider2D _collider, string _game)
    {
        if (_game == "Shapes")
        {
            _counterLimit = SceneManagerPro.GetParameters("parameter")*4;
            Debug.Log(_counterLimit);
            _counter += _gameCollisions[0].Collision(_otherObject, _collider);
        }
        if (_game == "Puzzle")
        {
            _counterLimit = 12;
            _counter += _gameCollisions[1].Collision(_otherObject, _collider);
        }
        if (_game == "Laberinth")
        {
            _counter= _gameCollisions[2].Collision(_otherObject, _collider);
        }
    }
    public bool CounterCheck()
    {
        if (_counter == _counterLimit)
        {
            _counter=0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int CollisionCheck()
    {
        if (_counter == 1)
        {
            _counter=0;
            return 1;
        }
        else if(_counter==-1)
        {
            _counter=0;
            return -1;
        }
        else
        {
            _counter=0;
            return 0;
        }
    }

    public void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            // if(_flag)
            // {
            //     Debug.Log("Yess");
            //     Score.instance.final_score = 0;
            //     _flag=false;
            // }
            // else
            // {
                Score.instance.score = (int)_timer;
            //}  
        }
    }
}
