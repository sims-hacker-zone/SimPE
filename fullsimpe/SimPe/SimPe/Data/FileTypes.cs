// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Extensions;

namespace SimPe.Data
{
	public enum FileTypes : uint
	{
		[FileType(DisplayName = "---  All Types ---")]
		ALL_TYPES = 0xFFFFFFFF,
		/// <summary>
		/// Sim DNA
		/// </summary>
		[FileType(DisplayName = "Sim DNA")]
		SDNA = 0xEBFEE33F,
		/// <summary>
		/// Property Set
		/// </summary>
		[FileType(DisplayName = "Property Set")]
		GZPS = 0xEBCF3E27,
		/// <summary>
		/// Wants XML
		/// </summary>
		[FileType(DisplayName = "Wants XML", Extension = "xml")]
		XWNT = 0xED7D7B4D,
		/// <summary>
		/// ID Number
		/// </summary>
		[FileType(DisplayName = "ID Number")]
		IDNO = 0xAC8A7A2E,
		/// <summary>
		/// House Descriptor
		/// </summary>
		[FileType(DisplayName = "House Descriptor")]
		HOUS = 0x484F5553,
		/// <summary>
		/// Slot File
		/// </summary>
		[FileType(DisplayName = "Slot File", ContainsFileName = true)]
		SLOT = 0x534C4F54,
		/// <summary>
		/// Geometric Node
		/// </summary>
		[FileType(DisplayName = "Geometric Node", Extension = "5gn")]
		GMND = 0x7BA3838C,
		/// <summary>
		/// Material Definition
		/// </summary>
		[FileType(DisplayName = "Material Definition", Extension = "5tm")]
		TXMT = 0x49596978,
		/// <summary>
		/// Texture Image
		/// </summary>
		[FileType(DisplayName = "Texture Image", Extension = "6tx")]
		TXTR = 0x1C4A276C,
		/// <summary>
		/// Large Image File
		/// </summary>
		[FileType(DisplayName = "Large Image File", Extension = "6li")]
		LIFO = 0xED534136,
		/// <summary>
		/// Animation Resource
		/// </summary>
		[FileType(DisplayName = "Animation Resource", Extension = "5an")]
		ANIM = 0xFB00791E,
		/// <summary>
		/// Shape
		/// </summary>
		[FileType(DisplayName = "Shape", Extension = "5sh")]
		SHPE = 0xFC6EB1F7,
		/// <summary>
		/// Resource Node
		/// </summary>
		[FileType(DisplayName = "Resource Node", Extension = "5cr")]
		CRES = 0xE519C933,
		/// <summary>
		/// Geometric Data Container
		/// </summary>
		[FileType(DisplayName = "Geometric Data Container", Extension = "5gd")]
		GMDC = 0xAC4F8687,
		/// <summary>
		/// Lighting (Directional Light)
		/// </summary>
		[FileType(DisplayName = "Lighting (Directional Light)", Extension = "5dl")]
		LDIR = 0xC9C81B9B,
		/// <summary>
		/// Lighting (Ambient Light)
		/// </summary>
		[FileType(DisplayName = "Lighting (Ambient Light)", Extension = "5al")]
		LAMB = 0xC9C81BA3,
		/// <summary>
		/// Lighting (Point Light)
		/// </summary>
		[FileType(DisplayName = "Lighting (Point Light)", Extension = "5pl")]
		LPNT = 0xC9C81BA9,
		/// <summary>
		/// Lighting (Spot Light)
		/// </summary>
		[FileType(DisplayName = "Lighting (Spot Light)", Extension = "5sl")]
		LSPT = 0xC9C81BAD,
		/// <summary>
		/// Material Override
		/// </summary>
		[FileType(DisplayName = "Material Override")]
		MMAT = 0x4C697E5A,
		/// <summary>
		/// Object XML
		/// </summary>
		[FileType(DisplayName = "Object XML", Extension = "xml")]
		XOBJ = 0xCCA8E925,
		/// <summary>
		/// Roof XML
		/// </summary>
		[FileType(DisplayName = "Roof XML", Extension = "xml")]
		XROF = 0xACA8EA06,
		/// <summary>
		/// Floor XML
		/// </summary>
		[FileType(DisplayName = "Floor XML", Extension = "xml")]
		XFLR = 0x4DCADB7E,
		/// <summary>
		/// Fence XML
		/// </summary>
		[FileType(DisplayName = "Fence XML", Extension = "xml")]
		XFNC = 0x2CB230B8,
		/// <summary>
		/// Neighborhood Object XML
		/// </summary>
		[FileType(DisplayName = "Neighborhood Object XML", Extension = "xml")]
		XNGB = 0x6D619378,
		/// <summary>
		/// Global Object Lua
		/// </summary>
		[FileType(DisplayName = "Global Object Lua")]
		GLUA = 0x9012468A,
		/// <summary>
		/// Object Lua
		/// </summary>
		[FileType(DisplayName = "Object Lua")]
		OLUA = 0x9012468B,
		/// <summary>
		/// Game Wide Inventory
		/// </summary>
		[FileType(DisplayName = "Game Wide Inventory")]
		GINV = 0x0ABA73AF,
		/// <summary>
		/// Hair Tone XML
		/// </summary>
		[FileType(DisplayName = "Hair Tone XML", Extension = "xml")]
		XHTN = 0x8C1580B5,
		/// <summary>
		/// Texture Overlay XML
		/// </summary>
		[FileType(DisplayName = "Texture Overlay XML", Extension = "xml")]
		XTOL = 0x2C1FD8A1,
		/// <summary>
		/// Mesh Overlay XML
		/// </summary>
		[FileType(DisplayName = "Mesh Overlay XML", Extension = "xml")]
		XMOL = 0x0C1FE246,
		/// <summary>
		/// Skin Tone XML
		/// </summary>
		[FileType(DisplayName = "Skin Tone XML", Extension = "xml")]
		XSTN = 0x4C158081,
		/// <summary>
		/// Age Data
		/// </summary>
		[FileType(DisplayName = "Age Data")]
		AGED = 0xAC598EAC,
		/// <summary>
		/// Facial Structure
		/// </summary>
		[FileType(DisplayName = "Facial Structure")]
		LxNR = 0xCCCEF852,
		/// <summary>
		/// Binary Index
		/// </summary>
		[FileType(DisplayName = "Binary Index")]
		BINX = 0x0C560F39,
		/// <summary>
		/// Sim Description
		/// </summary>
		[FileType(DisplayName = "Sim Description")]
		SDSC = 0xAACE2EFB,
		/// <summary>
		/// Family Ties
		/// </summary>
		[FileType(DisplayName = "Family Ties")]
		FAMT = 0x8C870743,
		/// <summary>
		/// Name Map
		/// </summary>
		[FileType(DisplayName = "Name Map")]
		NMAP = 0x4E6D6150,
		/// <summary>
		/// 3D ID Referencing File
		/// </summary>
		[FileType(DisplayName = "3D ID Referencing File")]
		THREE_IDR = 0xAC506764,
		/// <summary>
		/// Neighborhood Memory
		/// </summary>
		[FileType(DisplayName = "Neighborhood Memory")]
		NGBH = 0x4E474248,
		/// <summary>
		/// Catalog Description
		/// </summary>
		[FileType(DisplayName = "Catalog Description")]
		CTSS = 0x43545353,
		/// <summary>
		/// Object Data
		/// </summary>
		[FileType(DisplayName = "Object Data", ContainsFileName = true)]
		OBJD = 0x4F424A44,
		/// <summary>
		/// Global Data
		/// </summary>
		[FileType(DisplayName = "Global Data", ContainsFileName = true)]
		GLOB = 0x474C4F42,
		/// <summary>
		/// Behavior Function
		/// </summary>
		[FileType(DisplayName = "Behavior Function", ContainsFileName = true)]
		BHAV = 0x42484156,
		/// <summary>
		/// Text Lists
		/// </summary>
		[FileType(DisplayName = "Text Lists", ContainsFileName = true)]
		STR = 0x53545223,
		/// <summary>
		/// Sim Relations
		/// </summary>
		[FileType(DisplayName = "Sim Relations")]
		SREL = 0xCC364C2A,
		/// <summary>
		/// Pie Menu Strings
		/// </summary>
		[FileType(DisplayName = "Pie Menu Strings", ContainsFileName = true)]
		TTAs = 0x54544173,
		/// <summary>
		/// Pie Menu Functions
		/// </summary>
		[FileType(DisplayName = "Pie Menu Functions", ContainsFileName = true)]
		TTAB = 0x54544142,
		/// <summary>
		/// Lot Description
		/// </summary>
		[FileType(DisplayName = "Lot Description")]
		LTXT = 0x0BF999E7,
		/// <summary>
		/// Directory of Compressed Files
		/// </summary>
		[FileType(DisplayName = "Directory of Compressed Files", Extension = "dir")]
		CLST = 0xE86B1EEF,
		/// <summary>
		/// Weather Info
		/// </summary>
		[FileType(DisplayName = "Weather Info")]
		WTHR = 0xB21BE28B,
		/// <summary>
		/// Wall Layer
		/// </summary>
		[FileType(DisplayName = "Wall Layer")]
		WLAY = 0x8A84D7B0,
		/// <summary>
		/// Behaviour Constant Labels
		/// </summary>
		[FileType(DisplayName = "Behavior Constant Labels")]
		TRCN = 0x5452434E,
		/// <summary>
		/// Edith Simantics Behavior Labels
		/// </summary>
		[FileType(DisplayName = "Edith Simantics Behavior Labels", ContainsFileName = true)]
		TPRP = 0x54505250,
		/// <summary>
		/// Edith Flowchart Trees
		/// </summary>
		[FileType(DisplayName = "Edith Flowchart Trees", ContainsFileName = true)]
		TREE = 0x54524545,
		/// <summary>
		/// Game Tip
		/// </summary>
		[FileType(DisplayName = "Game Tip")]
		GTIP = 0xB1827A47,
		/// <summary>
		/// Previous EP Version Run
		/// </summary>
		[FileType(DisplayName = "Previous EP Version Run")]
		PEPV = 0xCC8A6A69,
		/// <summary>
		/// String Map
		/// </summary>
		[FileType(DisplayName = "String Map")]
		SMAP = 0xCAC4FC40,
		/// <summary>
		/// Family History
		/// </summary>
		[FileType(DisplayName = "Family History")]
		FAMH = 0x46414D68,
		/// <summary>
		/// Sim Scores
		/// </summary>
		[FileType(DisplayName = "Sim Scores")]
		SCOR = 0x3053CF74,
		/// <summary>
		/// Object Functions
		/// </summary>
		[FileType(DisplayName = "Object Functions", ContainsFileName = true)]
		OBJf = 0x4F424A66,
		/// <summary>
		/// Groups Cache
		/// </summary>
		[FileType(DisplayName = "Groups Cache")]
		GROP = 0x54535053,
		/// <summary>
		/// Road Texture
		/// </summary>
		[FileType(DisplayName = "Road Texture")]
		RTEX = 0xACE46235,
		/// <summary>
		/// Accelerator Key Definitions
		/// </summary>
		[FileType(DisplayName = "Accelerator Key Definitions")]
		KEYD = 0xA2E3D533,
		/// <summary>
		/// Package Text
		/// </summary>
		[FileType(DisplayName = "Package Text")]
		PTBP = 0x50544250,
		/// <summary>
		/// Popups
		/// </summary>
		[FileType(DisplayName = "Popups")]
		POPS = 0x2C310F46,
		/// <summary>
		/// Lot Definition
		/// </summary>
		[FileType(DisplayName = "Lot Definition")]
		LOTD = 0x6C589723,
		/// <summary>
		/// Cinematic Scene
		/// </summary>
		[FileType(DisplayName = "Cinematic Scene", Extension = "5cs")]
		CINE = 0x4D51F042,
		/// <summary>
		/// Lot Texture
		/// </summary>
		[FileType(DisplayName = "Lot Texture")]
		LTTX = 0x4B58975B,
		/// <summary>
		/// Single Sim Memory
		/// </summary>
		[FileType(DisplayName = "Single Sim Memory")]
		SMEM = 0xCDB8BDC4,
		/// <summary>
		/// Neighbor ID Mapping
		/// </summary>
		[FileType(DisplayName = "Neighbor ID Mapping")]
		NIDM = 0x2DB5C0F4,
		/// <summary>
		/// Neighborhood Terrain
		/// </summary>
		[FileType(DisplayName = "Neighborhood Terrain")]
		NHTR = 0xABD0DC63,
		/// <summary>
		/// Catalog String
		/// </summary>
		[FileType(DisplayName = "Catalog String")]
		CATS = 0x43415453,
		/// <summary>
		/// Audio Reference
		/// </summary>
		[FileType(DisplayName = "Audio Reference", ContainsFileName = true)]
		FWAV = 0x46574156,
		/// <summary>
		/// Function
		/// </summary>
		[FileType(DisplayName = "Function")]
		FCNS = 0x46434E53,
		/// <summary>
		/// Maxis Material Shader
		/// </summary>
		[FileType(DisplayName = "Maxis Material Shader", Extension = "matshad")]
		MATSHAD = 0xCD7FE87A,
		/// <summary>
		/// Unlockable Rewards
		/// </summary>
		[FileType(DisplayName = "Unlockable Rewards")]
		REW = 0x7181C501,
		/// <summary>
		/// Track Settings
		/// </summary>
		[FileType(DisplayName = "Track Settings")]
		TRKS = 0x0B9EB87E,
		/// <summary>
		/// UI Data
		/// </summary>
		[FileType(DisplayName = "UI Data", Extension = "uiScript")]
		UI = 0x00000000,
		/// <summary>
		/// Behaviour Constant
		/// </summary>
		[FileType(DisplayName = "Behaviour Constant", ContainsFileName = true)]
		BCON = 0x42434F4E,
		/// <summary>
		/// TATT
		/// </summary>
		[FileType(DisplayName = "TATT", ContainsFileName = true)]
		TATT = 0x54415454,
		/// <summary>
		/// Inventory Item
		/// </summary>
		[FileType(DisplayName = "Inventory Item")]
		INIT = 0x4F6FD33D,
		/// <summary>
		/// Inventory Item Index
		/// </summary>
		[FileType(DisplayName = "Inventory Item Index")]
		IIDX = 0x0F9F0C21,
		/// <summary>
		/// Object
		/// </summary>
		[FileType(DisplayName = "Object")]
		OBJT = 0x6F626A74,
		/// <summary>
		/// Castaway Mission Goal
		/// </summary>
		[FileType(DisplayName = "Castaway Mission Goal")]
		GOAL = 0xBEEF7B4D,
		/// <summary>
		/// Sim Wants and Fears
		/// </summary>
		[FileType(DisplayName = "Sim Wants and Fears")]
		SWAF = 0xCD95548E,
		/// <summary>
		/// Content Registry
		/// </summary>
		[FileType(DisplayName = "Content Registry")]
		CREG = 0xCDB467B8,
		/// <summary>
		/// Sim Creation Index
		/// </summary>
		[FileType(DisplayName = "Sim Creation Index")]
		SCID = 0xCC2A6A34,
		/// <summary>
		/// Name Reference
		/// </summary>
		[FileType(DisplayName = "Name Reference")]
		NREF = 0x4E524546,
		/// <summary>
		/// Family Information
		/// </summary>
		[FileType(DisplayName = "Family Information")]
		FAMI = 0x46414D49,
		/// <summary>
		/// Business Info
		/// </summary>
		[FileType(DisplayName = "Business Info")]
		BNFO = 0x104F6A6E,
		/// <summary>
		/// Version Information
		/// </summary>
		[FileType(DisplayName = "Version Information")]
		VERS = 0xEBFEE342,
		/// <summary>
		/// Face Region XML
		/// </summary>
		[FileType(DisplayName = "Face Region XML", Extension = "xml")]
		XFRG = 0x8C93BF6C,
		/// <summary>
		/// Face Neural XML
		/// </summary>
		[FileType(DisplayName = "Face Neural XML", Extension = "xml")]
		XFNU = 0x6C93B566,
		/// <summary>
		/// Face Modifier XML
		/// </summary>
		[FileType(DisplayName = "Face Modifier XML", Extension = "xml")]
		XFMD = 0x0C93E3DE,
		/// <summary>
		/// Face Arch XML
		/// </summary>
		[FileType(DisplayName = "Face Arch XML", Extension = "xml")]
		XFCH = 0x8C93E35C,
		/// <summary>
		/// Pet Body Options
		/// </summary>
		[FileType(DisplayName = "Pet Body Options")]
		PBOP = 0xD1954460,
		/// <summary>
		/// Collection
		/// </summary>
		[FileType(DisplayName = "Collection")]
		COLL = 0x6C4F359D,
		/// <summary>
		/// Thumbnail
		/// </summary>
		[FileType(DisplayName = "Thumbnail", Extension = "jpg")]
		THUB = 0xAC2950C1,
		/// <summary>
		/// Roof Thumbnail
		/// </summary>
		[FileType(DisplayName = "Roof Thumbnail", Extension = "jpg")]
		THUMB_ROOF = 0xCC489E46,
		/// <summary>
		/// Fence Thumbnail
		/// </summary>
		[FileType(DisplayName = "Fence Thumbnail", Extension = "jpg")]
		THUMB_FENCE = 0xCC30CDF8,
		/// <summary>
		/// Terrain Thumbnail
		/// </summary>
		[FileType(DisplayName = "Terrain Thumbnail", Extension = "jpg")]
		THUMB_TERRAIN = 0xEC3126C4,
		/// <summary>
		/// Neighborhood Object Thumbnail
		/// </summary>
		[FileType(DisplayName = "Neighborhood Object Thumbnail", Extension = "jpg")]
		THUMB_NHOBJ = 0x4D533EDD,
		/// <summary>
		/// Floor Thumbnail
		/// </summary>
		[FileType(DisplayName = "Floor Thumbnail", Extension = "jpg")]
		THUMB_FLOOR = 0x8C311262,
		/// <summary>
		/// Wall Thumbnail
		/// </summary>
		[FileType(DisplayName = "Wall Thumbnail", Extension = "jpg")]
		THUMB_WALL = 0x8C31125E,
		/// <summary>
		/// jpg/tga/png Image
		/// </summary>
		[FileType(DisplayName = "jpg/tga/png Image", Extension = "jpg")] // TODO(autinerd): Check if really all three picture formats are in this type
		IMG = 0x856DDBAC,
		/// <summary>
		/// Family Thumbnail
		/// </summary>
		[FileType(DisplayName = "Family Thumbnail", Extension = "jpg")]
		THUMB_FAMILY = 0x8C3CE95A,
		/// <summary>
		/// SimPE Object Lua
		/// </summary>
		[FileType(DisplayName = "SimPE Object Lua", ContainsFileName = true)]
		SLUA = 0x61754C1B,
		/// <summary>
		/// Neighborhood Terrain Geometry
		/// </summary>
		[FileType(DisplayName = "Neighborhood Terrain Geometry")]
		NHTG = 0xABCB5DA4,
		/// <summary>
		/// Lot Terrain Geometry
		/// </summary>
		[FileType(DisplayName = "Lot Terrain Geometry")]
		LOTG = 0x6B943B43,
		/// <summary>
		/// 3D Array
		/// </summary>
		[FileType(DisplayName = "3D Array")]
		THREE_ARY = 0x2A51171B,
		/// <summary>
		/// Audio Test
		/// </summary>
		[FileType(DisplayName = "Audio Test")]
		AUDT = 0xEBFEE345,
		/// <summary>
		/// Bitmap Image
		/// </summary>
		[FileType(DisplayName = "Bitmap Image", Extension = "bmp", ContainsFileName = true)]
		BMP = 0x424D505F,
		/// <summary>
		/// Layered Image
		/// </summary>
		[FileType(DisplayName = "Layered Image")]
		DGRP = 0x44475250,
		/// <summary>
		/// Effects List
		/// </summary>
		[FileType(DisplayName = "Effects List", Extension = "fx")]
		FX = 0xEA5118B0,
		/// <summary>
		/// Face Properties
		/// </summary>
		[FileType(DisplayName = "Face Properties")]
		FACE = 0x46414345,
		/// <summary>
		/// Fence Post Layer
		/// </summary>
		[FileType(DisplayName = "Fence Post Layer")]
		FPST = 0xAB4BA572,
		/// <summary>
		/// FX Sound
		/// </summary>
		[FileType(DisplayName = "FX Sound")]
		FXSD = 0x8DB5E4C2,
		/// <summary>
		/// JPEG Image
		/// </summary>
		[FileType(DisplayName = "JPEG Image", Extension = "jpg")]
		JPG = 0x0C7E9A76,
		/// <summary>
		/// Lighting (Draw State Light)
		/// </summary>
		[FileType(DisplayName = "Lighting (Draw State Light)", Extension = "5ds")]
		LDRS = 0xAC06A676,
		/// <summary>
		/// Lighting (Environment Cube Light)
		/// </summary>
		[FileType(DisplayName = "Lighting (Environment Cube Light)", Extension = "5el")]
		LENC = 0x6A97042F,
		/// <summary>
		/// Lighting (Linear Fog Light)
		/// </summary>
		[FileType(DisplayName = "Lighting (Linear Fog Light)", Extension = "5lf")]
		LLIF = 0xAC06A66F,
		/// <summary>
		/// Object Material?
		/// </summary>
		[FileType(DisplayName = "Object Material?")]
		OBJM = 0x4F626A4D,
		/// <summary>
		/// Object
		/// </summary>
		[FileType(DisplayName = "Object")]
		OBJT2 = 0xFA1C39F7,
		/// <summary>
		/// Image Color Palette (Version 1)
		/// </summary>
		[FileType(DisplayName = "Image Color Palette (Version 1)")]
		PALT = 0x50414C54,
		/// <summary>
		/// Stack Script
		/// </summary>
		[FileType(DisplayName = "Stack Script")]
		POSI = 0x504F5349,
		/// <summary>
		/// UNK: 0x8CC0A14B
		/// </summary>
		[FileType(DisplayName = "UNK: 0x8CC0A14B")]
		SDBA = 0x8CC0A14B,
		/// <summary>
		/// Sim Information
		/// </summary>
		[FileType(DisplayName = "Sim Information")]
		SIMI = 0x53494D49,
		/// <summary>
		/// Sprites
		/// </summary>
		[FileType(DisplayName = "Sprites", ContainsFileName = true)]
		SPR2 = 0x53505232,
		/// <summary>
		/// mp3 or xa Sound File
		/// </summary>
		[FileType(DisplayName = "mp3 or xa Sound File", Extension = "mp3")]
		MP3 = 0x2026960B,
		/// <summary>
		/// TSSG System
		/// </summary>
		[FileType(DisplayName = "TSSG System")]
		TSSG = 0xBA353CE1,
		/// <summary>
		/// Vertex
		/// </summary>
		[FileType(DisplayName = "Vertex")]
		VERT = 0xCB4387A1,
		/// <summary>
		/// Wall Graph
		/// </summary>
		[FileType(DisplayName = "Wall Graph")]
		WGRA = 0x0A284D0B,
		/// <summary>
		/// World Database
		/// </summary>
		[FileType(DisplayName = "World Database")]
		WRLD = 0x49FF7D76,
		/// <summary>
		/// Material Object?
		/// </summary>
		[FileType(DisplayName = "Material Object?")]
		XMTO = 0x584D544F,
		/// <summary>
		/// Object XML
		/// </summary>
		[FileType(DisplayName = "Object XML", Extension = "xml")]
		XOBJ2 = 0x584F424A,
		/// <summary>
		/// Wants Tree Item
		/// </summary>
		[FileType(DisplayName = "Wants Tree Item", Extension = "xml")]
		WNTT = 0x6D814AFE,
		/// <summary>
		/// Light Override
		/// </summary>
		[FileType(DisplayName = "Light Override", Extension = "nlo")]
		NLO = 0xADEE8D84,
		/// <summary>
		/// Scene Node
		/// </summary>
		[FileType(DisplayName = "Scene Node", Extension = "5sc")]
		SCEN = 0x25232B11,
		/// <summary>
		/// Fence Arch Thumbnail
		/// </summary>
		[FileType(DisplayName = "Fence Arch Thumbnail", Extension = "jpg")]
		THUMB_FARC = 0x2C30E040,
		/// <summary>
		/// Foundation or Pool Thumbnail
		/// </summary>
		[FileType(DisplayName = "Foundation or Pool Thumbnail", Extension = "jpg")]
		THUMB_POOL = 0x2C43CBD4,
		/// <summary>
		/// Dormer Thmbnail
		/// </summary>
		[FileType(DisplayName = "Dormer Thmbnail", Extension = "jpg")]
		THUMB_DORM = 0x2C488BCA,
		/// <summary>
		/// Modular Stair Thumbnail
		/// </summary>
		[FileType(DisplayName = "Modular Stair Thumbnail", Extension = "jpg")]
		THUMB_MODST = 0xCC44B5EC,
		/// <summary>
		/// Chimney Thumbnail
		/// </summary>
		[FileType(DisplayName = "Chimney Thumbnail", Extension = "jpg")]
		THUMB_CHIM = 0xCC48C51F,
		/// <summary>
		/// Awning Thumbnail
		/// </summary>
		[FileType(DisplayName = "Awning Thumbnail", Extension = "jpg")]
		THUMB_AWN = 0xF03D464C,
	}
}
