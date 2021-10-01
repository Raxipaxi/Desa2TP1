
public interface iInput
{    
    float GetH { get; }
    float GetV { get; }
    bool IsMoving();
    bool IsShooting();
    void UpdateInputs();
}
