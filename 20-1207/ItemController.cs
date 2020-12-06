using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayGround
{
    class ItemController
    {
        private int ItemEngine = 4;
        private int Count = 1;
        private object thislock { get; set; }
        private Queue<BaseItem> ItemQueue { get; set; }

        private ItemController()
        {
            thislock = new object();
            ItemQueue = new Queue<BaseItem>();
        }

        public static ItemController Instance { get; }

        static ItemController()
        {
            if (Instance is null)
                Instance = new ItemController();
        }

        public void Finished()
        {
            lock(thislock)
            {
                Count--;
            }
        }

        public void Enqueue(BaseItem item)
        {
            lock(thislock)
            {
                ItemQueue.Enqueue(item);
            }
        }

        public BaseItem Dequeue()
        {
            lock (thislock)
            {
                if (ItemQueue.Count != 0)
                {
                    if (Count > ItemEngine)
                        return null;
                    else
                    {
                        Count++;
                        return ItemQueue.Dequeue();
                    }
                }
                else
                    return null;
            }
        }

        public async void Deploy()
        {
            await Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (Dequeue() is BaseItem item)
                    {
                        Start(item);
                    }
                    Thread.Sleep(100);
                }
            });
        }

        public async void Start(BaseItem item)
        {
            await Task.Factory.StartNew(() =>
            {
                item.Start();
                Thread.Sleep(500);
                item.Finish();
            }).ContinueWith((task) => Finished());
        }
    }
}
