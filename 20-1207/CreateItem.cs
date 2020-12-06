using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    abstract class CreateItem
    {
        public string Contents { get; private set; }

        public CreateItem(string contents)
        {
            Contents = contents;
        }

        protected abstract BaseItem Create();

        public BaseItem Ready()
        {
            var item = Create();
            item.Ready();
            return item;
        }
    }

    class CreateConsoleItem : CreateItem
    {
        public CreateConsoleItem(string contents) : base(contents)
        {

        }

        protected override BaseItem Create()
        {
            return new ConsoleItem(Contents);
        }
    }

    class CreateTextFileItem : CreateItem
    {
        public string FileName { get; private set; }
        private readonly string Ext = ".txt";
        private readonly string FilePath = @"C:\Users\Chanos\Desktop\git\PlayGround\20-1207\textitem";

        public CreateTextFileItem(string contents, string filename) : base(contents)
        {
            FileName = filename;
        }

        protected override BaseItem Create()
        {
            string file = Path.Combine(FilePath, Path.ChangeExtension(FileName, Ext));
            return new TextFileItem(file, Contents);
        }
    }
}
