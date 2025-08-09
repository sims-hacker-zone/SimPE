// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using System.Text;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Views.Resource.Objd;

namespace SimPe.Sims2.Models.Resource.Objd;

public partial class Objd(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private string resourceName;

	[ObservableProperty] private EnumDisplayNameItem<ObjdVersion> version;

	[ObservableProperty] private ushort initialStackSize;

	[ObservableProperty] private ObjdWallAdjacencyFlags defaultWallAdjacentFlags;

	[ObservableProperty] private ushort defaultPlacementFlags;

	[ObservableProperty] private ushort defaultWallPlacementFlags;

	[ObservableProperty] private ushort defaultAllowedHeightFlags;

	[ObservableProperty] private ushort interactionTableID;

	[ObservableProperty] private ushort interactionGroup;

	[ObservableProperty] private EnumDisplayNameItem<ObjdType> type;

	[ObservableProperty] private ushort multiTileMasterID;

	[ObservableProperty] private ushort multiTileSubIndex;

	[ObservableProperty] private ushort useDefaultPlacementFlags;

	[ObservableProperty] private ushort lookAtScore;

	[ObservableProperty] private uint guid;

	[ObservableProperty] private ushort itemIsUnlockable;

	[ObservableProperty] private CheckableFlagEnum<ObjdCatalogUseFlags> catalogUseFlags;

	[ObservableProperty] private ushort price;

	[ObservableProperty] private ushort bodyStringsID;

	[ObservableProperty] private ushort slotsID;

	[ObservableProperty] private uint diagonalSelectorGUID;

	[ObservableProperty] private uint gridAlignedSelectorGUID;

	[ObservableProperty] private ushort objectOwnershipFlags;

	[ObservableProperty] private ushort ignoreGlobalSimFieldInCASLot;

	[ObservableProperty] private ushort cannotMoveOutWith;

	[ObservableProperty] private ushort hauntable;

	[ObservableProperty] private uint proxyGUID;

	[ObservableProperty] private ushort slotGroup;

	[ObservableProperty] private ushort aspirationFlags;

	[ObservableProperty] private ushort memoryNiceBad;

	[ObservableProperty] private ushort salePrice;

	[ObservableProperty] private ushort initialDepreciation;

	[ObservableProperty] private ushort dailyDepreciation;

	[ObservableProperty] private bool selfDepreciating;

	[ObservableProperty] private ushort depreciationLimit;

	[ObservableProperty] private CheckableFlagEnum<ObjdRoomSortFlags> roomSortFlags;

	[ObservableProperty] private CheckableFlagEnum<ObjdFunctionSortFlags> functionSortFlags;

	[ObservableProperty] private ushort catalogStringsID;

	[ObservableProperty] private ushort isGlobalSimObject;

	[ObservableProperty] private ushort toolTipNameType;

	[ObservableProperty] private ushort templateVersion;

	[ObservableProperty] private ushort nicenessMultiplier;

	[ObservableProperty] private ushort noDuplicateOnPlacement;

	[ObservableProperty] private ushort wantCategory;

	[ObservableProperty] private ushort noNewNameFromTemplate;

	[ObservableProperty] private ushort objectVersion;

	[ObservableProperty] private ushort defaultThumbnailID;

	[ObservableProperty] private ushort motiveEffectsID;

	[ObservableProperty] private uint jobObjectGUID;

	[ObservableProperty] private ushort catalogPopupID;

	[ObservableProperty] private ushort ignoreCurrentModelIndexInIcons;

	[ObservableProperty] private ushort levelOffset;

	[ObservableProperty] private ushort shadowType;

	[ObservableProperty] private ushort numAttributes;

	[ObservableProperty] private ushort numberOfObjectArrays;

	[ObservableProperty] private ushort frontDirection;

	[ObservableProperty] private ushort multiTileLeadObject;

	[ObservableProperty] private ObjdRequiredEPFlags requiredEPFlags;

	[ObservableProperty] private ushort chairEntryFlags;

	[ObservableProperty] private ushort tileWidth;

	[ObservableProperty] private ushort inhibitSuitCopying;

	[ObservableProperty] private CheckableFlagEnum<ObjdBuildModeSort> buildModeSort;

	[ObservableProperty] private uint originalGUID;

	[ObservableProperty] private uint objectModelGUID;

	[ObservableProperty] private ushort footprintMask;

	[ObservableProperty] private ushort extendFootprint;

	[ObservableProperty] private EnumDisplayNameItem<ObjdObjectSize> objectSize;

	[ObservableProperty] private ushort ratingHunger;

	[ObservableProperty] private ushort ratingComfort;

	[ObservableProperty] private ushort ratingHygiene;

	[ObservableProperty] private ushort ratingBladder;

	[ObservableProperty] private ushort ratingEnergy;

	[ObservableProperty] private ushort ratingFun;

	[ObservableProperty] private ushort ratingRoom;

	[ObservableProperty] private ObjdRatingSkillFlags ratingSkillFlags;

	[ObservableProperty] private ushort numTypeAttributes;

	[ObservableProperty] private ushort miscFlags;

	[ObservableProperty] private ushort functionSubSort;

	[ObservableProperty] private ushort downtownSort;

	[ObservableProperty] private ushort keepBuying;

	[ObservableProperty] private ushort vacationSort;

	[ObservableProperty] private ushort resetLotAction;

	[ObservableProperty] private ushort threeDObjectType;

	[ObservableProperty] private ushort communitySort;

	[ObservableProperty] private ushort dreamFlags;

	[ObservableProperty] private ushort thumbnailFlags;

	[ObservableProperty] private ushort ratingScratch;

	[ObservableProperty] private ushort ratingChew;

	[ObservableProperty] private ushort requirements;

	public UserControl Panel { get; set; }

	public string FriendlyName => ResourceName;

	public static IWrapper Unserialize(BinaryReader reader, Resource file)
	{
		Objd objd = new(file);
		reader.ReadBytes(64);
		objd.Version = new((ObjdVersion)reader.ReadUInt32());
		objd.InitialStackSize = reader.ReadUInt16();
		objd.DefaultWallAdjacentFlags = (ObjdWallAdjacencyFlags)reader.ReadUInt16();
		objd.DefaultPlacementFlags = reader.ReadUInt16();
		objd.DefaultWallPlacementFlags = reader.ReadUInt16();
		objd.DefaultAllowedHeightFlags = reader.ReadUInt16();
		objd.InteractionTableID = reader.ReadUInt16();
		objd.InteractionGroup = reader.ReadUInt16();
		objd.Type = new((ObjdType)reader.ReadUInt16());
		objd.MultiTileMasterID = reader.ReadUInt16();
		objd.MultiTileSubIndex = reader.ReadUInt16();
		objd.UseDefaultPlacementFlags = reader.ReadUInt16();
		objd.LookAtScore = reader.ReadUInt16();
		objd.Guid = reader.ReadUInt32();
		objd.ItemIsUnlockable = reader.ReadUInt16();
		objd.CatalogUseFlags = new((ObjdCatalogUseFlags)reader.ReadUInt16());
		objd.Price = reader.ReadUInt16();
		objd.BodyStringsID = reader.ReadUInt16();
		objd.SlotsID = reader.ReadUInt16();
		objd.DiagonalSelectorGUID = reader.ReadUInt32();
		objd.GridAlignedSelectorGUID = reader.ReadUInt32();
		objd.ObjectOwnershipFlags = reader.ReadUInt16();
		objd.IgnoreGlobalSimFieldInCASLot = reader.ReadUInt16();
		objd.CannotMoveOutWith = reader.ReadUInt16();
		objd.Hauntable = reader.ReadUInt16();
		objd.ProxyGUID = reader.ReadUInt32();
		objd.SlotGroup = reader.ReadUInt16();
		objd.AspirationFlags = reader.ReadUInt16();
		objd.MemoryNiceBad = reader.ReadUInt16();
		objd.SalePrice = reader.ReadUInt16();
		objd.InitialDepreciation = reader.ReadUInt16();
		objd.DailyDepreciation = reader.ReadUInt16();
		objd.SelfDepreciating = reader.ReadUInt16() == 1;
		objd.DepreciationLimit = reader.ReadUInt16();
		objd.RoomSortFlags = new((ObjdRoomSortFlags)reader.ReadUInt16());
		objd.FunctionSortFlags = new((ObjdFunctionSortFlags)reader.ReadUInt16());
		objd.CatalogStringsID = reader.ReadUInt16();
		objd.IsGlobalSimObject = reader.ReadUInt16();
		objd.ToolTipNameType = reader.ReadUInt16();
		objd.TemplateVersion = reader.ReadUInt16();
		objd.NicenessMultiplier = reader.ReadUInt16();
		objd.NoDuplicateOnPlacement = reader.ReadUInt16();
		objd.WantCategory = reader.ReadUInt16();
		objd.NoNewNameFromTemplate = reader.ReadUInt16();
		objd.ObjectVersion = reader.ReadUInt16();
		objd.DefaultThumbnailID = reader.ReadUInt16();
		objd.MotiveEffectsID = reader.ReadUInt16();
		objd.JobObjectGUID = reader.ReadUInt32();
		objd.CatalogPopupID = reader.ReadUInt16();
		objd.IgnoreCurrentModelIndexInIcons = reader.ReadUInt16();
		objd.LevelOffset = reader.ReadUInt16();
		objd.ShadowType = reader.ReadUInt16();
		objd.NumAttributes = reader.ReadUInt16();
		objd.NumberOfObjectArrays = reader.ReadUInt16();
		reader.ReadUInt16();
		objd.FrontDirection = reader.ReadUInt16();
		reader.ReadUInt16();
		objd.MultiTileLeadObject = reader.ReadUInt16();
		objd.RequiredEPFlags = (ObjdRequiredEPFlags)reader.ReadUInt32();
		objd.ChairEntryFlags = reader.ReadUInt16();
		objd.TileWidth = reader.ReadUInt16();
		objd.InhibitSuitCopying = reader.ReadUInt16();
		objd.BuildModeSort = new((ObjdBuildModeSort)((uint)reader.ReadUInt16() << 16));
		objd.OriginalGUID = reader.ReadUInt32();
		objd.ObjectModelGUID = reader.ReadUInt32();
		objd.BuildModeSort.Value |= (ObjdBuildModeSort)reader.ReadUInt16();
		reader.ReadUInt16();
		reader.ReadUInt16();
		objd.FootprintMask = reader.ReadUInt16();
		objd.ExtendFootprint = reader.ReadUInt16();
		objd.ObjectSize = new((ObjdObjectSize)reader.ReadUInt16());
		reader.ReadUInt16();
		reader.ReadUInt16();
		objd.RatingHunger = reader.ReadUInt16();
		objd.RatingComfort = reader.ReadUInt16();
		objd.RatingHygiene = reader.ReadUInt16();
		objd.RatingBladder = reader.ReadUInt16();
		objd.RatingEnergy = reader.ReadUInt16();
		objd.RatingFun = reader.ReadUInt16();
		objd.RatingRoom = reader.ReadUInt16();
		objd.RatingSkillFlags = (ObjdRatingSkillFlags)reader.ReadUInt16();
		objd.NumTypeAttributes = reader.ReadUInt16();
		objd.MiscFlags = reader.ReadUInt16();
		reader.ReadUInt16();
		reader.ReadUInt16();
		objd.FunctionSubSort = reader.ReadUInt16();
		objd.DowntownSort = reader.ReadUInt16();
		objd.KeepBuying = reader.ReadUInt16();
		objd.VacationSort = reader.ReadUInt16();
		objd.ResetLotAction = reader.ReadUInt16();
		objd.ThreeDObjectType = reader.ReadUInt16();
		objd.CommunitySort = reader.ReadUInt16();
		objd.DreamFlags = reader.ReadUInt16();
		objd.ThumbnailFlags = reader.ReadUInt16();
		objd.RatingScratch = reader.ReadUInt16();
		objd.RatingChew = reader.ReadUInt16();
		reader.ReadUInt16();
		reader.ReadUInt16();
		objd.Requirements = reader.ReadUInt16();
		int nameLength = reader.ReadInt32();
		objd.ResourceName = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
		objd.Panel = new ObjdPanel() { DataContext = objd };
		return objd;
	}

	public void Serialize(BinaryWriter writer)
	{
		throw new System.NotImplementedException();
	}
}
