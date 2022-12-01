using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionChecker : MonoBehaviour
{
    [SerializeField]
    private Text _game;
    private string _aux;
    private CollisionHandler _collisionHandler;
    private DatabaseModule _module;
    private SceneModule _sceneModule;
    private StoreModule _storeModule;
    private bool _isDone=false;
    private static float _timer = 60f;

    private void Awake()
    {
        _module= GetComponent<DatabaseModule>();
        _sceneModule= GetComponent<SceneModule>();
        _storeModule= GetComponent<StoreModule>();
        _collisionHandler= GetComponent<CollisionHandler>();

    }
    private void Start()
    {
        _aux= _game.GetComponent<UnityEngine.UI.Text>().text;
    }
    private void Update()
    {

        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            Score.instance.score = (int)_timer; 
        }
        
        if(_aux=="Figuras")
        {
            _isDone=_collisionHandler.CounterCheck();
            if(_isDone)
            {
                StartCoroutine(UploadInfo(true));
            }
        }
        if(_aux=="Puzzle")
        {
            _isDone=_collisionHandler.CounterCheck();
            if(_isDone)
            {
                StartCoroutine(UploadInfo(true));
            }
        }
        if(_aux=="Laberinto")
        {
            var _result=_collisionHandler.CollisionCheck();
            if(_result==1)
            {
                StartCoroutine(UploadInfo(true));
                _result=0;
            }
            if(_result==-1)
            {
                StartCoroutine(UploadInfo(false));
                _result=0;
            }
        }
    }

    private IEnumerator UploadInfo(bool _winner)
    {
        if(_winner)
        {
            _module.WriteGameData();
            _storeModule.WriteGameData();
            yield return new WaitForSeconds(1);
            _sceneModule.Load("GameEnded");
        }
        else
        {
            _module.WriteGameData();
            _storeModule.WriteGameData();
            yield return new WaitForSeconds(1);
            _sceneModule.Load("GameEnded");
        }

    }
}
