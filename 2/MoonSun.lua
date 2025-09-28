-- MoonSun.lua
local MoonSun = {}

MoonSun.currentTime = "day"
MoonSun.isEclipse = false
MoonSun.lunarCycle = "new"
MoonSun.celestialEnergy = 0

function MoonSun.activateCelestialCycle()
    print("Celestial cycle activated")
    MoonSun.startDayNightCycle()
    MoonSun.startLunarCycle()
end

function MoonSun.startDayNightCycle()
    timer.every(600, function() -- 10 minute day/night cycle
        if MoonSun.currentTime == "day" then
            MoonSun.currentTime = "night"
            MoonSun.startNightHorrors()
        else
            MoonSun.currentTime = "day"
            MoonSun.endNightHorrors()
        end
    end)
end

function MoonSun.startLunarCycle()
    timer.every(2400, function() -- 40 minute lunar cycle
        local cycles = {"new", "waxing", "full", "waning"}
        MoonSun.lunarCycle = cycles[math.random(#cycles)]
        
        if MoonSun.lunarCycle == "full" then
            MoonSun.triggerFullMoonEffects()
        end
    end)
end

function MoonSun.startNightHorrors()
    if MoonSun.lunarCycle == "full" then
        enemy.spawnRate = 2.0
        audio.play("night_ambience_scary.wav")
    else
        enemy.spawnRate = 1.5
        audio.play("night_ambience.wav")
    end
    
    -- Spawn night creatures
    MoonSun.spawnLunarCreatures()
end

function MoonSun.triggerFullMoonEffects()
    print("FULL MOON RISES - THE HORRORS INTENSIFY")
    screen.setTint(0.3, 0.3, 0.8, 0.2) -- Blue moonlight
    M.increaseMadness(25)
    
    -- Werewolf transformation chance
    if math.random(100) <= 50 then
        MoonSun.transformNPCtoWerewolf()
    end
end

function MoonSun.spawnLunarCreatures()
    local creatures = {
        "moon_beast",
        "shadow_stalker", 
        "lunar_ghoul"
    }
    
    for i = 1, 2 do
        local creature = creatures[math.random(#creatures)]
        enemy.spawn(creature, player.getPosition() + vector3(math.random(-15,15), 0, math.random(-15,15)))
    end
end

function MoonSun.triggerEclipse()
    MoonSun.isEclipse = true
    print("SOLAR ECLIPSE - REALITY FADES")
    screen.applyDarknessFilter()
    audio.play("eclipse_sound.wav")
    
    timer.after(120, function() -- 2 minute eclipse
        MoonSun.isEclipse = false
        screen.removeDarknessFilter()
    end)
end

function MoonSun.triggerLunarMadness()
    -- Special madness effect during moon events
    screen.setTint(0.8, 0.2, 0.8, 0.4) -- Purple madness tint
    audio.play("lunar_madness.wav")
    
    -- Reverse controls for 10 seconds
    controls.setInverted(true)
    timer.after(10, function()
        controls.setInverted(false)
    end)
end


return MoonSun