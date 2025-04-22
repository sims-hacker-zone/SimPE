// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.IO;

using SimPe.Models.Interfaces;
using SimPe.Models.PackedFile;
using SimPe.Models.PackedFile.Bcon;
using SimPe.Models.PackedFile.Bhav;
using SimPe.Models.PackedFile.Bnfo;
using SimPe.Models.PackedFile.Cats;
using SimPe.Models.PackedFile.Clst;
using SimPe.Models.PackedFile.Cpf;
using SimPe.Models.PackedFile.Famh;
using SimPe.Models.PackedFile.Fami;
using SimPe.Models.PackedFile.Famt;
using SimPe.Models.PackedFile.Fwav;
using SimPe.Models.PackedFile.Idno;
using SimPe.Models.PackedFile.Ltxt;
using SimPe.Models.PackedFile.Matshad;
using SimPe.Models.PackedFile.Ngbh;
using SimPe.Models.PackedFile.Objd;
using SimPe.Models.PackedFile.Objf;
using SimPe.Models.PackedFile.Picture;
using SimPe.Models.PackedFile.Scid;
using SimPe.Models.PackedFile.Scor;
using SimPe.Models.PackedFile.Sdsc;
using SimPe.Models.PackedFile.Srel;
using SimPe.Models.PackedFile.Str;
using SimPe.Models.PackedFile.Swaf;
using SimPe.Models.PackedFile.ThreeIdr;
using SimPe.Models.PackedFile.Ttab;
using SimPe.Models.PackedFile.Wthr;

namespace SimPe.Data
{
	public static class Wrappers
	{
		public static Dictionary<FileTypes, Func<BinaryReader, PackedFile, IWrapper>> Unserializers
		{
			get;
		} = new()
		{
			[FileTypes.CLST] = Clst.Unserialize,
			[FileTypes.IDNO] = Idno.Unserialize,
			[FileTypes.STR] = Str.Unserialize,
			[FileTypes.CTSS] = Str.Unserialize,
			[FileTypes.TTAs] = Str.Unserialize,
			[FileTypes.BMP] = Picture.Unserialize,
			[FileTypes.IMG] = Picture.Unserialize,
			[FileTypes.FWAV] = Fwav.Unserialize,
			[FileTypes.CATS] = Cats.Unserialize,
			[FileTypes.TTAB] = Ttab.Unserialize,
			[FileTypes.VERS] = Cpf.Unserialize,
			[FileTypes.GZPS] = Cpf.Unserialize,
			[FileTypes.BINX] = Cpf.Unserialize,
			[FileTypes.SDNA] = Cpf.Unserialize,
			[FileTypes.XTOL] = Cpf.Unserialize,
			[FileTypes.XOBJ] = Cpf.Unserialize,
			[FileTypes.XSTN] = Cpf.Unserialize,
			[FileTypes.XMOL] = Cpf.Unserialize,
			[FileTypes.XHTN] = Cpf.Unserialize,
			[FileTypes.XFRG] = Cpf.Unserialize,
			[FileTypes.XFNU] = Cpf.Unserialize,
			[FileTypes.XFMD] = Cpf.Unserialize,
			[FileTypes.XFCH] = Cpf.Unserialize,
			[FileTypes.XROF] = Cpf.Unserialize,
			[FileTypes.XFLR] = Cpf.Unserialize,
			[FileTypes.XFNC] = Cpf.Unserialize,
			[FileTypes.XNGB] = Cpf.Unserialize,
			[FileTypes.PBOP] = Cpf.Unserialize,
			[FileTypes.COLL] = Cpf.Unserialize,
			[FileTypes.AGED] = Cpf.Unserialize,
			[FileTypes.LTXT] = Ltxt.Unserialize,
			[FileTypes.FAMI] = Fami.Unserialize,
			[FileTypes.SCID] = Scid.Unserialize,
			[FileTypes.SDSC] = Sdsc.Unserialize,
			[FileTypes.THREE_IDR] = ThreeIdr.Unserialize,
			[FileTypes.SREL] = Srel.Unserialize,
			[FileTypes.SWAF] = Swaf.Unserialize,
			[FileTypes.OBJD] = Objd.Unserialize,
			[FileTypes.NGBH] = Ngbh.Unserialize,
			[FileTypes.FAMT] = Famt.Unserialize,
			[FileTypes.FAMH] = Famh.Unserialize,
			[FileTypes.SCOR] = Scor.Unserialize,
			[FileTypes.WTHR] = Wthr.Unserialize,
			[FileTypes.BHAV] = Bhav.Unserialize,
			[FileTypes.THUMB_FAMILY] = Picture.Unserialize,
			[FileTypes.THUMB_AWN] = Picture.Unserialize,
			[FileTypes.THUMB_CHIM] = Picture.Unserialize,
			[FileTypes.THUMB_DORM] = Picture.Unserialize,
			[FileTypes.THUB] = Picture.Unserialize,
			[FileTypes.THUMB_FARC] = Picture.Unserialize,
			[FileTypes.THUMB_FENCE] = Picture.Unserialize,
			[FileTypes.THUMB_FLOOR] = Picture.Unserialize,
			[FileTypes.THUMB_MODST] = Picture.Unserialize,
			[FileTypes.THUMB_NHOBJ] = Picture.Unserialize,
			[FileTypes.THUMB_POOL] = Picture.Unserialize,
			[FileTypes.THUMB_ROOF] = Picture.Unserialize,
			[FileTypes.THUMB_TERRAIN] = Picture.Unserialize,
			[FileTypes.THUMB_WALL] = Picture.Unserialize,
			[FileTypes.BCON] = Bcon.Unserialize,
			[FileTypes.BNFO] = Bnfo.Unserialize,
			[FileTypes.OBJf] = Objf.Unserialize,
			[FileTypes.MATSHAD] = Matshad.Unserialize,
		};
	}
}
