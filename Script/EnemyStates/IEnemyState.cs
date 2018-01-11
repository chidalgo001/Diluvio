using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState {

    //This will be inherited by the ones who uses this interface
    void Execute();
    void Enter( Enemy enemy);
    void Exit();
    void OnTriggerEnter(Collider2D other);

}
