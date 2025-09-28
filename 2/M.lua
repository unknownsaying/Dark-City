-- M.lua
local M = {}

M.mysteryLevel = 100
M.madness = 0
M.isActive = false

function M.activate()
    M.isActive = true
    print("The M Entity awakens...")
    M.startWhispering()
end

function M.startWhispering()
    local whispers = {
        "They're watching from the walls",
        "The symbols don't lie",
        "Mars is not what it seems",
        "The sun remembers everything"
    }
    
    -- Random whisper every 30 seconds
    timer.every(30, function()
        local whisper = whispers[math.random(#whispers)]
        game.showSubtitle(whisper)
        M.madness = M.madness + 5
    end)
end

function M.increaseMadness(amount)
    M.madness = math.min(100, M.madness + amount)
    if M.madness >= 80 then
        M.hallucinate()
    end
end

function M.hallucinate()
    -- Spawn fake enemies, distort vision
    world.spawnHallucination()
    screen.applyDistortionEffect()
end
return M