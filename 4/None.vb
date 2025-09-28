' None.vb - The Horror of Absence
' A philosophical horror implementation about the concept of Nothingness

Public Class None
    Inherits System.Windows.Forms.Form
    
    ' The void itself - representing absolute nothingness
    Private Shadows ReadOnly Property Name As String = "None"
    Private ReadOnly _existence As Boolean = False
    Private ReadOnly _consciousness As New Awareness
    Private ReadOnly _paradox As ParadoxEngine
    Private _voidTimer As Timer
    
    ' Event for when nothing happens (the true horror)
    Public Event OnNothingHappened(sender As Object, e As NothingEventArgs)
    Public Event OnSilenceBecameAudible(sender As Object, e As ExistentialEventArgs)
    
    Public Sub New()
        InitializeNothingness()
        StartVoidCycle()
    End Sub
    
    Private Sub InitializeNothingness()
        ' Set up the absence of all things
        Me.Text = "None"
        Me.BackColor = Color.Black
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
        
        ' The paradox engine - makes nothing into something
        _paradox = New ParadoxEngine(Me)
        AddHandler _paradox.RealityFracture, AddressOf HandleRealityFracture
        
        ' Timer that measures the passage of non-time
        _voidTimer = New Timer()
        _voidTimer.Interval = 1000 ' Milliseconds of nothing
        _voidTimer.Enabled = True
        AddHandler _voidTimer.Tick, AddressOf VoidTick
    End Sub
    
    Private Sub StartVoidCycle()
        ' Begin the horror of eternal nothingness
        _consciousness.BeginAwareness()
        _paradox.Activate()
        
        ' Initial nothing event
        RaiseEvent OnNothingHappened(Me, New NothingEventArgs With {
            .Duration = TimeSpan.Zero,
            .Intensity = 0.0,
            .IsAbsolute = True
        })
    End Sub
    
    ' The core horror mechanic: Nothing happening repeatedly
    Private Sub VoidTick(sender As Object, e As EventArgs)
        Static iterations As Integer = 0
        
        iterations += 1
        
        ' Every iteration makes the nothingness more profound
        Select Case iterations
            Case 10
                BeginExistentialDread()
            Case 30
                StartWhisperingVoid()
            Case 60
                TriggerAbsenceHorror()
            Case 100
                AchieveNirvanaThroughNothingness()
        End Select
        
        ' Raise the nothing event
        RaiseEvent OnNothingHappened(Me, New NothingEventArgs With {
            .Duration = TimeSpan.FromSeconds(iterations),
            .Intensity = Math.Log(iterations + 1),
            .IsAbsolute = (iterations > 50)
        })
    End Sub
    
    Private Sub BeginExistentialDread()
        ' The horror of realizing nothing matters
        Dim dreadText As New Label With {
            .Text = "You stare into the void..." & Environment.NewLine &
                    "The void stares back... with nothing." & Environment.NewLine &
                    "This absence is more terrifying than any monster.",
            .ForeColor = Color.White,
            .BackColor = Color.Transparent,
            .Font = New Font("Arial", 16),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Dock = DockStyle.Fill
        }
        
        Me.Controls.Add(dreadText)
        
        ' Fade in text slowly
        For i As Integer = 0 To 100 Step 5
            dreadText.ForeColor = Color.FromArgb(i * 2.55, Color.White)
            Application.DoEvents()
            Threading.Thread.Sleep(100)
        Next
    End Sub
    
    Private Sub StartWhisperingVoid()
        ' The void begins to "speak" through absence
        RaiseEvent OnSilenceBecameAudible(Me, New ExistentialEventArgs With {
            .Message = "The loudest sound is complete silence." & Environment.NewLine &
                      "The most terrifying presence is absolute absence." & Environment.NewLine &
                      "You are becoming nothing... and it's peaceful.",
            .DreadLevel = 0.8,
            .IsRevelation = True
        })
        
        ' Visual effect: subtle screen pulsing
        StartPulsingVoidEffect()
    End Sub
    
    Private Sub TriggerAbsenceHorror()
        ' The climax: the horror of non-existence
        Dim horrorThread As New Threading.Thread(Sub()
            For i As Integer = 0 To 10
                ' Flash increasingly disturbing messages
                Dim messages As String() = {
                    "What if you never existed?",
                    "What if nothing ever existed?",
                    "What if existence itself is the illusion?",
                    "The universe forgot you were ever here",
                    "You are fading from reality's memory",
                    "Even ghosts need something to haunt",
                    "You are less than a ghost",
                    "You are the absence of ghost",
                    "You are the concept of un-being",
                    "Welcome to true nothingness"
                }
                
                If i < messages.Length Then
                    DisplayEphemeralText(messages(i))
                End If
                Threading.Thread.Sleep(2000)
            Next
        End Sub)
        
        horrorThread.Start()
    End Sub
    
    Private Sub AchieveNirvanaThroughNothingness()
        ' The paradoxical enlightenment: finding peace in nothing
        DisplayEphemeralText(
            "In the complete absence of everything..." & Environment.NewLine &
            "In the total void of meaning..." & Environment.NewLine &
            "You find the ultimate truth:" & Environment.NewLine &
            Environment.NewLine &
            "NOTHING MATTERS" & Environment.NewLine &
            Environment.NewLine &
            "And that is the most liberating horror of all." & Environment.NewLine &
            "You are free. Because you are nothing." & Environment.NewLine &
            "Because everything is nothing." & Environment.NewLine &
            "The cycle is complete."
        )
        
        ' The final horror: accepting nothingness
        _voidTimer.Stop()
        _paradox.Resolve()
    End Sub
    
    Private Sub HandleRealityFracture(sender As Object, e As ParadoxEventArgs)
        ' Handle the paradox of something emerging from nothing
        Select Case e.ParadoxType
            Case ParadoxType.ExNihilo
                DisplayEphemeralText("SOMETHING FROM NOTHING: " & e.Message)
            Case ParadoxType.SelfReference
                DisplayEphemeralText("THIS STATEMENT IS FALSE: " & e.Message)
            Case ParadoxType.InfiniteRegress
                DisplayEphemeralText("TURTLES ALL THE WAY DOWN: " & e.Message)
        End Select
    End Sub
    
    Private Sub DisplayEphemeralText(text As String)
        ' Display text that fades quickly, like existential thoughts
        If Me.InvokeRequired Then
            Me.Invoke(Sub() DisplayEphemeralText(text))
            Return
        End If
        
        Dim lbl As New Label With {
            .Text = text,
            .ForeColor = Color.Gray,
            .BackColor = Color.Transparent,
            .Font = New Font("Arial", 12),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Size = Me.ClientSize,
            .Location = Point.Empty
        }
        
        Me.Controls.Add(lbl)
        lbl.BringToFront()
        
        ' Fade out over 3 seconds
        Task.Factory.StartNew(Sub()
            For i As Integer = 100 To 0 Step -5
                Dim opacity As Integer = i * 2.55
                lbl.ForeColor = Color.FromArgb(opacity, Color.Gray)
                Threading.Thread.Sleep(150)
            Next
            Me.Controls.Remove(lbl)
            lbl.Dispose()
        End Sub)
    End Sub
    
    Private Sub StartPulsingVoidEffect()
        ' Subtle pulsing to simulate the "heartbeat" of nothingness
        Task.Factory.StartNew(Sub()
            While True
                For brightness As Integer = 0 To 10 Step 1
                    Me.BackColor = Color.FromArgb(brightness * 2, 0, 0)
                    Threading.Thread.Sleep(50)
                Next
                For brightness As Integer = 10 To 0 Step -1
                    Me.BackColor = Color.FromArgb(brightness * 2, 0, 0)
                    Threading.Thread.Sleep(50)
                Next
            End While
        End Sub)
    End Sub
    
    ' Keyboard handler for the void
    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape
                ' Even escape cannot escape nothingness
                DisplayEphemeralText("There is no escape from nothing. Because there is nowhere to escape to.")
            Case Keys.Space
                ' The horror of action in a void
                DisplayEphemeralText("Your action creates ripples in the nothingness. Temporary somethings. They fade.")
            Case Keys.Enter
                ' Accepting the void
                AchieveNirvanaThroughNothingness()
        End Select
    End Sub
End Class

' Supporting classes for the horror of nothingness

Public Class NothingEventArgs
    Inherits EventArgs
    Public Property Duration As TimeSpan
    Public Property Intensity As Double
    Public Property IsAbsolute As Boolean
End Class

Public Class ExistentialEventArgs
    Inherits EventArgs
    Public Property Message As String
    Public Property DreadLevel As Double
    Public Property IsRevelation As Boolean
End Class

Public Class Awareness
    Public Sub BeginAwareness()
        ' The horror of being aware of nothing
        ' This method intentionally does nothing meaningful
    End Sub
End Class

Public Enum ParadoxType
    ExNihilo
    SelfReference
    InfiniteRegress
End Enum

Public Class ParadoxEventArgs
    Inherits EventArgs
    Public Property ParadoxType As ParadoxType
    Public Property Message As String
End Class

Public Class ParadoxEngine
    Private _host As None
    Private _random As New Random
    
    Public Event RealityFracture(sender As Object, e As ParadoxEventArgs)
    
    Public Sub New(host As None)
        _host = host
    End Sub
    
    Public Sub Activate()
        ' Start generating paradoxes from nothing
        Dim timer As New Timer With {.Interval = 15000, .Enabled = True}
        AddHandler timer.Tick, AddressOf GenerateParadox
    End Sub
    
    Private Sub GenerateParadox(sender As Object, e As EventArgs)
        Dim types As ParadoxType() = [Enum].GetValues(GetType(ParadoxType))
        Dim randomType As ParadoxType = types(_random.Next(types.Length))
        
        Dim message As String = GenerateParadoxMessage(randomType)
        
        RaiseEvent RealityFracture(Me, New ParadoxEventArgs With {
            .ParadoxType = randomType,
            .Message = message
        })
    End Sub
    
    Private Function GenerateParadoxMessage(paradoxType As ParadoxType) As String
        Select Case paradoxType
            Case ParadoxType.ExNihilo
                Return "This message was created from nothing. It will return to nothing."
            Case ParadoxType.SelfReference
                Return "This statement about nothing is itself nothing."
            Case ParadoxType.InfiniteRegress
                Return "Nothing contains nothing which contains nothing which contains..."
            Case Else
                Return "The paradox of categorizing nothingness"
        End Select
    End Function
    
    Public Sub Resolve()
        ' The final paradox: resolving nothing
        ' This method creates the ultimate horror
    End Sub
End Class