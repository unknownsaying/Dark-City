-- Main.lua
local M = require("M")
local MarsEarth = require("MarsEarth")
local MoonSun = require("MoonSun")

local Main = {
    currentChapter = 1,
    playerSanity = 100,
    gameTime = 0
}

function Main.init()
    print("Horror Game Initialized")
    Main.startChapter1()
end

function Main.startChapter1()
    -- MarsEarth chapter
    MarsEarth.activateColony()
    M.activate()
    
    timer.every(60, function()
        Main.gameTime = Main.gameTime + 1
        Main.updateSanity()
    end)
end

function Main.updateSanity()
    local sanityLoss = 0
    
    if M.isActive then
        sanityLoss = sanityLoss + 2
    end
    
    if MarsEarth.isStormActive then
        sanityLoss = sanityLoss + 3
    end
    
    if MoonSun.isEclipse then
        sanityLoss = sanityLoss + 5
    end
    
    Main.playerSanity = math.max(0, Main.playerSanity - sanityLoss)
    
    if Main.playerSanity <= 30 then
        Main.triggerInsanityEvents()
    end
end

function Main.triggerInsanityEvents()
    -- Random horror events when sanity is low
    local events = {
        MarsEarth.spawnMartianGhost,
        MoonSun.triggerLunarMadness,
        M.hallucinate
    }
    
    if math.random(100) <= 20 then -- 20% chance per minute
        events[math.random(#events)]()
    end
end

function Main.progressToChapter2()
    Main.currentChapter = 2
    MoonSun.activateCelestialCycle()
    MarsEarth.deactivateColony()
end

return Main