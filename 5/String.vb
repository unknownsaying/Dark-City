' HorrorScene.vb
Public Class HorrorScene
    Public Shared Function BuildTerrifyingScene() As String
        Dim horror = ""
        horror &= "The floorboards creak unnaturally in the dead silence. "
        horror &= "A cold breath touches your neck but no one is there. "
        horror &= "Shadows twist into familiar shapes that shouldn't move. "
        horror &= "Whispers echo from walls that have no openings. "
        horror &= "Every reflection shows something standing behind you. "
        horror &= "The lights flicker to reveal brief, impossible figures. "
        horror &= "Your own heartbeat is the only sound you can trust. "
        horror &= "Until it starts to beat in rhythm with something else. "
        horror &= "Something that is now breathing in the darkness with you."
        Return horror
    End Function
    
    ' Ultra-compact version (1 line)
    Public Shared ReadOnly Property Scene As String = 
        "Blood drips upwards. " &
        "Windows show the wrong room. " &
        "Your shadow moves first. " &
        "The door handle turns by itself. " &
        "Something whispers your childhood name."
End Class
Class H
    Shared S As String = "Darkness moves. Something breathes. You are not alone."
End Class