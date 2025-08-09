// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Objf;

public enum ObjfFunction : ushort
{
	[DisplayName("init")] Init,
	[DisplayName("main")] Main,
	[DisplayName("load")] Load,
	[DisplayName("cleanup")] Cleanup,
	[DisplayName("queue skipped")] QueueSkipped,
	[DisplayName("allow intersection")] AllowIntersection,

	[DisplayName("wall adjacency changed")]
	WallAdjacencyChanged,
	[DisplayName("room changed")] RoomChanged,

	[DisplayName("dynamic multi-tile update")]
	DynamicMultiTileUpdate,
	[DisplayName("placement")] Placement,
	[DisplayName("pickup")] Pickup,
	[DisplayName("user placement")] UserPlacement,
	[DisplayName("user pickup")] UserPickup,
	[DisplayName("level info request")] LevelInfoRequest,
	[DisplayName("serving surface")] ServingSurface,
	[DisplayName("portal")] Portal,
	[DisplayName("gardening")] Gardening,
	[DisplayName("wash hands")] WashHands,
	[DisplayName("prep")] Prep,
	[DisplayName("cook")] Cook,
	[DisplayName("surface")] Surface,
	[DisplayName("dispose")] Dispose,
	[DisplayName("food")] Food,
	[DisplayName("pickup from slot")] PickupFromSlot,
	[DisplayName("wash dish")] WashDish,
	[DisplayName("eating surface")] EatingSurface,
	[DisplayName("sit")] Sit,
	[DisplayName("stand")] Stand,
	[DisplayName("clean")] Clean,
	[DisplayName("repair")] Repair,
	[DisplayName("ui event")] UIEvent,
	[DisplayName("Restock")] Restock,
	[DisplayName("Wash Clothes")] WashClothes,
	[DisplayName("Start Live Mode")] StartLiveMode,
	[DisplayName("Stop Live Mode")] StopLiveMode,
	[DisplayName("Link Objects")] LinkObjects,
	[DisplayName("Message Handler")] MessageHandler,
	[DisplayName("Pre Route")] PreRoute,
	[DisplayName("Post Route")] PostRoute,
	[DisplayName("Goal Check")] GoalCheck,
	[DisplayName("Reaction Handler")] ReactionHandler,
	[DisplayName("Along Route Callback")] AlongRouteCallback,
	[DisplayName("awareness")] Awareness,
	[DisplayName("reset")] Reset,
	[DisplayName("lookatTarget")] LookAtTarget,
	[DisplayName("Walk Over")] WalkOver,
	[DisplayName("Utility State Change")] UtilityStateChange,
	[DisplayName("Set Model by Type")] SetModelByType,
	[DisplayName("Get Model Type")] GetModelType,
	[DisplayName("delete")] Delete,
	[DisplayName("user delete")] UserDelete,
	[DisplayName("Just Moved In")] JustMovedIn,
	[DisplayName("prevent place in slot")] PreventPlaceInSlot,
	[DisplayName("Global Awareness")] GlobalAwareness,

	[DisplayName("Object Updated by Design Mode")]
	ObjectUpdatedByDesignMode,
}
