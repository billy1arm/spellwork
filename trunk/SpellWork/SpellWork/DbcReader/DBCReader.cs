using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Collections.Generic;

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
}
