using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;

namespace SpellWork.DbcReader
{
    class DBCReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="dbcTable"></param>
        /// <param name="shem"></param>
        public DBCReader(string fileName, ref DataTable dbcTable, String[][] shem)
        {
            GenericReader reader = new GenericReader(fileName, Encoding.UTF8);

            if (reader.BaseStream.Length < 20 || reader.ReadUInt32() != 0x43424457)
                return;
            
            int recordsCount    = reader.ReadInt32();
            int fieldsCount     = reader.ReadInt32();
            int recordSize      = reader.ReadInt32();
            int stringTableSize = reader.ReadInt32();

            reader.BaseStream.Position = reader.BaseStream.Length - stringTableSize;

            GenericReader stringsReader = new GenericReader(new MemoryStream(reader.ReadBytes(stringTableSize)), Encoding.UTF8);

            reader.BaseStream.Position = 20;

            byte[][] m_rows = new byte[recordsCount][];

            for (int i = 0; i < recordsCount; i++)
            {
                m_rows[i] = reader.ReadBytes(recordSize);
            }
            reader.Close();

            foreach (var field in shem)
            {
                dbcTable.Columns.Add(field[1].ToString());
            }

            for (int i = 0; i < recordsCount; ++i)
            {
                GenericReader rowsReader = new GenericReader(new MemoryStream(m_rows[i]), Encoding.UTF8);
                DataRow rows = dbcTable.NewRow();

                foreach (var field in shem)
                {
                    #region Read Type

                    switch (field[0])
                    {
                        //case "long": rows[field[1]] = rowsReader.ReadInt64();
                        //    break;
                        //case "ulong": rows[field[1]] = rowsReader.ReadUInt64();
                        //    break;
                        case "int": rows[field[1]] = rowsReader.ReadInt32();
                            break;
                        case "uint": rows[field[1]] = rowsReader.ReadUInt32();
                            break;
                        //case "short": rows[field[1]] = rowsReader.ReadInt16();
                        //    break;
                        //case "ushort": rows[field[1]] = rowsReader.ReadUInt16();
                        //    break;
                        //case "sbyte": rows[field[1]] = rowsReader.ReadSByte();
                        //    break;
                        //case "byte": rows[field[1]] = rowsReader.ReadByte();
                        //    break;
                        case "float": rows[field[1]] = Regex.Replace(rowsReader.ReadSingle().ToString(), @",", @".");
                            break;
                        //case "double": rows[field[1]] = Regex.Replace(rowsReader.ReadDouble().ToString(), @",", @".");
                        //    break;
                        case "string": rows[field[1]] = GetString(ref stringsReader, rowsReader.ReadInt32());
                            break;
                        default:
                            break;
                    }

                    #endregion
                }

                dbcTable.Rows.Add(rows);

                reader.Close();
            }
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringReader"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        string GetString(ref GenericReader stringReader, int offset)
        {
            stringReader.BaseStream.Position = offset;
            return stringReader.ReadStringNull();
        }     
    }
}
