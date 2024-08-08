using UnityEngine;
using UnityEngine.Events;

public class GoalDetectTrigger : MonoBehaviour
{

    [Header("Trigger Collider Tag To Detect")]
    public string tagToDetect = "goalYellow"; //collider tag to detect
    public string tagToDetectOpponent = "goalBlue"; //collider tag to detect

    [Header("Goal Value")]
    public float GoalValue = 1;

    [Header("Penalty Value")]
    public float PenaltyValue = -1;

    private Collider m_col;
    [System.Serializable]
    public class TriggerEvent : UnityEvent<Collider, float>
    {
    }

    [Header("Trigger Callbacks")]
    public TriggerEvent onTriggerEnterEvent = new TriggerEvent();
    public TriggerEvent onTriggerStayEvent = new TriggerEvent();
    public TriggerEvent onTriggerExitEvent = new TriggerEvent();

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag(tagToDetect))
        {
            onTriggerEnterEvent.Invoke(m_col, GoalValue);
        }
        else if (col.CompareTag(tagToDetectOpponent) && PenaltyValue != 0)
        {
            onTriggerEnterEvent.Invoke(m_col, PenaltyValue);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag(tagToDetect))
        {
            onTriggerStayEvent.Invoke(m_col, GoalValue);
        }
        else if (col.CompareTag(tagToDetectOpponent) && PenaltyValue != 0)
        {
            onTriggerStayEvent.Invoke(m_col, PenaltyValue);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag(tagToDetect))
        {
            onTriggerExitEvent.Invoke(m_col, GoalValue);
        }
        else if (col.CompareTag(tagToDetectOpponent) && PenaltyValue != 0)
        {
            onTriggerExitEvent.Invoke(m_col, PenaltyValue);
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        m_col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
