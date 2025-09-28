// LifeCycle.js - Philosophical Horror Game System
class LifeCycle {
    constructor() {
        this.stages = ['birth', 'growth', 'reproduction', 'decay', 'death'];
        this.currentStage = 0;
        this.existentialDread = 0;
        this.lifeMeaning = 0;
        this.memories = [];
        this.isEnlightened = false;
    }

    // Progress through life stages with horror elements
    progressStage() {
        if (this.currentStage >= this.stages.length - 1) {
            this.triggerRebirthCycle();
            return;
        }

        this.currentStage++;
        this.existentialDread += Math.random() * 20;
        
        // Horror events based on life stage
        switch(this.stages[this.currentStage]) {
            case 'birth':
                this.spawnIntoExistence();
                break;
            case 'growth':
                this.questionPurpose();
                break;
            case 'reproduction':
                this.faceLegacyFear();
                break;
            case 'decay':
                this.confrontMortality();
                break;
            case 'death':
                this.transcendOrPerish();
                break;
        }

        this.updateLifeMeaning();
    }

    questionPurpose() {
        const philosophicalQuestions = [
            "Why do I exist?",
            "Is this reality real?",
            "What happens when it ends?",
            "Does any of this matter?"
        ];
        
        const question = philosophicalQuestions[Math.floor(Math.random() * philosophicalQuestions.length)];
        this.displayExistentialText(question);
        this.existentialDread += 15;
    }

    confrontMortality() {
        // Visual and audio horror elements
        this.fadeToDecayVisuals();
        this.playHeartbeatSound(true); // Irregular heartbeat
        this.spawnGhostsOfPastSelves();
        
        // Philosophical horror dialogue
        this.displayExistentialText(
            "The body decays but consciousness remains... " +
            "Is this the end or merely a transition?"
        );
    }

    transcendOrPerish() {
        if (this.lifeMeaning > 75) {
            this.achieveEnlightenment();
        } else if (this.lifeMeaning < 25) {
            this.fallIntoDespair();
        } else {
            this.reincarnate();
        }
    }

    achieveEnlightenment() {
        this.isEnlightened = true;
        this.displayExistentialText(
            "Death is not an end but a return to the cosmic whole. " +
            "The cycle continues, but you have broken the chains of fear."
        );
        this.playEnlightenmentMusic();
    }

    fallIntoDespair() {
        this.displayExistentialText(
            "In the end, nothing mattered. The universe remains indifferent. " +
            "Your consciousness fades into eternal silence..."
        );
        this.playHorrorStinger();
        this.gameOver();
    }

    updateLifeMeaning() {
        // Life meaning increases through meaningful choices
        // and decreases through existential dread
        this.lifeMeaning = Math.max(0, Math.min(100, 
            this.lifeMeaning + (this.memories.length * 2) - (this.existentialDread * 0.1)
        ));
    }

    // Endless cycle mechanic
    triggerRebirthCycle() {
        this.displayExistentialText(
            "The cycle continues... But is each iteration truly new? " +
            "Or are we trapped in an endless repetition?"
        );
        this.currentStage = 0;
        this.memories.push(`Cycle ${this.memories.length + 1} completed`);
        this.existentialDread += 10;
    }
}