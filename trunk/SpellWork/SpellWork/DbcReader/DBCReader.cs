using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SpellWork
{
    class DBCReader
    {
        public DBCReader(string fileName, ref DataTable dbcTable, String[][] shem)
        {
            GenericReader reader = new GenericReader(fileName, Encoding.UTF8);

            if (reader.BaseStream.Length < 20 || reader.ReadUInt32() != 0x43424457)
                return;

            int recordsCount    = reader.ReadInt32();
            int fieldsCount     = reader.ReadInt32();
            int recordSize      = reader.ReadInt32();
            int stringTableSize = reader.ReadInt32();

            GenericReader dataReader = new GenericReader(new MemoryStream(reader.ReadBytes(recordsCount * recordSize)), Encoding.UTF8);
            GenericReader stringsReader = new GenericReader(new MemoryStream(reader.ReadBytes(stringTableSize)), Encoding.UTF8);
            
            reader.Close();

            byte[][] m_rows = new byte[recordsCount][];

            for (int i = 0; i < recordsCount; i++)
                m_rows[i] = dataReader.ReadBytes(recordSize);

            foreach (var field in shem)
                 dbcTable.Columns.Add(field[1].ToString());

            for (int i = 0; i < recordsCount; ++i)
            {
                GenericReader rowsReader = new GenericReader(new MemoryStream(m_rows[i]), Encoding.UTF8);
                DataRow rows = dbcTable.NewRow();

                foreach (var field in shem)
                {
                    switch (field[0])
                    {
                        case "ulong":  rows[field[1]] = rowsReader.ReadUInt64();
                            break;
                        case "int":    rows[field[1]] = rowsReader.ReadInt32();
                            break;
                        case "uint":   rows[field[1]] = rowsReader.ReadUInt32();
                            break;
                        case "float":  rows[field[1]] = Regex.Replace(rowsReader.ReadSingle().ToString(), @",", @".");
                            break;
                        case "string": rows[field[1]] = stringsReader.ReadStringDbc(rowsReader.ReadInt32());
                            break;
                        case "struct": rows[field[1]] = BinaryReaderExtensions.ReadStruct<SpellEntry>(rowsReader);
                            break;
                        default:
                            break;
                    }
                }
                dbcTable.Rows.Add(rows);
                rowsReader.Close();
            }
            dataReader.Close();
            stringsReader.Close();
        }
    }

    class GenericReader : BinaryReader
    {
        public GenericReader(Stream input, Encoding encoding) : base(input, encoding) { }

        public GenericReader(String fname, Encoding encoding) : base(new FileStream(fname, FileMode.Open, FileAccess.Read), encoding) { }

        public String ReadStringDbc(Int32 offset)
        {
            Byte num;
            List<Byte> temp = new List<Byte>();
            this.BaseStream.Position = offset;

            while ((num = this.ReadByte()) != 0)
                temp.Add(num);

            return Encoding.UTF8.GetString(temp.ToArray());
        }
    }

    public static class BinaryReaderExtensions
    {
        /// <summary>  Reads the packed guid from the current stream and 
        /// advances the current position of the stream by packed guid size.
        /// </summary>
        public static ulong ReadPackedGuid(this BinaryReader reader)
        {
            byte mask = reader.ReadByte();

            if (mask == 0)
            {
                return 0;
            }

            ulong res = 0;

            int i = 0;
            while (i < 8)
            {
                if ((mask & 1 << i) != 0)
                {
                    res += (ulong)reader.ReadByte() << (i * 8);
                }
                i++;
            }

            return res;
        }

        /// <summary> Reads the NULL terminated string from 
        /// the current stream and advances the current position of the stream by string length + 1.
        /// <seealso cref="BinaryReader.ReadString"/>
        /// </summary>
        public static string ReadCString(this BinaryReader reader)
        {
            return reader.ReadCString(Encoding.UTF8);
        }

        /// <summary> Reads the NULL terminated string from 
        /// the current stream and advances the current position of the stream by string length + 1.
        /// <seealso cref="BinaryReader.ReadString"/>
        /// </summary>
        public static string ReadCString(this BinaryReader reader, Encoding encoding)
        {
            var bytes = new List<byte>();
            byte b;
            while ((b = reader.ReadByte()) != 0)
            {
                bytes.Add(b);
            }
            return encoding.GetString(bytes.ToArray());
        }

        /// <summary> Reads struct from the current stream and advances the 
        /// current position if the stream by SizeOf(T) bytes.
        /// </summary>
        public static T ReadStruct<T>(this BinaryReader reader) where T : struct
        {
            byte[] rawData = reader.ReadBytes(Marshal.SizeOf(typeof(T)));
            GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            var returnObject = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return returnObject;
        }
    }
}
