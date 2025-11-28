using UnityEngine;
public interface ITransmission
{
    void NextStage();
    void PreviousStage();
    int Stage { get; set; }
}
