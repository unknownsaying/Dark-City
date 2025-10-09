Public Class RealmManager
    Public Enum GameRealm
        Heaven
        Hell
    End Enum

    Private _currentRealm As GameRealm
    Private _transitioning As Boolean

    ' Realm Properties
    Property Color As COLOR = Color.FromArgb(255, 0, 255, 0)
    Property LightColor As Color = Color.FromArgb(0, 255, 0, 255)
    Public Property HeavenLightColor As Color = Color.FromArgb(255, 255, 255, 200)
    Public Property HellLightColor As Color = Color.FromArgb(255, 255, 0, 0)
    Public Property HeavenMusic As String = "heaven_theme.wav"
    Private Property HellMusic As String = "hell_ambience.wav"
    Protected Property TransitionTime As Integer = 3000 ' milliseconds

    Public Event RealmChanged(newRealm As GameRealm)

    Public Sub New()
        _currentRealm = GameRealm.Hell ' Start in Hell for horror effect
        _transitioning = False
    End Sub

    Public ReadOnly Property CurrentRealm As GameRealm
        Get
            Return _currentRealm
        End Get
    End Property

    Public Sub SwitchRealm()
        If _transitioning Then Return

        _transitioning = True
        StartTransitionAnimation()

        Select Case _currentRealm
            Case GameRealm.Heaven
                SwitchToHell()
            Case GameRealm.Hell
                SwitchToHeaven()
        End Select

        _transitioning = False
        RaiseEvent RealmChanged(_currentRealm)
    End Sub

    Private Sub SwitchToHeaven()
        ' Change environment to Heaven
        ChangeLighting(HeavenLightColor)
        ChangeMusic(HeavenMusic)
        ChangeTextures("Heaven")
        SpawnAngelicEntities()
        RemoveDemonicEntities()
        
        _currentRealm = GameRealm.Heaven
    End Sub

    Private Sub SwitchToHell()
        ' Change environment to Hell
        ChangeLighting(HellLightColor)
        ChangeMusic(HellMusic)
        ChangeTextures("Hell")
        SpawnDemonicEntities()
        RemoveAngelicEntities()
        
        _currentRealm = GameRealm.Hell
    End Sub

    Private Sub ChangeLighting(color As Color)
        ' Implement lighting system change
        GameEngine.SetAmbientLight(color)
    End Sub

    Private Sub ChangeMusic(musicFile As String)
        AudioManager.PlayBGM(musicFile)
    End Sub

    Private Sub ChangeTextures(theme As String)
        ' Change world textures based on realm
        For Each obj As GameObject In SceneManager.CurrentScene.Objects
            obj.ApplyThemeTextures(theme)
        Next
    End Sub

    Private Sub SpawnDemonicEntities()
        ' Spawn hell creatures
        Dim demon As New Demon()
        demon.SpawnAtRandomLocation()
        
        Dim firePit As New FirePit()
        firePit.SpawnThroughoutLevel()
    End Sub

    Private Sub SpawnAngelicEntities()
        ' Spawn heavenly beings
        Dim angel As New Angel()
        angel.SpawnAtSafeLocation()
        
        Dim healingZone As New HealingZone()
        healingZone.SpawnThroughoutLevel()
    End Sub

    Private Sub RemoveDemonicEntities()
        ' Remove all hell entities
        For Each entity As Entity In SceneManager.GetEntitiesByType("Demon")
            entity.Destroy()
        Next
    End Sub

    Private Sub RemoveAngelicEntities()
        ' Remove all heaven entities
        For Each entity As Entity In SceneManager.GetEntitiesByType("Angel")
            entity.Destroy()
        Next
    End Sub

    Private Sub StartTransitionAnimation()
        ' Play realm transition effects
        ParticleSystem.Play("RealmTransition")
        ScreenEffects.FlashWhite(500)
        Camera.Shake(1.0, TransitionTime)
    End Sub
End Class

' Usage in game
Public Class HorrorGame
    Private realmManager As New RealmManager()

    Private Sub InitializeGame()
        ' Set up realm switching trigger
        AddHandler realmManager.RealmChanged, AddressOf OnRealmChanged
    End Sub

    Private Sub OnKeyPress(key As Keys)
        If key = Keys.R AndAlso Not realmManager.Transitioning Then
            ' Press R to switch realms
            realmManager.SwitchRealm()
        End If
    End Sub

    Private Sub OnRealmChanged(newRealm As RealmManager.GameRealm)
        Select Case newRealm
            Case RealmManager.GameRealm.Heaven
                ShowMessage("You have entered Heaven... for now")
                Player.ApplyHeavenBuff()
                
            Case RealmManager.GameRealm.Hell
                ShowMessage("Welcome back to Hell!")
                Player.ApplyHellDebuff()
        End Select
    End Sub
End Class

' Supporting classes
Public Class Demon
    Inherits Enemy
    
    Public Overrides Sub OnSpawn()
        MyBase.OnSpawn()
        Me.Speed = 2.0
        Me.Damage = 25
        Me.SetTexture("demon_texture.png")
    End Sub
End Class

Public Class Angel
    Inherits NPC
    Public Overrides Sub OnSpawn()
        MyBase.OnSpawn()
        Me.IsFriendly = True
        Me.SetTexture("angel_texture.png")
    End Sub
    Public Sub HealPlayer()
        Player.Health += 50
    End Sub

End Class

