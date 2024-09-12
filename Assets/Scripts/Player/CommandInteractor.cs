using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CommandInteractor : Interactor
{
    Queue<Command> _commandQueue = new Queue<Command>();
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] GameObject _pointerPrefab;
    [SerializeField] Camera _cam;
    Command _currentCommand;
    public override void Interact()
    {
        if (_input._commandPressed)
        {
            Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Ground"))
                {

                    GameObject pointer = Instantiate(_pointerPrefab, hit.point, Quaternion.identity);
                    _commandQueue.Enqueue(new MoveCommand(_agent, hit.point));
                }
                else if (hit.collider.CompareTag("Builder"))
                {
                    _commandQueue.Enqueue(new BuildCommand(_agent, hit.collider.GetComponent<Builder>()));
                }
            }
        }
        ProcessCommands();
    }

    void ProcessCommands()
    {
        if (_currentCommand == null && !_currentCommand._isComplete)
            return;

        if (_commandQueue.Count == 0)
            return;

        _currentCommand = _commandQueue.Dequeue();
        _currentCommand.Execute();

    }
}
