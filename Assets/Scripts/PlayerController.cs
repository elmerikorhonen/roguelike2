using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private BoardManager m_board;
    private Vector2Int m_CellPosition;

    public void Spawn(BoardManager boardManager, Vector2Int cell) // pelaaja on oikeassa paikassa, kun Spawn kutsutaan, joten ei tarvitse tarkistaa onko cell passable
    {
        m_board = boardManager;
        m_CellPosition = cell;

        transform.position = m_board.CellToWorld(cell);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2Int newCellTarget = m_CellPosition;
        bool hasMoved = false;

        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            newCellTarget += Vector2Int.up;
            hasMoved = true;
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            newCellTarget += Vector2Int.down;
            hasMoved = true;
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            newCellTarget += Vector2Int.left;
            hasMoved = true;
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            newCellTarget += Vector2Int.right;
            hasMoved = true;
        }
        if (hasMoved)
        {
            // Tarkistetaan, onko uusi ruutu läpäistävä
            BoardManager.CellData cellData = m_board.GetCellData(newCellTarget);
            if (cellData != null && cellData.Passable)
            {
                m_CellPosition = newCellTarget;
                transform.position = m_board.CellToWorld(m_CellPosition);
            }
        }
    }
}
