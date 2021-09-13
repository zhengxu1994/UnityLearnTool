﻿using UnityEngine;
using System.Collections;
using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{
    /// <summary>
    /// Add this component to a character and it'll be able to activate/desactivate the pause
    /// </summary>
    [MMHiddenProperties("AbilityStopFeedbacks")]
    [AddComponentMenu("TopDown Engine/Character/Abilities/Character Pause")]
    public class CharacterPause : CharacterAbility
    {
        /// This method is only used to display a helpbox text at the beginning of the ability's inspector
        public override string HelpBoxText() { return "Allows this character (and the player controlling it) to press the pause button to pause the game."; }

        /// <summary>
        /// Every frame, we check the input to see if we need to pause/unpause the game
        /// </summary>
        protected override void HandleInput()
        {
            if (_inputManager.PauseButton.State.CurrentState == MMInput.ButtonStates.ButtonDown)
            {
                TriggerPause();
            }
        }

        /// <summary>
        /// If the pause button has been pressed, we change the pause state
        /// </summary>
        protected virtual void TriggerPause()
        {
            if (!AbilityAuthorized
            && (_condition.CurrentState == CharacterStates.CharacterConditions.Normal || _condition.CurrentState == CharacterStates.CharacterConditions.Paused))
            {
                return;
            }
            PlayAbilityStartFeedbacks();
            // we trigger a Pause event for the GameManager and other classes that could be listening to it too
            TopDownEngineEvent.Trigger(TopDownEngineEventTypes.TogglePause, null);
        }

        /// <summary>
        /// Puts the character in the pause state
        /// </summary>
        public virtual void PauseCharacter()
        {
            if (!this.enabled)
            {
                return;
            }
            _condition.ChangeState(CharacterStates.CharacterConditions.Paused);
        }

        /// <summary>
        /// Restores the character to the state it was in before the pause.
        /// </summary>
        public virtual void UnPauseCharacter()
        {
            if (!this.enabled)
            {
                return;
            }
            _condition.RestorePreviousState();
        }
    }
}