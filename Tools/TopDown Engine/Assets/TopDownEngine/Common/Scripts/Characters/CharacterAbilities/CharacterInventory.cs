﻿using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.InventoryEngine;
using System.Collections.Generic;

namespace MoreMountains.TopDownEngine
{
    [System.Serializable]
    public struct AutoPickItem
    {
        public InventoryItem Item;
        public int Quantity;
    }

    /// <summary>
    /// Add this component to a character and it'll be able to control an inventory
    /// Animator parameters : none
    /// </summary>
    [MMHiddenProperties("AbilityStopFeedbacks")]
    [AddComponentMenu("TopDown Engine/Character/Abilities/Character Inventory")] 
	public class CharacterInventory : CharacterAbility, MMEventListener<MMInventoryEvent>
	{
        public enum WeaponRotationModes { Normal, AddEmptySlot, AddInitialWeapon }

        [Header("Bindings")]
		/// the name of the main inventory for this character
		[Tooltip("the name of the main inventory for this character")]
		public string MainInventoryName;
		/// the name of the inventory where this character stores weapons
		[Tooltip("the name of the inventory where this character stores weapons")]
		public string WeaponInventoryName;
		/// the name of the hotbar inventory for this character
		[Tooltip("the name of the hotbar inventory for this character")]
		public string HotbarInventoryName;

        [Header("Weapon Rotation")]
        /// the rotation mode for weapons : Normal will cycle through all weapons, AddEmptySlot will return to empty hands, AddOriginalWeapon will cycle back to the original weapon
		[Tooltip("if this is true, will add an empty slot to the weapon rotation")]
        public WeaponRotationModes WeaponRotationMode = WeaponRotationModes.Normal;

        [Header("AutoEquip")]
        /// a list of items to automatically add to this Character's inventories on start
		[Tooltip("a list of items to automatically add to this Character's inventories on start")]
        public AutoPickItem[] AutoPickItems;
        /// a weapon to auto equip on start
		[Tooltip("a weapon to auto equip on start")]
        public InventoryWeapon AutoEquipWeaponOnStart;
        
        /// the target handle weapon ability - if left empty, will pick the first one it finds
        [Tooltip("the target handle weapon ability - if left empty, will pick the first one it finds")]
        public CharacterHandleWeapon CharacterHandleWeapon;

        public Inventory MainInventory { get; set; }
		public Inventory WeaponInventory { get; set; }
		public Inventory HotbarInventory { get; set; }

		protected List<int> _availableWeapons;
		protected List<string> _availableWeaponsIDs;
		protected string _nextWeaponID;
        protected bool _nextFrameWeapon = false;
        protected string _nextFrameWeaponName;
        protected const string _emptySlotWeaponName = "_EmptySlotWeaponName";
        protected const string _initialSlotWeaponName = "_InitialSlotWeaponName";

        /// <summary>
        /// On init we setup our ability
        /// </summary>
		protected override void Initialization () 
		{
			base.Initialization();
			Setup ();
		}

        /// <summary>
        /// Grabs all inventories, and fills weapon lists
        /// </summary>
		protected virtual void Setup()
		{
			GrabInventories ();
			if (CharacterHandleWeapon == null)
			{
				CharacterHandleWeapon = _character?.FindAbility<CharacterHandleWeapon> ();	
			}
			FillAvailableWeaponsLists ();

            // we auto pick items if needed
            if (AutoPickItems.Length > 0)
            {
                foreach (AutoPickItem item in AutoPickItems)
                {
                    MMInventoryEvent.Trigger(MMInventoryEventType.Pick, null, item.Item.TargetInventoryName, item.Item, item.Quantity, 0);
                }
            }

            // we auto equip a weapon if needed
            if (AutoEquipWeaponOnStart != null)
            {
                MMInventoryEvent.Trigger(MMInventoryEventType.Pick, null, AutoEquipWeaponOnStart.TargetInventoryName, AutoEquipWeaponOnStart, 1, 0);
                EquipWeapon(AutoEquipWeaponOnStart.ItemID);
            }
        }

        public override void ProcessAbility()
        {
            base.ProcessAbility();
            
            if (_nextFrameWeapon)
            {
                EquipWeapon(_nextFrameWeaponName);
                _nextFrameWeapon = false;
            }
        }

        /// <summary>
        /// Grabs any inventory it can find that matches the names set in the inspector
        /// </summary>
		protected virtual void GrabInventories()
		{
			if (MainInventory == null)
			{
				GameObject mainInventoryTmp = GameObject.Find (MainInventoryName);
				if (mainInventoryTmp != null) { MainInventory = mainInventoryTmp.GetComponent<Inventory> (); }	
			}
			if (WeaponInventory == null)
			{
				GameObject weaponInventoryTmp = GameObject.Find (WeaponInventoryName);
				if (weaponInventoryTmp != null) { WeaponInventory = weaponInventoryTmp.GetComponent<Inventory> (); }	
			}
			if (HotbarInventory == null)
			{
				GameObject hotbarInventoryTmp = GameObject.Find (HotbarInventoryName);
				if (hotbarInventoryTmp != null) { HotbarInventory = hotbarInventoryTmp.GetComponent<Inventory> (); }	
			}
			if (MainInventory != null) { MainInventory.SetOwner (this.gameObject); MainInventory.TargetTransform = this.transform;}
			if (WeaponInventory != null) { WeaponInventory.SetOwner (this.gameObject); WeaponInventory.TargetTransform = this.transform;}
			if (HotbarInventory != null) { HotbarInventory.SetOwner (this.gameObject); HotbarInventory.TargetTransform = this.transform;}
		}

        /// <summary>
        /// On handle input, we watch for the switch weapon button, and switch weapon if needed
        /// </summary>
		protected override void HandleInput()
        {
            if (!AbilityAuthorized
                || (_condition.CurrentState != CharacterStates.CharacterConditions.Normal))
            {
                return;
            }
            if (_inputManager.SwitchWeaponButton.State.CurrentState == MMInput.ButtonStates.ButtonDown)
			{
				SwitchWeapon ();
			}
		}

        /// <summary>
        /// Fills the weapon list. The weapon list will be used to determine what weapon we can switch to
        /// </summary>
		protected virtual void FillAvailableWeaponsLists()
		{
			_availableWeaponsIDs = new List<string> ();
			if ((CharacterHandleWeapon == null) || (WeaponInventory == null))
			{
				return;
			}
			_availableWeapons = MainInventory.InventoryContains (ItemClasses.Weapon);
			foreach (int index in _availableWeapons)
			{
				_availableWeaponsIDs.Add (MainInventory.Content [index].ItemID);
			}
			if (!InventoryItem.IsNull(WeaponInventory.Content[0]))
			{
				_availableWeaponsIDs.Add (WeaponInventory.Content [0].ItemID);
			}

			_availableWeaponsIDs.Sort ();
		}

        /// <summary>
        /// Determines the name of the next weapon in line
        /// </summary>
		protected virtual void DetermineNextWeaponName ()
		{
			if (InventoryItem.IsNull(WeaponInventory.Content[0]))
			{
				_nextWeaponID = _availableWeaponsIDs [0];
				return;
			}

            if ((_nextWeaponID == _emptySlotWeaponName) || (_nextWeaponID == _initialSlotWeaponName))
            {
                _nextWeaponID = _availableWeaponsIDs[0];
                return;
            }

            for (int i = 0; i < _availableWeaponsIDs.Count; i++)
			{
				if (_availableWeaponsIDs[i] == WeaponInventory.Content[0].ItemID)
				{
					if (i == _availableWeaponsIDs.Count - 1)
					{
                        switch (WeaponRotationMode)
                        {
                            case WeaponRotationModes.AddEmptySlot:
                                _nextWeaponID = _emptySlotWeaponName;
                                return;
                            case WeaponRotationModes.AddInitialWeapon:
                                _nextWeaponID = _initialSlotWeaponName;
                                return;
                        }

						_nextWeaponID = _availableWeaponsIDs [0];
					}
					else
					{
						_nextWeaponID = _availableWeaponsIDs [i+1];
					}
				}
			}
		}

        /// <summary>
        /// Equips the weapon with the name passed in parameters
        /// </summary>
        /// <param name="weaponID"></param>
		protected virtual void EquipWeapon(string weaponID)
        {
            if ((weaponID == _emptySlotWeaponName) && (CharacterHandleWeapon != null))
            {
                MMInventoryEvent.Trigger(MMInventoryEventType.UnEquipRequest, null, WeaponInventoryName, WeaponInventory.Content[0], 0, 0);
                CharacterHandleWeapon.ChangeWeapon(null, _emptySlotWeaponName, false);
                MMInventoryEvent.Trigger(MMInventoryEventType.Redraw, null, WeaponInventory.name, null, 0, 0);
                return;
            }

            if ((weaponID == _initialSlotWeaponName) && (CharacterHandleWeapon != null))
            {
                MMInventoryEvent.Trigger(MMInventoryEventType.UnEquipRequest, null, WeaponInventoryName, WeaponInventory.Content[0], 0, 0);
                CharacterHandleWeapon.ChangeWeapon(CharacterHandleWeapon.InitialWeapon, _emptySlotWeaponName, false);
                MMInventoryEvent.Trigger(MMInventoryEventType.Redraw, null, WeaponInventory.name, null, 0, 0);
                return;
            }

            for (int i = 0; i < MainInventory.Content.Length ; i++)
			{
				if (InventoryItem.IsNull(MainInventory.Content[i]))
				{
					continue;
				}
				if (MainInventory.Content[i].ItemID == weaponID)
				{
					MMInventoryEvent.Trigger(MMInventoryEventType.EquipRequest, null, MainInventory.name, MainInventory.Content[i], 0, i);
					break;
				}
			}
		}

        /// <summary>
        /// Switches to the next weapon in line
        /// </summary>
		protected virtual void SwitchWeapon()
		{
			// if there's no character handle weapon component, we can't switch weapon, we do nothing and exit
			if ((CharacterHandleWeapon == null) || (WeaponInventory == null))
			{
				return;
			}

			FillAvailableWeaponsLists ();

			// if we only have 0 or 1 weapon, there's nothing to switch, we do nothing and exit
			if (_availableWeaponsIDs.Count <= 0)
			{
				return;
			}

			DetermineNextWeaponName ();
			EquipWeapon (_nextWeaponID);
            PlayAbilityStartFeedbacks();
            PlayAbilityStartSfx();
		}

		/// <summary>
		/// Watches for InventoryLoaded events
		/// When an inventory gets loaded, if it's our WeaponInventory, we check if there's already a weapon equipped, and if yes, we equip it
		/// </summary>
		/// <param name="inventoryEvent">Inventory event.</param>
		public virtual void OnMMEvent(MMInventoryEvent inventoryEvent)
		{
			if (inventoryEvent.InventoryEventType == MMInventoryEventType.InventoryLoaded)
			{
				if (inventoryEvent.TargetInventoryName == WeaponInventoryName)
				{
					this.Setup ();
					if (WeaponInventory != null)
					{
						if (!InventoryItem.IsNull (WeaponInventory.Content [0]))
						{
							CharacterHandleWeapon.Setup ();
							WeaponInventory.Content [0].Equip ();
						}
					}
				}
            }
            if (inventoryEvent.InventoryEventType == MMInventoryEventType.Pick)
            {
                bool isSubclass = (inventoryEvent.EventItem.GetType().IsSubclassOf(typeof(InventoryWeapon)));
                bool isClass = (inventoryEvent.EventItem.GetType() == typeof(InventoryWeapon));
                if (isClass || isSubclass)
                {
                    InventoryWeapon inventoryWeapon = (InventoryWeapon)inventoryEvent.EventItem;
                    switch (inventoryWeapon.AutoEquipMode)
                    {
                        case InventoryWeapon.AutoEquipModes.NoAutoEquip:
                            // we do nothing
                            break;

                        case InventoryWeapon.AutoEquipModes.AutoEquip:
                            _nextFrameWeapon = true;
                            _nextFrameWeaponName = inventoryEvent.EventItem.ItemID;
                            break;

                        case InventoryWeapon.AutoEquipModes.AutoEquipIfEmptyHanded:
                            if (CharacterHandleWeapon.CurrentWeapon == null)
                            {
                                _nextFrameWeapon = true;
                                _nextFrameWeaponName = inventoryEvent.EventItem.ItemID;
                            }
                            break;
                    }
                }
            }
        }

        protected override void OnDeath()
        {
            base.OnDeath();
            if (WeaponInventory != null)
            {
                MMInventoryEvent.Trigger(MMInventoryEventType.UnEquipRequest, null, WeaponInventoryName, WeaponInventory.Content[0], 0, 0);
            }            
        }

        /// <summary>
        /// On enable, we start listening for MMGameEvents. You may want to extend that to listen to other types of events.
        /// </summary>
        protected override void OnEnable()
		{
            base.OnEnable();
			this.MMEventStartListening<MMInventoryEvent>();
		}

		/// <summary>
		/// On disable, we stop listening for MMGameEvents. You may want to extend that to stop listening to other types of events.
		/// </summary>
		protected override void OnDisable()
		{
			base.OnDisable ();
			this.MMEventStopListening<MMInventoryEvent>();
		}
	}
}
