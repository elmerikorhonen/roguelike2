using UnityEngine;

public class TurnManager
{
    private int m_TurnCount;

    public TurnManager()
    {
        m_TurnCount = 1;
    }

    public void Tick()
    {
        m_TurnCount+= 1;
        Debug.Log("current turn count : "+ m_TurnCount);
    }
}
