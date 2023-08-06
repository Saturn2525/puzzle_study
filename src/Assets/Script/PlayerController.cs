using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PuyoController[] _puyoControllers = new PuyoController[2] { default!, default! };
    [SerializeField] BoardController boardController = default!;
    Vector2Int _position;

    // Start is called before the first frame update

    void Start()
    {
        _puyoControllers[0].SetPuyoType(PuyoType.Green);
        _puyoControllers[1].SetPuyoType(PuyoType.Red);

        _position = new Vector2Int(2, 12);

        _puyoControllers[0].SetPos(new Vector3((float)_position.x, (float)_position.y, 0.0f));
        _puyoControllers[1].SetPos(new Vector3((float)_position.x, (float)_position.y + 1.0f, 0.0f));
    }
    // Update is called once per frame
    private bool CanMove(Vector2Int pos)
    {
        if (!boardController.CanSettle(pos)) return false;
        if (!boardController.CanSettle(pos + Vector2Int.up)) return false;

        return true;
    }

    private bool Translate(bool is_right)
    {
        Vector2Int pos = _position + (is_right ? Vector2Int.right : Vector2Int.left);
        if(!CanMove(pos)) return false;

        _position = pos;

        _puyoControllers[0].SetPos(new Vector3((float)_position.x, (float)_position.y, 0.0f));
        _puyoControllers[1].SetPos(new Vector3((float)_position.x, (float)_position.y + 1.0f, 0.0f));

        return true;
    }

    void Update()
    {
        if (Input.GetKeyDown("right") || Input.GetKey(KeyCode.D))
        {
            Translate(true);
        }
        if (Input.GetKeyDown("right") || Input.GetKey(KeyCode.D))
        {
            Translate(false);
        }
    }
}