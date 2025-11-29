' Resonance.vb - Horror Game Logic

Public Class Resonance
    Private Shared ReadOnly Frequencies As New Dictionary(Of String, Integer) From {
        {"Whisper", 1}, {"Scream", 2}, {"Heartbeat", 3}, {"Footstep", 4}, {"Breathing", 5}
    }
    
    Private Shared ReadOnly Entities As New Dictionary(Of String, Integer) From {
        {"Ghost", 1}, {"Shadow", 2}, {"Demon", 3}, {"Memory", 4}, {"Echo", 5}
    }
    
    Private Shared ResonanceMatrix(,) As Boolean = {
        {True, False, True, False, False},   ' Whisper resonates with Ghost and Demon
        {False, True, False, True, True},    ' Scream resonates with Shadow, Memory, Echo
        {True, False, False, True, False},   ' Heartbeat resonates with Ghost, Memory
        {False, True, True, False, True},    ' Footstep resonates with Shadow, Demon, Echo
        {True, True, False, False, True}     ' Breathing resonates with Ghost, Shadow, Echo
    }
    
    Public Shared Function CheckResonance(sound As String, entity As String) As Boolean
        Return ResonanceMatrix(Frequencies(sound) - 1, Entities(entity) - 1)
    End Function
    
    Public Shared Function TriggerHorror(sound As String, entity As String) As String
        If CheckResonance(sound, entity) Then
            Dim horrors As New Dictionary(Of String, String) From {
                {"WhisperGhost", "The whisper becomes a chorus of the damned"},
                {"ScreamShadow", "The shadow grows teeth and eyes"},
                {"HeartbeatMemory", "Your heartbeat syncs with a forgotten death"},
                {"FootstepDemon", "The footsteps approach from all directions"},
                {"BreathingEcho", "The breathing comes from inside your own lungs"}
            }
            Return horrors($"{sound}{entity}")
        End If
        Return "Nothing happens... yet"
    End Function
End Class

' Usage Example:
' If Resonance.CheckResonance("Whisper", "Ghost") Then
'     Console.WriteLine(Resonance.TriggerHorror("Whisper", "Ghost"))
' End If

Class Resonance
    Shared M(,) As Boolean = {{1,0,1,0,0},{0,1,0,1,1},{1,0,0,1,0},{0,1,1,0,1},{1,1,0,0,1}}
    Shared Function Check(s As Integer, e As Integer) As Boolean
        Return M(s-1, e-1)
    End Function
    Shared Function Trigger(s As Integer, e As Integer) As String
        If Check(s,e) Then Return "RESONANCE HORROR" Else Return "Nothing"
    End Function
End Class
