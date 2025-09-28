// Love_Die_Nature.c - Horror Game Core Mechanics
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <unistd.h>
#include <string.h>

#define TRUE 1
#define FALSE 0
#define HEARTBEAT_MAX 180
#define HEARTBEAT_MIN 40

// Nature's terrifying duality: Love && Die
typedef struct {
    int heartbeat;
    float fear_level;
    int is_loving;
    int is_dying;
    char nature_state[20];
} PlayerState;

typedef struct {
    char *sound_effect;
    char *visual_description;
    int fear_impact;
} HorrorEvent;

// Jump scare triggers in nature
HorrorEvent nature_horrors[] = {
    {"TWIG_SNAP", "Something moves in the bushes", 25},
    {"ANIMAL_GROWL", "Eyes glow in the darkness", 40},
    {"WHISPER", "You hear your name whispered", 35},
    {"HEARTBEAT_LOUD", "Your own heartbeat deafens you", 30},
    {"SCREAM", "A human scream echoes through trees", 50}
};

// Love transforms into horror
void love_transforms_to_fear(PlayerState *player) {
    printf("\n🌹 LOVE TRANSFORMS TO FEAR 🌹\n");
    printf("The beautiful forest reveals its true nature...\n");
    
    player->is_loving = FALSE;
    player->is_dying = TRUE;
    strcpy(player->nature_state, "HOSTILE");
    
    // Sudden jump scare
    system("afplay sudden_screech.wav &");  // macOS sound
    // system("play sudden_screech.wav &");  // Linux sound
}

// Nature's jump scare system
void trigger_nature_jump_scare(PlayerState *player) {
    int scare_index = rand() % 5;
    HorrorEvent scare = nature_horrors[scare_index];
    
    printf("\n🚨 NATURE JUMP SCARE! 🚨\n");
    printf("SOUND: %s\n", scare.sound_effect);
    printf("VISUAL: %s\n", visual_description);
    printf("FEAR INCREASE: +%d\n", scare.fear_impact);
    
    player->fear_level += scare.fear_impact;
    player->heartbeat += 30;
    
    // Screen flash simulation
    printf("\033[5;41m");  // Blinking red background
    printf("‼️  JUMP SCARE ‼️");
    printf("\033[0m\n");
    usleep(200000);  // 200ms flash
}

// Heartbeat monitor - reflects fear
void update_heartbeat(PlayerState *player) {
    int target_bpm = HEARTBEAT_MIN + (player->fear_level * 1.4);
    
    if (target_bpm > HEARTBEAT_MAX) {
        target_bpm = HEARTBEAT_MAX;
        printf("💀 HEARTBEAT CRITICAL - NEARING CARDIAC ARREST 💀\n");
    }
    
    player->heartbeat = target_bpm;
    
    // Audio heartbeat simulation
    if (player->heartbeat > 120) {
        printf("💓 Heartbeat: %d BPM (RAPID)\n", player->heartbeat);
    } else if (player->heartbeat > 80) {
        printf("💓 Heartbeat: %d BPM (ELEVATED)\n", player->heartbeat);
    } else {
        printf("💓 Heartbeat: %d BPM (NORMAL)\n", player->heartbeat);
    }
}

// The core philosophical dilemma: Love && Die
int love_and_die_mechanic(PlayerState *player) {
    printf("\n=== LOVE && DIE CYCLE ===\n");
    
    while (player->fear_level < 100) {
        // Random event trigger
        if (rand() % 100 < 30) {  // 30% chance each cycle
            trigger_nature_jump_scare(player);
        }
        
        // Love turning to fear
        if (player->is_loving && rand() % 100 < 20) {
            love_transforms_to_fear(player);
        }
        
        update_heartbeat(player);
        
        // Survival check
        if (player->heartbeat >= HEARTBEAT_MAX) {
            printf("\n💀 CARDIAC ARREST - YOU DIED OF FEAR 💀\n");
            return FALSE;  // Player dies
        }
        
        printf("Fear Level: %.1f/100.0\n", player->fear_level);
        sleep(2);  // 2 second cycles
    }
    
    return TRUE;  // Survived
}

// Nature's beautiful facade hiding horror
void initialize_nature_environment() {
    printf("🌳 WELCOME TO THE FOREST 🌳\n");
    printf("The trees whisper secrets... The wind carries memories...\n");
    printf("But beauty hides terror. Love conceals death.\n\n");
    
    printf("You feel at peace here. You love this place.\n");
    printf("But nature remembers every death that happened here.\n");
    sleep(3);
}

int main() {
    srand(time(NULL));  // Seed random for unpredictable horror
    
    PlayerState player = {
        .heartbeat = 70,
        .fear_level = 0.0,
        .is_loving = TRUE,
        .is_dying = FALSE,
        .nature_state = "PEACEFUL"
    };
    
    initialize_nature_environment();
    
    printf("\nStarting Love && Die simulation...\n");
    printf("Nature will test your sanity.\n");
    printf("Can you survive when love turns to horror?\n\n");
    
    int survived = love_and_die_mechanic(&player);
    
    if (survived) {
        printf("\n🎉 YOU SURVIVED THE HORROR 🎉\n");
        printf("But the forest will remember your fear...\n");
    } else {
        printf("\n⚰️  NATURE CLAIMED ANOTHER SOUL ⚰️\n");
        printf("Love && Die - the eternal cycle continues...\n");
    }
    
    // Philosophical conclusion
    printf("\n=== PHILOSOPHICAL INSIGHT ===\n");
    printf("In nature, love and death are intertwined.\n");
    printf("Every beautiful moment contains the seed of its own end.\n");
    printf("The horror comes from realizing this truth too suddenly.\n");
    
    return survived ? 0 : 1;
}

// Additional nature horror functions
void sudden_silence_effect(PlayerState *player) {
    printf("\n... sudden silence ...\n");
    printf("The forest goes completely quiet.\n");
    printf("No birds, no wind, no leaves...\n");
    
    player->fear_level += 15;
    sleep(2);
    
    // BREAK THE SILENCE WITH SCARE
    trigger_nature_jump_scare(player);
}

void nature_whispering_dilemma() {
    char *whispers[] = {
        "Join us in the soil",
        "The trees hunger",
        "Your love sustains us",
        "Death is just another season",
        "We've been waiting for you"
    };
    
    printf("\n🌬️  THE FOREST WHISPERS: \"%s\" 🌬️\n", 
           whispers[rand() % 5]);
}

// Compilation instructions:
// gcc -o love_die Love_Die_Nature.c
// ./love_die