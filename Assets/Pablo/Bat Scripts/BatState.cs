using UnityEngine;

// Base Bat State Class
public abstract class BatState
{
    protected BatStateMachine stateMachine;
    protected Bat bat;

    public BatState(BatStateMachine stateMachine, Bat bat)
    {
        this.stateMachine = stateMachine;
        this.bat = bat;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}