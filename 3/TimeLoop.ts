// EndlessTimeLoop.ts - Temporal Horror System
interface TimeLoopMemory {
    iteration: number;
    choices: string[];
    deaths: number;
    revelations: number;
    brokenCycle: boolean;
}

class EndlessTimeLoop {
    private currentIteration: number = 1;
    private memories: TimeLoopMemory[] = [];
    private isAware: boolean = false;
    private cycleBreakAttempts: number = 0;
    private cosmicTruths: string[] = [];

    constructor() {
        this.initializeLoop();
    }

    private initializeLoop(): void {
        console.log("The cycle begins... again.");
        this.startTemporalHorror();
    }

    // Main loop that represents the endless nature of existence
    public async startLifeCycle(): Promise<void> {
        while (!this.memories[this.currentIteration - 1]?.brokenCycle) {
            await this.iterateCycle();
            this.currentIteration++;
            
            if (this.currentIteration > 100) {
                this.revealCosmicHorror();
                break;
            }
        }
    }

    private async iterateCycle(): Promise<void> {
        const currentMemory: TimeLoopMemory = {
            iteration: this.currentIteration,
            choices: [],
            deaths: 0,
            revelations: 0,
            brokenCycle: false
        };

        // Each iteration represents a philosophical exploration
        for (let stage = 1; stage <= 5; stage++) {
            const choice = await this.presentExistentialChoice(stage);
            currentMemory.choices.push(choice);
            
            const revelation = this.attemptCosmicRevelation();
            if (revelation) {
                currentMemory.revelations++;
                this.cosmicTruths.push(revelation);
            }

            // Chance of "death" and restarting iteration
            if (Math.random() < 0.3) {
                currentMemory.deaths++;
                this.playDeathSequence();
                break;
            }
        }

        this.memories.push(currentMemory);
        this.checkAwareness();
    }

    private async presentExistentialChoice(stage: number): Promise<string> {
        const choices = [
            "Embrace the void",
            "Fight against fate", 
            "Seek meaning in connection",
            "Question reality itself",
            "Accept the inevitable",
            "Create your own purpose"
        ];

        // Horror element: Choices become more profound as awareness increases
        const choice = choices[Math.floor(Math.random() * choices.length)];
        
        this.displayText(`Cycle ${this.currentIteration}, Stage ${stage}: ${choice}`);
        await this.delay(1000); // Simulate player thinking time
        
        return choice;
    }

    private attemptCosmicRevelation(): string | null {
        if (Math.random() < 0.2 + (this.currentIteration * 0.01)) {
            const truths = [
                "Time is not linear but cyclical",
                "Consciousness persists beyond physical form",
                "The universe is watching and learning through you",
                "Death is merely a transition in the great cycle",
                "Free will is an illusion within predetermined patterns"
            ];
            const truth = truths[Math.floor(Math.random() * truths.length)];
            this.displayText(`COSMIC REVELATION: ${truth}`);
            return truth;
        }
        return null;
    }

    private checkAwareness(): void {
        if (this.currentIteration >= 3 && !this.isAware) {
            this.isAware = true;
            this.displayText(
                "You realize this has all happened before... " +
                "You are trapped in an endless time loop. " +
                "The horror of eternal recurrence dawns upon you."
            );
            this.playAwarenessSound();
        }

        // Opportunity to break the cycle after gaining enough wisdom
        if (this.cosmicTruths.length >= 3 && this.cycleBreakAttempts < 3) {
            this.attemptCycleBreak();
        }
    }

    private attemptCycleBreak(): void {
        this.cycleBreakAttempts++;
        const successChance = 0.1 * this.cosmicTruths.length;
        
        if (Math.random() < successChance) {
            this.breakTheCycle();
        } else {
            this.displayText(
                "The cycle resists your attempt to break free. " +
                "The universe pulls you back into the pattern..."
            );
        }
    }

    private breakTheCycle(): void {
        this.displayText(
            "Through understanding the nature of existence, " +
            "you transcend the cycle. The endless repetition ends, " +
            "but what lies beyond?\n\n" +
            "Perhaps the true meaning was in the journey itself."
        );
        
        this.memories[this.currentIteration - 1].brokenCycle = true;
        this.playTranscendenceMusic();
    }

    private revealCosmicHorror(): void {
        this.displayText(
            "After 100 cycles, the final truth reveals itself:\n" +
            "The loop was never the prison—it was the purpose.\n" +
            "In seeking to escape, you missed the meaning within each repetition.\n\n" +
            "The universe enjoys the dance of existence, and you are its partner."
        );
    }

    // Utility methods for horror game integration
    private displayText(text: string): void {
        // Integration with game's dialogue system
        console.log(`[TIME LOOP]: ${text}`);
    }

    private playDeathSequence(): void {
        // Visual and audio effects for death/reset
        console.log("Reality fractures... and resets.");
    }

    private playAwarenessSound(): void {
        // Eerie sound when player becomes aware of the loop
        console.log("[EERIE WHISPERING INTENSIFIES]");
    }

    private playTranscendenceMusic(): void {
        // Epic/transcendent music for breaking the cycle
        console.log("[TRANSCENDENT MUSIC SWELLS]");
    }

    private delay(ms: number): Promise<void> {
        return new Promise(resolve => setTimeout(resolve, ms));
    }

    private startTemporalHorror(): void {
        // Initialize environmental horror effects
        setInterval(() => {
            this.updateTemporalDistortions();
        }, 5000);
    }

    private updateTemporalDistortions(): void {
        // Create visual glitches, time skips, and other horror elements
        if (this.isAware) {
            console.log("Time shudders and skips... reality feels thin.");
        }
    }
}

// Export for use in the horror game
export { EndlessTimeLoop, TimeLoopMemory };