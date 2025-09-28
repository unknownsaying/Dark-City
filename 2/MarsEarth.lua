-- MarsEarth.lua
local MarsEarth = {}

MarsEarth.colonyStatus = "functional"
MarsEarth.oxygenLevel = 100
MarsEarth.isStormActive = false
MarsEarth.martianArtifacts = 0

function MarsEarth.activateColony()
    print("Mars Colony activated")
    MarsEarth.startOxygenCycle()
    MarsEarth.startWeatherCycle()
end

function MarsEarth.startOxygenCycle()
    timer.every(10, function()
        MarsEarth.oxygenLevel = math.max(0, MarsEarth.oxygenLevel - 1)
        
        if MarsEarth.oxygenLevel <= 20 then
            game.showWarning("OXYGEN CRITICAL")
            MarsEarth.triggerBreathingSounds()
        end
    end)
end

function MarsEarth.startWeatherCycle()
    timer.every(300, function() -- Every 5 minutes
        MarsEarth.isStormActive = math.random(100) <= 30 -- 30% chance
        
        if MarsEarth.isStormActive then
            MarsEarth.startDustStorm()
        end
    end)
end

function MarsEarth.startDustStorm()
    print("MARTIAN DUST STORM INCOMING")
    screen.applyRedFilter()
    audio.play("storm_wind.wav")
    
    -- Spawn storm creatures
    timer.after(30, function()
        MarsEarth.spawnDustWraiths()
    end)
end

function MarsEarth.spawnDustWraiths()
    for i = 1, 3 do
        enemy.spawn("dust_wraith", player.getPosition() + vector3(math.random(-10,10), 0, math.random(-10,10)))
    end
end

function MarsEarth.spawnMartianGhost()
    local ghost = enemy.spawn("martian_ghost", player.getPosition() + vector3(5, 0, 5))
    ghost.setInvisible(true)
    ghost.setSpeed(2.0)
end

function MarsEarth.discoverArtifact()
    MarsEarth.martianArtifacts = MarsEarth.martianArtifacts + 1
    M.increaseMadness(10)
    
    if MarsEarth.martianArtifacts >= 5 then
        MarsEarth.triggerAncientAwakening()
    end
end

function MarsEarth.triggerAncientAwakening()
    print("ANCIENT MARTIAN POWER AWAKENS")
    screen.shake(5.0)
    audio.play("ancient_awakening.wav")
end

return MarsEarth