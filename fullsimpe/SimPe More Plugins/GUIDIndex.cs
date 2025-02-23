/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections;
using System.Resources;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace pjse
{
    public class GUIDIndex : IDictionary<uint, string>
    {
        public struct IndexItem
        {
            public string objdName;
            public uint objdGroup;
            public ushort objdType;
            public uint semiGlobal;
        }
        private Dictionary<uint, IndexItem> guidIndex = null;
        //private Hashtable guidIndex = null;

        public static GUIDIndex TheGUIDIndex = new GUIDIndex();
        public static String DefaultGUIDFile = Path.Combine(SimPe.Helper.SimPePluginDataPath, "pjse.coder.plugin\\guidindex.txt");
        static GUIDIndex()
        {
            if (Settings.PJSE.LoadGUIDIndexAtStartup) TheGUIDIndex.Load();
        }

        public void Create() { Create(false); }
        public void Create(bool fromCurrent)
        {
            guidIndex = new Dictionary<uint, IndexItem>();
            pjse.FileTable.Entry[] items = (fromCurrent && pjse.FileTable.GFT.CurrentPackage != null)
                ? pjse.FileTable.GFT[pjse.FileTable.GFT.CurrentPackage, SimPe.Data.MetaData.OBJD_FILE]
                : pjse.FileTable.GFT[SimPe.Data.MetaData.OBJD_FILE];

            SimPe.Wait.Start(items.Length);
            try
            {
                foreach (pjse.FileTable.Entry item in items)
                {
                    System.Windows.Forms.Application.DoEvents();
                    try
                    {
                        SimPe.Interfaces.Plugin.AbstractWrapper wrapper = item.Wrapper;
                        if (wrapper == null) continue;

                        IndexItem ii = new IndexItem();

                        pjse.FileTable.Entry[] globs = pjse.FileTable.GFT[0x474C4F42, item.Group];
                        ii.semiGlobal = (globs.Length == 0) ? 0 : ((SimPe.Plugin.Glob)globs[0].Wrapper).SemiGlobalGroup;

                        System.IO.BinaryReader reader = wrapper.StoredData;
                        if (reader.BaseStream.Length >= 0x40) // filename length
                        {
                            ii.objdName = SimPe.Helper.ToString(reader.ReadBytes(0x40)).Trim();
                            ii.objdGroup = wrapper.FileDescriptor.Group;
                            if (reader.BaseStream.Length > 0x52 + 2) // sizeof(ushort)
                            {
                                reader.BaseStream.Seek(0x52, System.IO.SeekOrigin.Begin);
                                ii.objdType = reader.ReadUInt16();
                                if (reader.BaseStream.Length > 0x5c + 4) // sizeof(uint)
                                {
                                    reader.BaseStream.Seek(0x5c, System.IO.SeekOrigin.Begin);
                                    UInt32 objdGUID = reader.ReadUInt32();
                                    guidIndex[objdGUID] = ii;
                                }
                            }
                        }
                    }
                    finally { SimPe.Wait.Progress++; }
                }
                pjse.FileTable.GFT.OnFiletableRefresh(this, new EventArgs());
            }
            finally
            {
                SimPe.Wait.Stop();
            }
        }

        public void Load() { Load(DefaultGUIDFile); }
        public void Load(String fromFile)
        {
            if (File.Exists(fromFile))
            {
                bool hadV2hdr = false;
                guidIndex = new Dictionary<uint, IndexItem>();
                System.IO.StreamReader sr = new StreamReader(fromFile);
                for (string line = sr.ReadLine(); line != null; line = sr.ReadLine())
                {
                    if (line.StartsWith("#"))
                    {
                        if (line.Equals("# PJSE GUID Index - version 2"))
                            hadV2hdr = true;
                        continue;
                    }
                    if (!hadV2hdr) continue;
                    String[] s = line.Split(new char[] { '=' }, 5, StringSplitOptions.None);
                    if (s.Length != 5) continue;
                    try
                    {
                        IndexItem ii = new IndexItem();
                        UInt32 guid = Convert.ToUInt32(s[0], 16);
                        ii.objdGroup = Convert.ToUInt32(s[1], 16);
                        ii.semiGlobal = Convert.ToUInt32(s[2], 16);
                        ii.objdType = Convert.ToUInt16(s[3], 16);
                        ii.objdName = s[4].Trim();
                        guidIndex[guid] = ii;
                    }
                    catch (System.FormatException) { continue; }
                }
                sr.Close();
                sr.Dispose();
                sr = null;
                pjse.FileTable.GFT.OnFiletableRefresh(this, new EventArgs());
            }
        }

        public void Save() { Save(DefaultGUIDFile); }
        public void Save(String toFile)
        {
            if (!System.IO.Directory.Exists(Path.Combine(SimPe.Helper.SimPePluginDataPath, "pjse.coder.plugin")))
                System.IO.Directory.CreateDirectory(Path.Combine(SimPe.Helper.SimPePluginDataPath, "pjse.coder.plugin"));
            System.IO.StreamWriter sw = new StreamWriter(toFile, false);
            sw.WriteLine("# PJSE GUID Index - version 2");
            foreach (UInt32 guid in guidIndex.Keys)
                sw.WriteLine("0x" + SimPe.Helper.HexString(guid)
                    + "=0x" + SimPe.Helper.HexString(guidIndex[guid].objdGroup)
                    + "=0x" + SimPe.Helper.HexString(guidIndex[guid].semiGlobal)
                    + "=0x" + SimPe.Helper.HexString(guidIndex[guid].objdType)
                    + "=" + guidIndex[guid].objdName
                    );
            sw.Close();
            sw.Dispose();
            sw = null;
        }

        public bool IsLoaded { get { return guidIndex != null; } }

        #region IDictionary<uint,string> Members

        public void Add(uint key, string value) { throw new Exception("The method or operation is not implemented."); }

        public bool ContainsKey(uint key) { return guidIndex.ContainsKey(key); }

        public ICollection<uint> Keys { get { return guidIndex.Keys; } }

        public bool Remove(uint key) { throw new Exception("The method or operation is not implemented."); }

        public bool TryGetValue(uint key, out string value)
        {
            IndexItem ii;
            if (!guidIndex.TryGetValue(key, out ii)) { value = null; return false; }
            value = ii.objdName;
            return true;
        }

        public ICollection<string> Values { get { List<string> x = new List<string>(); foreach (IndexItem ii in guidIndex.Values) x.Add(ii.objdName); return x; } }


        public string this[uint key]
        {
            get { string s; return (guidIndex == null || !guidIndex.ContainsKey(key) || (s = (String)guidIndex[key].objdName) == null || s.Length == 0) ? null : s; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

        #region ICollection<KeyValuePair<uint,string>> Members

        public void Add(KeyValuePair<uint, string> item) { throw new Exception("The method or operation is not implemented."); }

        public void Clear() { throw new Exception("The method or operation is not implemented."); }

        public bool Contains(KeyValuePair<uint, string> item) { throw new Exception("The method or operation is not implemented."); }

        public void CopyTo(KeyValuePair<uint, string>[] array, int arrayIndex) { foreach (uint key in guidIndex.Keys) array[arrayIndex++] = new KeyValuePair<uint, string>(key, guidIndex[key].objdName); }

        public int Count { get { return guidIndex.Count; } }

        public bool IsReadOnly { get { return true; } }

        public bool Remove(KeyValuePair<uint, string> item) { throw new Exception("The method or operation is not implemented."); }

        #endregion

        #region IEnumerable<KeyValuePair<uint,string>> Members

        public IEnumerator<KeyValuePair<uint, string>> GetEnumerator()
        {
            Dictionary<uint, string> res = new Dictionary<uint, string>();
            foreach (uint key in guidIndex.Keys) res.Add(key, guidIndex[key].objdName);
            return res.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator() { return guidIndex.GetEnumerator(); }

        #endregion


        /*ushort[] KnownObjTypes = new ushort[] {
            0x0000, 0x0002, 0x0004,
            0x0005, 0x0007, 0x0008,
            0x0009, 0x000A, 0x000B, 0x000C,
            0x000D, 0x000E, 0x000F, 0x0010,
            0x0013
        };*/
        public Dictionary<uint, string> ByObjType(ushort type)
        {
            Dictionary<uint, string> res = new Dictionary<uint, string>();
            foreach (KeyValuePair<uint, IndexItem> kvp in guidIndex) if (kvp.Value.objdType == type) res.Add(kvp.Key, kvp.Value.objdName);
            return res;
        }

        public Dictionary<uint, string> BySemiGlobal(string semiGroupName) { return BySemiGlobal(SimPe.Data.MetaData.SemiGlobalID(semiGroupName)); }
        public Dictionary<uint, string> BySemiGlobal(uint semiGroup)
        {
            Dictionary<uint, string> res = new Dictionary<uint, string>();
            foreach (KeyValuePair<uint, IndexItem> kvp in guidIndex) if (kvp.Value.semiGlobal == semiGroup) res.Add(kvp.Key, kvp.Value.objdName);
            return res;
        }

        public List<uint> GroupsForSemiGlobal(string semiGroupName) { return GroupsForSemiGlobal(SimPe.Data.MetaData.SemiGlobalID(semiGroupName)); }
        public List<uint> GroupsForSemiGlobal(uint semiGroup)
        {
            List<uint> res = new List<uint>();
            foreach (KeyValuePair<uint, IndexItem> kvp in guidIndex) if (kvp.Value.semiGlobal == semiGroup) res.Add(kvp.Value.objdGroup);
            return res;
        }

        public uint GUIDforGroup(uint group) { foreach (KeyValuePair<uint, IndexItem> kvp in guidIndex) if (kvp.Value.objdGroup == group) return kvp.Key; return 0; }
        public uint GroupforGUID(uint GUID) { return guidIndex.ContainsKey(GUID) ? guidIndex[GUID].objdGroup : 0; }
    }
}
