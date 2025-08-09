// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.IO;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Data;
using SimPe.Sims2.Models.Resource;
using SimPe.Sims2.Models.Resource.Bcon;
using SimPe.Sims2.Models.Resource.Bhav;
using SimPe.Sims2.Models.Resource.Bnfo;
using SimPe.Sims2.Models.Resource.Cats;
using SimPe.Sims2.Models.Resource.Clst;
using SimPe.Sims2.Models.Resource.Cpf;
using SimPe.Sims2.Models.Resource.Famh;
using SimPe.Sims2.Models.Resource.Fami;
using SimPe.Sims2.Models.Resource.Famt;
using SimPe.Sims2.Models.Resource.Fwav;
using SimPe.Sims2.Models.Resource.Idno;
using SimPe.Sims2.Models.Resource.Lotd;
using SimPe.Sims2.Models.Resource.Ltxt;
using SimPe.Sims2.Models.Resource.Matshad;
using SimPe.Sims2.Models.Resource.Ngbh;
using SimPe.Sims2.Models.Resource.Objd;
using SimPe.Sims2.Models.Resource.Objf;
using SimPe.Sims2.Models.Resource.Picture;
using SimPe.Sims2.Models.Resource.Scid;
using SimPe.Sims2.Models.Resource.Scor;
using SimPe.Sims2.Models.Resource.Sdsc;
using SimPe.Sims2.Models.Resource.Srel;
using SimPe.Sims2.Models.Resource.Str;
using SimPe.Sims2.Models.Resource.Swaf;
using SimPe.Sims2.Models.Resource.ThreeIdr;
using SimPe.Sims2.Models.Resource.Ttab;
using SimPe.Sims2.Models.Resource.Wthr;

namespace SimPe.Sims2.Data;

public static class Wrappers
{
	public static Dictionary<FileTypes, Func<BinaryReader, Resource, IWrapper>> Unserializers { get; } = new()
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
		[FileTypes.LOTD] = Lotd.Unserialize,
	};
}
