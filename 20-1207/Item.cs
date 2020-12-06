using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    abstract class BaseItem : IItemAction
    {
        public BaseItem(string contents)
        {
            Contents = contents;
        }

        public string Contents { get; private set; }

        public abstract void Start();
        public abstract void Ready();
        public abstract void Finish();
    }

    class ConsoleItem : BaseItem
    {
        public ConsoleItem(string contents) : base(contents)
        {

        }

        public override void Start()
        {
            Console.WriteLine($"콘솔 {Contents} 시작!");
        }

        public override void Ready()
        {
            Console.WriteLine($"콘솔 {Contents} 준비!");
        }

        public override void Finish()
        {
            Console.WriteLine($"콘솔 {Contents} 끝!");
        }
    }

    class TextFileItem : BaseItem
    {
        public string FileName { get; private set; } 
        private FileStream FileStream { get; set; }

        public TextFileItem(string fileName, string contents) : base(contents)
        {
            FileName = fileName;
        }

        public override void Start()
        {
            byte[] contentsByte = Encoding.UTF8.GetBytes(Contents);
            FileStream.Write(contentsByte, 0, contentsByte.Length);
            Console.WriteLine($"파일 {FileName} : 쓰기 {Contents}");
        }

        public override void Ready()
        {
            if (File.Exists(FileName))
            {
                FileStream = File.Open(FileName, FileMode.Append);
                Console.WriteLine($"파일 {FileName} : 이어쓰기");
            }
            else
            {
                FileStream = File.Create(FileName);
                Console.WriteLine($"파일 {FileName} : 생성");
            }

            Console.WriteLine($"파일 {FileName} : 준비");
        }

        public override void Finish()
        {
            FileStream.Close();
            Console.WriteLine($"파일 {FileName} : 끝");
        }
    }
}
