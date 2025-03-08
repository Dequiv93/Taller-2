using UnityEngine;

public interface ITriggerCheckable
{
    bool IsAggroed { get; set; }

    bool IsWithinStrikingDistance { get; set; }

    void SetAggroStatus(bool isAggroed);

    void IsWithinStrikingDistanceBool(bool IsWithinStrikingDistance);
}
