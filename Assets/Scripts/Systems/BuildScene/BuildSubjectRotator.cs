using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildSubjectRotator : MonoBehaviour
{
    public bool m_isSelected;
    
    private float m_axis_yaw = 0;
    private float m_axis_pitch = 0;
    private float m_axis_roll = 0;
    private float m_base_turn_rate = 100;
    
    public InputActionReference p1_pitch;
    public InputActionReference p1_roll;
    public InputActionReference p1_yaw;

    public InputActionReference p2_pitch;
    public InputActionReference p2_roll;
    public InputActionReference p2_yaw;

    private void GetInput()
    {
        if (BuildSubjectLogic.m_currentPlayerId == 1)
        {
            m_axis_pitch = p1_pitch.action.ReadValue<float>();
            m_axis_roll = p1_roll.action.ReadValue<float>();
            m_axis_yaw = p1_yaw.action.ReadValue<float>();
        }
        else if (BuildSubjectLogic.m_currentPlayerId == 2)
        {
            m_axis_pitch = p2_pitch.action.ReadValue<float>();
            m_axis_roll = p2_roll.action.ReadValue<float>();
            m_axis_yaw = p2_yaw.action.ReadValue<float>();
        }
    }
    private void RotationUpdate()
    {
        Vector3 angles;
        angles.x = m_axis_pitch * m_base_turn_rate * Time.deltaTime;
        angles.y = m_axis_yaw * m_base_turn_rate * Time.deltaTime;
        angles.z = m_axis_roll * m_base_turn_rate * Time.deltaTime;
        transform.Rotate(angles);
    }
    void Update()
    {
        GetInput();
        RotationUpdate();
    }
}
