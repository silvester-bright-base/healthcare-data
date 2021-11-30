using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silvester.BrightBase.Healthcare.Seeding.Parsers
{
    public interface IParser<TModel>
    {
        IEnumerable<TModel> Parse(Stream csv);
    }

    public abstract class BaseParser<TModel> : IParser<TModel>
    {
        public IEnumerable<TModel> Parse(Stream csv)
        {
            TextFieldParser parser = new TextFieldParser(csv, Encoding.UTF8, detectEncoding: true, leaveOpen: true);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            //This takes the header row out of the way.
            _ = parser.ReadFields();

            while (parser.EndOfData == false)
            {
                string[] row = parser.ReadFields()!;
                yield return Deserialize(row);
            }
        }

        protected abstract TModel Deserialize(string[] row);
    }
}
